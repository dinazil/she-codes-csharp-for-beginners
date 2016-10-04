using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions
{
    class ShoppingCart
    {
        public int TotalPrice { get; set; }
        public int ProductCount { get; set; }

        public void AddProduct(int price)
        {
            TotalPrice += price;
            ProductCount += 1;
        }

        public void Checkout()
        {
            Console.WriteLine("Total price  : " + TotalPrice);
            Console.WriteLine("Product count: " + ProductCount);
            Console.WriteLine("Average price: " + (TotalPrice / ProductCount));
        }
    }
}
