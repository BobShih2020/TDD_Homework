using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Day1_Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;

namespace TDD_Day1_Homework.Tests
{
    [TestClass()]
    public class TDD_Day1_HomeworkTests
    {
        private List<TestItem> _BookItems;

        private GetSum _Target;

        private TestContext testContextInstance;

        /// <summary>
        ///取得或設定提供目前測試回合
        ///的相關資訊與功能的測試內容。
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

        [TestInitialize()]
        public void MyTestInitialize()
        {
            Console.WriteLine("TestInitialize" + this.TestContext.TestName);
            this._Target = new GetSum();
            this._BookItems = new List<TestItem>()
            {
                new TestItem {ID=1, Cost=1, Revenue=11, SellPrice=21},
                new TestItem {ID=2, Cost=2, Revenue=12, SellPrice=22},
                new TestItem {ID=3, Cost=3, Revenue=13, SellPrice=23},
                new TestItem {ID=4, Cost=4, Revenue=14, SellPrice=24},
                new TestItem {ID=5, Cost=5, Revenue=15, SellPrice=25},
                new TestItem {ID=6, Cost=6, Revenue=16, SellPrice=26},
                new TestItem {ID=7, Cost=7, Revenue=17, SellPrice=27},
                new TestItem {ID=8, Cost=8, Revenue=18, SellPrice=28},
                new TestItem {ID=9, Cost=9, Revenue=19, SellPrice=29},
                new TestItem {ID=10, Cost=10, Revenue=20, SellPrice=30},
                new TestItem {ID=11, Cost=11, Revenue=21, SellPrice=31}
            };
        }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Console.WriteLine("TestCleanup" + this.TestContext.TestName);
            this._BookItems.Clear();
        }

        [TestMethod()]
        public void GetSumCostTest_3筆一組計算Cost欄位加總()
        {
            //arrange
            var expected = new int[] { 6, 15, 24, 21 };

            //act            
            var actual = this._Target.GetSumCost(this._BookItems, 3);


            //assert
            CollectionAssert.AreEquivalent(expected, actual);

        }

        [TestMethod()]
        public void GetSumRevenueTest_4筆一組計算Revenue欄位加總()
        {
            //arrange            
            var expected = new int[] { 50, 66, 60 };

            //act            
            var actual = this._Target.GetSumRevenue(this._BookItems, 4);


            //assert
            CollectionAssert.AreEquivalent(expected, actual);

        }

        [TestMethod()]
        public void GetSumTest_3筆一組計算Cost欄位加總()
        {
            //arrange            
            var expected = new int[] { 6, 15, 24, 21 };

            //act            
            var actual = this._Target.GetSumByPropertyName(this._BookItems, 3, "Cost");


            //assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void GetSumAllPropertyTest_3筆一組計算所有欄位的Sum()
        {
            //arrange
            var expected =                
                new int[][] {
                    new int[]{ 6, 15, 24, 21 },
                    new int[]{ 6, 15, 24, 21 },
                    new int[]{ 36, 45, 54, 41 },
                    new int[]{ 66, 75, 84, 61 }                    
                };

            //act
            var actual = this._Target.GetSumAllProperty(this._BookItems, 3);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
            
        }
    }
}