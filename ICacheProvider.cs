using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe.Caching
{
    public interface ICacheProvider
    {
        CachedObject AddOrUpdate(String key, CachedObject addValue, Func<String, CachedObject, CachedObject> updateValueFactory);
        CachedObject this[String key] { get; set; }
        bool ContainsKey(String key);
        void Clear();
        bool TryRemove(String key, out CachedObject value);
        int Count { get; }
    }
}
