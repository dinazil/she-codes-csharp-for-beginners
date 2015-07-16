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
            string input = Console.ReadLine();
            Console.WriteLine("**** " + input + " ****");

            input = Console.ReadLine();
            int number = int.Parse(input);
            Console.WriteLine(number * number);
        }
    }
}
