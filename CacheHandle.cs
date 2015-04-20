using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Joe.Caching
{
    class CacheHandle
    {
        public Delegate Function { get; private set; }
        private TimeSpan Duration { get; set; }
        private ICacheProvider CachedObjects { get; set; }
        private String Key { get; set; }
        private bool isZeroTimeSpan { get; set; }

        public CacheHandle(Delegate function, TimeSpan duration, String key, ICacheProvider cachedObjectProvider = null)
        {
            Function = function;
            Duration = duration;
            Key = key;
            CachedObjects = cachedObjectProvider ?? new DefaultCacheProvider();
            isZeroTimeSpan = duration.TotalMilliseconds == 0.0;
        }

        public Object GetItem(params Object[] parameters)
        {
            if (!isZeroTimeSpan)
            {
                var key = this.GetKey(parameters);
                if (!CachedObjects.ContainsKey(key))
                    CachedObjects.AddOrUpdate(key,
                        new CachedObject(this.GetNewExpiration(), this.Function.DynamicInvoke(parameters)),
                        (String updateKey, CachedObject newObject) =>
                        {
                            return newObject;
                        });
                else
                {
                    var cachedObject = CachedObjects[key];
                    if (cachedObject.Expiration <= DateTime.Now)
                        CachedObjects.AddOrUpdate(key,
                        new CachedObject(this.GetNewExpiration(), this.Function.DynamicInvoke(parameters)),
                        (String updateKey, CachedObject newObject) =>
                        {
                            return newObject;
                        });
                }

                return CachedObjects[key].Value;
            }
            else
                return this.Function.DynamicInvoke(parameters);

        }

        public int CachedObjectCount()
        {
            return this.CachedObjects.Count;
        }

        private DateTime GetNewExpiration()
        {
            return Duration == TimeSpan.MaxValue ? DateTime.MaxValue : DateTime.Now.Add(Duration);
        }

        public void Flush()
        {
            CachedObjects.Clear();
        }

        public void FlushItem(params Object[] parameters)
        {
            CachedObject outObject = null;
            var key = this.GetKey(parameters);
            if (CachedObjects.ContainsKey(key))
                CachedObjects.TryRemove(key, out outObject);
        }

        private string GetKey(Object[] parameters)
        {
            var parameterInfos = Function.Method.GetParameters();
            var hash = new StringBuilder();
            hash.Append(Function.GetHashCode().ToString());
            var count = 0;
            foreach (var parameter in parameters)
            {
                var doNotHash = parameterInfos[count].GetCustomAttributes(typeof(DoNotHashAttribute), true).Count() > 0;
                if (!doNotHash)
                    if (parameter != null)
                        hash.Append(GetJson(parameter));
                    else
                        hash.Append(-1);
                count++;
            }

            return Key + GetMD5Hash(hash.ToString());
        }

        private String GetJson<T>(T source)
        {
            return JsonConvert.SerializeObject(source);
        }

        private String GetMD5Hash(String source)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            Byte[] hash = null;

            var bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(source);
            hash = md5.ComputeHash(bytes);

            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < hash.Length; i++)
            {
                sBuilder.Append(hash[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}
