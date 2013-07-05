using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe.Caching
{
    public class CacheHandle
    {
        public Delegate Function { get; private set; }
        private TimeSpan Duration { get; set; }
        private DateTime Experiation { get; set; }
        private ICacheProvider<int, Object> CachedObjects { get; set; }

        public CacheHandle(Delegate function, TimeSpan duration, ICacheProvider<int, Object> cachedObjectProvider = null)
        {
            Function = function;
            Duration = duration;
            Experiation = DateTime.Now.Add(duration);
            CachedObjects = cachedObjectProvider ?? new DefaultCacheProvider();
        }

        public Object GetItem(params Object[] parameters)
        {
            var key = this.GetKey(parameters);
            if (!CachedObjects.ContainsKey(key))
                CachedObjects.Add(key, this.Function.DynamicInvoke(parameters));
            else if (DateTime.Now > Experiation)
            {
                Experiation = DateTime.Now.Add(Duration);
                CachedObjects[key] = this.Function.DynamicInvoke(parameters);
            }
            return CachedObjects[key];

        }

        public void Flush()
        {
            Experiation = DateTime.Now;
        }

        private int GetKey(Object[] parameters)
        {
            int hash = Function.GetHashCode();
            foreach (var parameter in parameters)
                if (parameter != null)
                    hash += parameter.GetHashCode();
                else
                    hash += -1;

            return hash;
        }
    }
}
