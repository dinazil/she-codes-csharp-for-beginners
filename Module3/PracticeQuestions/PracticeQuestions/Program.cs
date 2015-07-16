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
            int value = -43;
            if (value >= 0)
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine(-value);
            }

            for (int i = 1; i <= 100; ++i)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i + " Buzz!");
                }
            }

            int power = 2;
            for (int i = 1; i <= 10; ++i)
            {
                Console.WriteLine(power);
                power = power * 2;
            }

            int sum = 0;
            for (int i = 1; i <= 100; ++i)
            {
                sum = sum + i;
            }
            Console.WriteLine(sum);
        }
    }
}
