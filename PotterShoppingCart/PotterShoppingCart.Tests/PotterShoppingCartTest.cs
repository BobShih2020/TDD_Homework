using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart;

namespace PotterShoppingCart.Tests
{
    /// <summary>
    /// Summary description for PotterShoppingCartTest
    /// </summary>
    [TestClass]
    public class PotterShoppingCartTest
    {
        public PotterShoppingCartTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        private static List<Book> GetShoppingCart(int quantity1, int quantity2, int quantity3, int quantity4, int quantity5)
        {
            List<Book> shoppingcart = new List<Book>();
            shoppingcart.Add(new Book("Potter1", 100, quantity1));
            shoppingcart.Add(new Book("Potter2", 100, quantity2));
            shoppingcart.Add(new Book("Potter3", 100, quantity3));
            shoppingcart.Add(new Book("Potter4", 100, quantity4));
            shoppingcart.Add(new Book("Potter5", 100, quantity5));
            return shoppingcart;
        }

        [TestMethod]
        public void 第一集買一本共100元()
        {
            //arrange
            var expected = 100;

            List<Book> shoppingcart = GetShoppingCart(1, 0, 0, 0, 0);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 第一集買一本第二集買一本共190元()
        {
            //arrange
            var expected = 190;

            List<Book> shoppingcart = GetShoppingCart(1, 1, 0, 0, 0);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三集各買了一本共270元()
        {
            //arrange
            var expected = 270;

            List<Book> shoppingcart = GetShoppingCart(1, 1, 1, 0, 0);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三四集各買了一本共320元()
        {
            //arrange
            var expected = 320;

            List<Book> shoppingcart = GetShoppingCart(1, 1, 1, 1, 0);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二三四五集各買了一本共375元()
        {
            //arrange
            var expected = 375;

            List<Book> shoppingcart = GetShoppingCart(1, 1, 1, 1, 1);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二集各一本第三集兩本共370元()
        {
            //arrange
            var expected = 370;

            List<Book> shoppingcart = GetShoppingCart(1, 1, 2, 0, 0);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 第一集一本第二三集各兩本共460元()
        {
            //arrange
            var expected = 460;

            List<Book> shoppingcart = GetShoppingCart(1, 2, 2, 0, 0);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 第一集一本第二三集各兩本第五集三本共690元()
        {
            //arrange
            var expected = 690;

            List<Book> shoppingcart = GetShoppingCart(1, 2, 2, 0, 3);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 第一集一本第二三集各兩本第四集三本第五集三本共885元()
        {
            //arrange
            var expected = 100*5*0.75M+100*4*0.8M+100*2*0.95M;

            List<Book> shoppingcart = GetShoppingCart(1, 2, 2, 3, 3);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 都不買應為0元()
        {
            //arrange
            var expected = 0;

            List<Book> shoppingcart = GetShoppingCart(0,0,0,0,0);

            //act            
            var actual = Cashier.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
