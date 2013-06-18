using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe.Caching
{
    public class Cache
    {
        public static ICacheProvider<int, Object> CacheProvider { get; set; }
        private static Cache _instance;
        private IDictionary<String, CacheHandle> _delegates = new Dictionary<String, CacheHandle>();
        public static Cache Instance
        {
            get
            {
                _instance = _instance ?? new Cache();
                return _instance;
            }
        }

        public void Add(String key, TimeSpan duration, Delegate handle)
        {
            if (_delegates.ContainsKey(key))
                throw new Exception("Cache already contains an entry for the given key");

            _delegates.Add(key, new CacheHandle(handle, duration, CacheProvider));
        }

        public void Remove(String key)
        {
            _delegates.Remove(key);
        }

        public void Flush(String key)
        {
            if (_delegates.ContainsKey(key))
                _delegates[key].Flush();
        }

        public void Flush()
        {
            foreach (var cacheHandle in _delegates)
                cacheHandle.Value.Flush();
        }

        public void Clear()
        {
            _delegates.Clear();
        }

        public Object Get(String key, params Object[] parameters)
        {
            if (_delegates.ContainsKey(key))
                return _delegates[key].GetItem(parameters);
            return null;
        }
    }
}
