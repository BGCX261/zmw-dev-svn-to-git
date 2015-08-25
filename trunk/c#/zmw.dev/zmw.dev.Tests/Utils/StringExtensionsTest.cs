using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using zmw.dev.utils;

namespace zmw.dev.Tests.Utils
{
    [TestFixture]
    public class StringExtensionsTest
    {
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        #endregion

        #region Tests

        [Test]
        public void Test()
        {
            Assert.AreEqual("TOTALAoij", "TOTAL_aoij".ToTitleCase(new[] { "_" }));
            Assert.AreEqual("SpUsermasterVf", "sp_usermaster_vf".ToTitleCase(new[] { "_" }));
            Assert.AreEqual("SpUsermasterVf", "sp_usermaster_vf".ToTitleCase("_"));
            Assert.AreEqual("Joke For Life", "joke for life".ToTitleCase());


        }

        #endregion
    }
}
