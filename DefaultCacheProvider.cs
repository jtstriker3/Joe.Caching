using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe.Caching
{
    public class DefaultCacheProvider : Dictionary<int, Object>, ICacheProvider<int, Object>
    {
    }
}
