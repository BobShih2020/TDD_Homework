using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class PotterShoppingCart
    {
        public int GetPrice(List<Book> books)
        {
            return books.Sum(t => t.Price);
        }

    }

    public class Book
    {
        public Book(string bookName, int price = 100)
        {
            this.BookName = bookName;
            this.Price = price;
        }
        public string BookName { get; }

        public int Price { get; }
    }



}
