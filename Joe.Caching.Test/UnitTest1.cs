using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Joe.Caching.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFunc()
        {
            var cache = Joe.Caching.Cache.Instance;
            var result = cache.GetOrAdd("1", new TimeSpan(0, 0, 10), (String arg1, String arg2) =>
            {
                return arg1 + arg2;
            }, "1", "2");

            Assert.AreEqual("12", result);

            result = cache.Get<String>("1", "1", "2");

            Assert.AreEqual("12", result);
        }
    }
}
