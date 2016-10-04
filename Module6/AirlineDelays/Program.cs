using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirlineDelays
{
    class Program
    {
        const string AirlinePerformanceFileName = "airline-on-time-performance-sep2014-us.csv";

        // Prints average and maximum delays for each airline on a specific route
        static void PrintDelaysForEachAirline(string origin, string destination)
        {
            List<Airline> airlinesOnRoute = new List<Airline>();
            string[] lines = File.ReadAllLines(AirlinePerformanceFileName);
            
            for (int i = 1 /* We skip the first line */; i < lines.Length; ++i)
            {
                string line = lines[i];

                string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 7)
                    continue;

                if (parts[1] == origin && parts[2] == destination)
                {
                    // Add data to the list of matching airlines on route
                    airlinesOnRoute.Add(new Airline
                    {
                        AirlineCode = parts[0],
                        ArrivalDelay = int.Parse(parts[4])
                    });
                }
            }

            if (airlinesOnRoute.Count == 0)
            {
                Console.WriteLine("There are no flights on this route.");
                return;
            }

            Console.WriteLine("\nThere a total of {0} flights along this route.", airlinesOnRoute.Count);
            Console.WriteLine("Below is the break down of these flights according to airline:\n");

            string codeOfCurrentAirline = "";
            int maxDelay = int.MinValue;
            int totalArrivalDelay = 0;
            int totalFlightsOfCurrentAirline = 0;
            int avgArrivalDelay = 0;
            foreach (Airline airline in airlinesOnRoute)
            {
                //Get the first airline 
                if (codeOfCurrentAirline == "")
                    codeOfCurrentAirline = airline.AirlineCode;

                maxDelay = Math.Max(maxDelay, airline.ArrivalDelay);

                totalArrivalDelay += airline.ArrivalDelay;                    
                totalFlightsOfCurrentAirline++;

                // If the iterator moves to the next airline or this was the last item in the list
                // report the data related to the previous airline and clear variables
                if (codeOfCurrentAirline != airline.AirlineCode || airline.Equals(airlinesOnRoute[airlinesOnRoute.Count - 1]))
                {
                    if (totalFlightsOfCurrentAirline != 0) avgArrivalDelay = totalArrivalDelay / totalFlightsOfCurrentAirline;

                    Console.WriteLine(
                        "There were {0} flights between these airports for airline {1}.\n" +
                        "The average delay for this airline is {2} minutes.\n" +
                        "The maximum delay for this airline is {3} minutes.\n\n",
                        totalFlightsOfCurrentAirline, codeOfCurrentAirline, avgArrivalDelay, maxDelay);

                    totalArrivalDelay = 0;
                    totalFlightsOfCurrentAirline = 0;
                    maxDelay = 0;
                    codeOfCurrentAirline = airline.AirlineCode;
                }
            }
        }
        
        // Finds the worst airports to fly from and fly to
        static void FindWorstAirports()
        {
            List<Airport> airports = new List<Airport>();
            string[] lines = File.ReadAllLines(AirlinePerformanceFileName);
            for (int i = 1; i < lines.Length; ++i)
            {
                string line = lines[i];
                string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 7)
                    continue;

                // Create and fill up a unique airport list with airport objects
                // Set the total delay and flight count properties for each object
                Airport departureAirport = new Airport();
                Airport arrivalAirport = new Airport();
                departureAirport.AirportName = parts[1];
                arrivalAirport.AirportName = parts[2];

                if (!airports.Exists(a => a.AirportName == departureAirport.AirportName))
                    airports.Add(departureAirport);
                if (!airports.Exists(a => a.AirportName == arrivalAirport.AirportName))
                    airports.Add(arrivalAirport);

                airports.Find(x => x.AirportName == departureAirport.AirportName).TotalDepartureDelay += int.Parse(parts[3]);
                airports.Find(x => x.AirportName == departureAirport.AirportName).DepartureFlightCount++;

                airports.Find(x => x.AirportName == arrivalAirport.AirportName).TotalArrivalDelay += int.Parse(parts[4]);
                airports.Find(x => x.AirportName == arrivalAirport.AirportName).ArrivalFlightCount++;
            }

            List<Airport> worstAirportToFlyFrom = airports.OrderByDescending(a => a.AverageDepartureDelay).ToList();
            List<Airport> worstAirportToFlyTo = airports.OrderByDescending(a => a.AverageArrivalDelay).ToList();

            Console.WriteLine("The worst airport to fly from is {0} with an average departure delay of {1}.",
                worstAirportToFlyFrom.First().AirportName, worstAirportToFlyFrom.First().AverageDepartureDelay);
            Console.WriteLine("The worst airport to fly to is {0} with an average arrival delay of {1}.",
                worstAirportToFlyTo.First().AirportName, worstAirportToFlyTo.First().AverageArrivalDelay);
        }

        static void Main(string[] args)
        {
            Console.Write("Please enter the origin airport: ");
            string origin = Console.ReadLine();

            Console.Write("Please enter the destination airport: ");
            string destination = Console.ReadLine();

            PrintDelaysForEachAirline(origin, destination);

            FindWorstAirports();
        }
    }
}
