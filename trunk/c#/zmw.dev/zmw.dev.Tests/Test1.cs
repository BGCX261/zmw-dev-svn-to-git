using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using zmw.dev.utils;
using zmw.dev.utils.Attribute;

namespace zmw.dev.Tests
{
    [TestFixture]
    public class Test1
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
        enum MyEnum1
        {
            
            [EnumCode(1)]
            Value1,
            Value2

        }

        [Test]
        public void Test()
        {
        }

        #endregion
    }
}
