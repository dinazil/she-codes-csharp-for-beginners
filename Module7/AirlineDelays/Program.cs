using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDelays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FlightInfo> flights = FlightInfo.ReadFlightsFromFile(@"C:\Users\Sasha\Downloads\airline-on-time-performance-sep2014-us.csv");
            var query = (from flight in flights
                         where flight.Airline == "AA"
                         group flight.DepartureDelay by flight.Origin into g
                         select new { Airport = g.Key, DepartureDelay = g.Average() }
                         ).OrderByDescending(a => a.DepartureDelay).Take(1);

            if (query is IEnumerable)
            {
                foreach (var row in (IEnumerable)(object)query)
                {
                    Console.WriteLine(row);
                }
            }
            else
            {
                Console.WriteLine(query);
            }
        }
    }
}
