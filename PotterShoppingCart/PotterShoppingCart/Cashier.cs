using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class Cashier
    {     
        public static Decimal GetPrice(IEnumerable<Book> shoppingcart)
        {
            //數量0的以外有幾種書
            var order = shoppingcart.Where(t => t.Quantity > 0);
            var booktypecount = order.Count();

            //沒有數量則直接回傳0
            if (booktypecount == 0)
                return 0;

            //計算折數
            var discount = GetDiscount(booktypecount);

            //計算數量(取最小數量)
            var minquantity = order.Min(t => t.Quantity);

            //取得價格
            var orderprice = order.Select(t => t.Price).Sum();

            //計算金額(數量*價格*折數)
            var subtotal = minquantity * orderprice * discount;


            //扣除已計價數量
            var restorder = new List<Book>();


            foreach (var book in order)
            {
                book.Quantity -= minquantity;
                restorder.Add(book);
            }

            //計算總金額=小計+剩餘金額
            var totalprice = subtotal + GetPrice(restorder);

            return totalprice;

        }


        private static Decimal GetDiscount(int booktypecount)
        {
            switch (booktypecount)
            {                
                default:
                    return 1;
                case 2:
                    return 0.95M;
                case 3:
                    return 0.9M;
                case 4:
                    return 0.8M;
                case 5:
                    return 0.75M;
                
            }
        }
    }


}
