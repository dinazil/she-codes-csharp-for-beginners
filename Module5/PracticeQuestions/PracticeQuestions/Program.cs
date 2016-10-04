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
            Rational rational = new Rational(1, 3);
            Rational another = new Rational(1, 2);
            rational.Add(another);
            Console.WriteLine("Sum: " + rational.Numerator + "/" + rational.Denominator);

            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(1400);
            cart.AddProduct(17);
            cart.Checkout();
        }
    }
}
