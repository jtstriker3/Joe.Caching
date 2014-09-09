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
    public class CacheHandle
    {
        public Delegate Function { get; private set; }
        private TimeSpan Duration { get; set; }
        public DateTime Expiration { get; private set; }
        private ICacheProvider<String, Object> CachedObjects { get; set; }
        private String Key { get; set; }

        public CacheHandle(Delegate function, TimeSpan duration, String key, ICacheProvider<String, Object> cachedObjectProvider = null)
        {
            Function = function;
            Duration = duration;
            this.SetNewExpiration();
            Key = key;
            CachedObjects = cachedObjectProvider ?? new DefaultCacheProvider();
        }

        public Object GetItem(params Object[] parameters)
        {
            var key = this.GetKey(parameters);
            if (!CachedObjects.ContainsKey(key))
                CachedObjects.AddOrUpdate(key, this.Function.DynamicInvoke(parameters), (String updateKey, Object newObject) =>
                {
                    return newObject;
                });
            else if (DateTime.Now > Expiration)
            {
                this.SetNewExpiration();
                CachedObjects[key] = this.Function.DynamicInvoke(parameters);
            }
            return CachedObjects[key];

        }

        public int CachedObjectCount(){
            return this.CachedObjects.Count;
        }

        private void SetNewExpiration()
        {
            Expiration = Duration == TimeSpan.MaxValue ? DateTime.MaxValue : DateTime.Now.Add(Duration);
        }

        public void Flush()
        {
            Expiration = DateTime.Now;
        }

        public void FlushItem(params Object[] parameters)
        {
            Object outObject = null;
            var key = this.GetKey(parameters);
            if (CachedObjects.ContainsKey(key))
                CachedObjects.TryRemove(key, out outObject);
        }

        private string GetKey(Object[] parameters)
        {

            var hash = new StringBuilder();
            hash.Append(Function.GetHashCode().ToString());
            foreach (var parameter in parameters)
                if (parameter != null)
                    hash.Append(GetJson(parameter));
                else
                    hash.Append(-1);

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
