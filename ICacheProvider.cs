using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe.Caching
{
    public interface ICacheProvider<TKey, TValue>
    {
        void Add(TKey key, TValue value);
        TValue this[TKey key] { get; set; }
        bool ContainsKey(TKey key);
        bool Remove(TKey key);
        void Clear();
    }
}
