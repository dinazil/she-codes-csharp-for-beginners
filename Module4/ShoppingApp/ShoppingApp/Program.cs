using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    class Program
    {
        static bool IsProductInCatalog(string product, string[] catalog)
        {
            foreach (string productInCatalog in catalog)
            {
                if (product == productInCatalog)
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*** Hello! Welcome to the shopping application. ***");

            string[] catalog = File.ReadAllLines("catalog.txt");

            string[] cart = new string[5];
            
            int productsAdded = 0;
            while (productsAdded < cart.Length)
            {
                Console.Write("Enter a product: ");
                string product = Console.ReadLine();
                if (!IsProductInCatalog(product, catalog))
                {
                    Console.WriteLine("Sorry, the product \"{0}\" is not in the catalog. Try another product.", product);
                }
                else
                {
                    cart[productsAdded] = product;
                    productsAdded = productsAdded + 1;
                    Console.WriteLine("$$$ \"{0}\" has been added to your shopping cart.", product);
                }
            }

            Console.WriteLine("*** You're ready to check out! Here are the products in your shopping cart: ***");
            foreach (string product in cart)
            {
                Console.WriteLine(product);
            }
        }
    }
}
