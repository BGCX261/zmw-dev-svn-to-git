using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonUtils.Tools;

namespace CommonUtlis.Test.Tools
{
    [TestClass]
    public class ExcelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Excel excel = new Excel();
            excel.OpenFile("C:\\Users\\Zhuangmaowei\\Desktop\\見積もり.xlsx");

            var value1 = excel.GetValue<string>("A26");
            Assert.IsNotNull(value1);
        }
    }
}
