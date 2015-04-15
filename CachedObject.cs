using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joe.Caching
{
    public class CachedObject
    {
        public CachedObject(DateTime expiration, object value)
        {
            Expiration = expiration;
            Value = value;
        }

        public DateTime Expiration { get; private set; }
        public object Value { get; private set; }
    }
}
