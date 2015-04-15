using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joe.Caching
{
    public class CachedItemView
    {
        public String Key { get; set; }
        //public DateTime Expiration { get; set; }
        public int CachedObjectCount { get; set; }
    }
}
