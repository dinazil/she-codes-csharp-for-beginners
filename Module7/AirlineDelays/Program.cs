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

            var query1 = from flight in flights
                         where flight.Origin == "Boston MA"
                         where flight.Destination == "Chicago IL"
                         select flight.ArrivalDelay;

            var query2 = (from flight in flights
                          where flight.Destination == "Monterey CA"
                          select flight.Origin).Distinct();

            var query3 = (from flight in flights
                          orderby flight.ArrivalDelay descending
                          select new { flight.Origin, flight.Destination, flight.ArrivalDelay }
                          ).Take(10);

            var query4 = from flight in flights.Take(20)
                         select flight.Destination;

            var query5 = (from flight in flights
                          select flight.ArrivalDelay).Average();

            var query6 = (from flight in flights
                          orderby flight.Distance ascending
                          select new { flight.Origin, flight.Destination, flight.Distance }
                          ).Take(1);

            var query7 = (from flight in flights
                          where flight.Origin == "San Francisco CA"
                          orderby flight.Distance descending
                          select flight
                         ).Take(1);

            var query8 = (from flight in flights
                          where flight.Origin == "Boston MA"
                          let weightedDelay = flight.ArrivalDelay / (double)flight.Distance
                          orderby weightedDelay descending
                          select flight
                         ).Take(1);

            var query9 = (from flight in flights
                          where flight.Origin == "Seattle WA"
                          where flight.ArrivalDelay <= 0
                          select flight
                          ).Count();

            var query10 = (from flight in flights
                           group flight.DepartureDelay by flight.Origin into g
                           let averageDelay = g.Average()
                           orderby averageDelay descending
                           select new { Airport = g.Key, DepartureDelay = averageDelay }
                          ).Take(10);

            var query11 = (from flight in flights
                           where flight.Origin == "New York NY"
                           group flight.ArrivalDelay by flight.Airline into g
                           let averageDelay = g.Average()
                           orderby averageDelay descending
                           select new { Airline = g.Key, ArrivalDelay = averageDelay }
                          ).Take(1);

            var query12 = (from flight in flights
                           where flight.Airline == "AA"
                           group flight.DepartureDelay by flight.Origin into g
                           let averageDelay = g.Average()
                           orderby averageDelay descending
                           select new { Origin = g.Key, DepartureDelay = averageDelay }
                          ).Take(1);

            // Note: this query takes a long time to run. Either be patient, or make the file smaller
            // by removing some entries.
            var query13 = (from leg1 in flights
                           where leg1.Origin == "Boston MA"
                           from leg2 in flights
                           where leg2.Origin == leg1.Destination
                           where leg2.Destination == "Los Angeles CA"
                           let totalDelay = leg1.DepartureDelay + leg1.ArrivalDelay + leg2.DepartureDelay + leg2.ArrivalDelay
                           group totalDelay by new { O1 = leg1.Origin, O2 = leg1.Destination, D = leg2.Destination } into g
                           let averageTotalDelay = g.Average()
                           orderby averageTotalDelay ascending
                           select g.Key
                          ).Take(1);
        }
    }
}
