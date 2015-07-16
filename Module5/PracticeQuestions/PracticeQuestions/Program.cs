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
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine(name.ToUpper());

            DateTime today = DateTime.Today;
            for (int i = 10; i > 0; --i)
            {
                Console.WriteLine("{0} years ago today the day of the week was {1}",
                    i, today.AddYears(-i).DayOfWeek);
            }
        }
    }
}
