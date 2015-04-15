using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Joe.Caching
{
    class DefaultCacheProvider : ConcurrentDictionary<String, CachedObject>, ICacheProvider
    {
    }
}
