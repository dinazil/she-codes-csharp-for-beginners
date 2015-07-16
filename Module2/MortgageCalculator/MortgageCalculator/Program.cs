using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the house price: ");
            string priceInput = Console.ReadLine();
            int price = int.Parse(priceInput);

            Console.Write("Please enter the mortage duration in years: ");
            string yearsInput = Console.ReadLine();
            int years = int.Parse(yearsInput);

            Console.Write("Please enter the yearly interest rate in %: ");
            string interestPercentInput = Console.ReadLine();
            int interestPercent = int.Parse(interestPercentInput);

            double interestRate = 1 + (interestPercent / 100.0);

            double total = price * Math.Pow(interestRate, years);

            Console.WriteLine("Your total mortage amount will be: " + (int)total);
        }
    }
}
