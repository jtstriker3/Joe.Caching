using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Joe.Caching
{
    public class Cache
    {
        public static ICacheProvider<String, Object> CacheProvider { get; set; }
        private static Cache _instance;
        private ConcurrentDictionary<String, CacheHandle> _delegates = new ConcurrentDictionary<String, CacheHandle>();
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
            _delegates.AddOrUpdate(key, new CacheHandle(handle, duration, key, CacheProvider), (String newKey, CacheHandle handleToAdd) =>
            {
                return handleToAdd;
            });
        }

        public void Remove(String key)
        {
            CacheHandle outHandle = null;
            _delegates.TryRemove(key, out outHandle);
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

        public Object GetOrAdd(String key, TimeSpan duration, Delegate handle, params Object[] parameters)
        {
            if (_delegates.ContainsKey(key))
                return this.Get(key, parameters);
            else
            {
                this.Add(key, duration, handle);
                return this.Get(key, parameters);
            }

        }

        public void FlushMany(String filter)
        {
            var items = _delegates.Where(handle => handle.Key.Contains(filter));
            foreach (var item in items)
                item.Value.Flush();
        }

        public void FlushMany(String filter, String keyNotToFlush = null, params Object[] parameters)
        {
            var items = _delegates.Where(handle => handle.Key.Contains(filter) && handle.Key != keyNotToFlush);
            foreach (var item in items)
                item.Value.FlushItem(parameters);
        }
    }
}
