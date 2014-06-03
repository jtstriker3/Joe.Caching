using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe.Caching
{
    public interface ICacheProvider<TKey, TValue>
    {
        TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory);
        TValue this[TKey key] { get; set; }
        bool ContainsKey(TKey key);
        void Clear();
        bool TryRemove(TKey key, out TValue value);
    }
}
