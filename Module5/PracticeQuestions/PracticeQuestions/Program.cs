using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            SunTimes times = new SunTimes(DateTime.Now.AddHours(-2), DateTime.Now.AddHours(8));
            Console.WriteLine("Daylight minutes: " + times.DaylightMinutes());

            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(1400);
            cart.AddProduct(17);
            cart.Checkout();
        }
    }
}
