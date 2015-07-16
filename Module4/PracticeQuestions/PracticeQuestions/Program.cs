using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions
{
    class Program
    {
        static int ArraySum(int[] array)
        {
            int sum = 0;
            foreach (int i in array)
            {
                sum = sum + i;
            }
            return sum;
        }

        static int ArrayMin(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        static int ArrayMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        static int[] ArraySquare(int[] array)
        {
            int[] squares = new int[array.Length];
            for (int i = 0; i < array.Length; ++i)
            {
                squares[i] = array[i] * array[i];
            }
            return squares;
        }

        static void Main(string[] args)
        {
            int[] array = { 1, 48, 12, -9, 7, 13, 0, 4, 5, -4 };

            Console.WriteLine(ArraySum(array));
            Console.WriteLine(ArrayMin(array));
            Console.WriteLine(ArrayMax(array));

            foreach (var square in ArraySquare(array))
            {
                Console.WriteLine(square);
            }
        }
    }
}
