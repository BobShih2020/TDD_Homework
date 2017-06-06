using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            List<Book> shoppingcart = GetShoppingCart(1,0,0,0,0);

            //act            
            var actual = Cashire.GetPrice(shoppingcart);

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
            var actual = Cashire.GetPrice(shoppingcart);

            //assert
            Assert.AreEqual(expected, actual);
        }

    }

    public class Cashire
    {
        internal static int GetPrice(List<Book> shoppingcart)
        {           
            return 100;
        }
    }

    public class Book
    {
        public Book(string bookName, int price, int quantity)
        {
            this.BookName = bookName;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string BookName { get; }

        public int Price { get; }

        public int Quantity { get; set; }
    }

}
