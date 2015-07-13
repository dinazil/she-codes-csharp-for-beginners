using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDelays
{
    class Program
    {
        static void PrintAverageDelay(string origin, string destination)
        {
            bool first = true;
            int count = 0;
            int sumDelays = 0;
            using (var reader = new StreamReader(@"airline-on-time-performance-sep2014-us.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (first)
                    {
                        first = false;
                        continue;
                    }

                    string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 7)
                        continue;

                    if (parts[1] == origin && parts[2] == destination)
                    {
                        ++count;
                        sumDelays += int.Parse(parts[4]);
                    }
                }
            }
            Console.WriteLine("{0} flights, average delay {1} minutes", count, sumDelays / count);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter origin airport: ");
            string origin = Console.ReadLine();

            Console.Write("Enter destination airport: ");
            string destination = Console.ReadLine();

            PrintAverageDelay(origin, destination);
        }
    }
}
