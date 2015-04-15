using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joe.Caching
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class DoNotHashAttribute : Attribute
    {
    }
}
