using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class Book
    {
        public Book(string bookName, Decimal price, int quantity)
        {
            this.BookName = bookName;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string BookName { get; }

        public Decimal Price { get; }

        public int Quantity { get; set; }
    }
}
