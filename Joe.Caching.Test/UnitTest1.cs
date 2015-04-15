using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Joe.Caching;
using System.IO;
using System.Diagnostics;
using System.Threading;

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

        [TestMethod]
        public void TestDoNotHash()
        {
            var cache = Joe.Caching.Cache.Instance;
            var result = cache.GetOrAdd("1", new TimeSpan(0, 0, 10), TestDelegate, "1", "2");

            Assert.AreEqual("12", result);

            result = cache.Get<String>("1", "1", "2");

            Assert.AreEqual("12", result);
        }

        public static string TestDelegate([DoNotHash]String arg1, String arg2)
        {
            return arg1 + arg2;
        }

        [TestMethod]
        public void TestZeroTimeSpan()
        {
            var cache = Joe.Caching.Cache.Instance;
            var result = cache.GetOrAdd("1", new TimeSpan(0, 0, 0), (String arg1, String arg2) =>
            {
                return arg1 + arg2;
            }, "1", "2");

            Assert.AreEqual("12", result);

            result = cache.Get<String>("1", "1", "2");

            Assert.AreEqual("12", result);
        }  

        //[TestMethod]
        //public void MemoryTest()
        //{

        //    var text = File.ReadAllText(@"C:\memTest.txt");
        //    var currentMemory = Process.GetCurrentProcess().PrivateMemorySize64;
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        var cache = Joe.Caching.Cache.Instance;
        //        var result = cache.GetOrAdd(i.ToString(), new TimeSpan(0, 0, 0), (String t) =>
        //        {
        //            string temp = t;
        //            return temp;
        //        }, text);
        //    }
        //    //Give GC some Time
        //    Thread.Sleep(15000);
        //    var afterMemory = Process.GetCurrentProcess().PrivateMemorySize64;

        //    Assert.IsTrue(afterMemory <= currentMemory + 10000000);
        //}

        //[TestMethod]
        //public void UseMemoryTest()
        //{

        //    var text = File.ReadAllText(@"C:\memTest.txt");
        //    var currentMemory = Process.GetCurrentProcess().PrivateMemorySize64;
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        var cache = Joe.Caching.Cache.Instance;
        //        var result = cache.GetOrAdd(i.ToString(), new TimeSpan(0, 0, 0), (String t) =>
        //        {
        //            string temp = t;
        //            return temp;
        //        }, text);
        //    }
        //    //Give GC some Time
        //    Thread.Sleep(5000);
        //    var afterMemory = Process.GetCurrentProcess().PrivateMemorySize64;

        //    Assert.IsTrue(afterMemory > currentMemory + 10000000);
        //}
    }

    class FileHolder
    {
        public String Text { get; set; }
        public FileHolder(String text)
        {
            Text = text;
        }
    }
}
