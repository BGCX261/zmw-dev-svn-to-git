using BaiduApi;
using BaiduApi.Api;
using BaiduApi.Models.Conditions;
using BaiduApi.Models.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BaiduApi.Models;

namespace BaiduApi.Test
{


    /// <summary>
    ///PlaceApiTest のテスト クラスです。すべての
    ///PlaceApiTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class PlaceApiTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 追加のテスト属性
        // 
        //テストを作成するときに、次の追加属性を使用することができます:
        //
        //クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //各テストを実行する前にコードを実行するには、TestInitialize を使用
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //各テストを実行した後にコードを実行するには、TestCleanup を使用
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Place のテスト
        ///</summary>
        [TestMethod()]
        public void PlaceTest()
        {
            PlaceApi target = new PlaceApi("key");
            PlaceCondition condition = new PlaceCondition()
                                           {
                                               Query = "ATM",
                                               Region = "上海"
                                           };

            try
            {
                target.Place(condition);

                Assert.Fail();
            }
            catch
            {

            }

        }

        /// <summary>
        ///PlaceApi コンストラクター のテスト
        ///</summary>
        [TestMethod()]
        public void PlaceApiConstructorTest()
        {
            PlaceApi target = new PlaceApi("key");
        }
    }
}
