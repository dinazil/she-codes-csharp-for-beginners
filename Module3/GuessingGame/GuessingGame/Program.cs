using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = new Random().Next(1, 10);

            for (int i = 0; i < 5; ++i)
            {
                Console.Write("Enter your guess: ");
                int guess = int.Parse(Console.ReadLine());

                if (guess == number)
                {
                    Console.WriteLine("You won! Way to go!");
                    break;
                }
                else
                {
                    if (guess > number)
                    {
                        Console.WriteLine("Your guess is too high. Try again.");
                    }
                    if (guess < number)
                    {
                        Console.WriteLine("Your guess is too low. Try again.");
                    }
                }
            }
        }
    }
}
