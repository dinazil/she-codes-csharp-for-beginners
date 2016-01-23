using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirlineDelays
{
    class Program
    {

        // Prints average and maximum delays for each airline on a specific route
        static void PrintDelaysForEachAirline(string origin, string destination)
        {
            StreamReader myFile = new StreamReader("airline-on-time-performance-sep2014-us.csv");

            bool first = true;
            string line = "";

            string airlineCodeOfCurrent = "";
            int maxDelay = 0;
            int totalArrivalDelay = 0;
            int flightTotalForCurrentAirline = 0;
            int avgArrivalDelay = 0;

            List<Airline> airlinesOnRoute = new List<Airline>();

            while ((line = myFile.ReadLine()) != null)
            {
                if (first)
                {
                    first = false;
                    continue;
                }

                string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 7) continue;
                if (parts[1] == origin && parts[2] == destination)
                {
                    // Add data to the list of matching airlines on route 
                    airlinesOnRoute.Add(new Airline(parts[0], int.Parse(parts[4])));
                }
            }
            myFile.Close();


            if (airlinesOnRoute.Count == 0)
            {
                Console.WriteLine("There are no flights on this route.");
                return;
            }

                Console.WriteLine("\nThere a total of {0} flights along this route.", airlinesOnRoute.Count);
                Console.WriteLine("Below is the break down of these flights according to airline:\n");

                foreach (Airline item in airlinesOnRoute)
                {
                    //Get the first airline 
                    if (airlineCodeOfCurrent == "") airlineCodeOfCurrent = item.airlineCode;

                    //Get the max delay first time
                    if (maxDelay == 0) maxDelay = item.arrivalDelay;
                    if (item.arrivalDelay > maxDelay) maxDelay = item.arrivalDelay;

                    totalArrivalDelay += item.arrivalDelay;                    
                    flightTotalForCurrentAirline++;

                    // If the iterator moves to the next airline or this was the last item in the list
                    // report the data related to the previous airline and clear variables
                    if (airlineCodeOfCurrent != item.airlineCode || item.Equals(airlinesOnRoute[airlinesOnRoute.Count - 1]))
                    {
                        if (flightTotalForCurrentAirline != 0) avgArrivalDelay = totalArrivalDelay / flightTotalForCurrentAirline;

                        Console.WriteLine("There were {0} flights between these airports for airline {1}. \n The average delay for this airline is {2} minutes. \n The maximum delay for this airline is {3} minutes. \n\n"
                            , flightTotalForCurrentAirline, airlineCodeOfCurrent, avgArrivalDelay, maxDelay);

                        totalArrivalDelay = 0;
                        flightTotalForCurrentAirline = 0;
                        maxDelay = 0;
                        airlineCodeOfCurrent = item.airlineCode;
                }
                }
                    
        }

        
        // Finds the worst airports to fly from and fly to
        static void FindWorstAirports()
        {
            StreamReader myFile = new StreamReader("airline-on-time-performance-sep2014-us.csv");

            bool first = true;
            string line = "";
            List<Airport> airports = new List<Airport>();

            while ((line = myFile.ReadLine()) != null)
            {
                if (first)
                {
                    first = false;
                    continue;
                }

                string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 7) continue;

                // Create and fill up a unique airport list with airport objects
                // Set the total delay and flight count properties for each object
                Airport departureAirport = new Airport();
                Airport arrivalAirport = new Airport();
                departureAirport.AirportName = parts[1];
                arrivalAirport.AirportName = parts[2];
                                
                if (!airports.Exists(a => a.AirportName == departureAirport.AirportName)) airports.Add(departureAirport);
                if (!airports.Exists(a => a.AirportName == arrivalAirport.AirportName)) airports.Add(arrivalAirport);

                airports.Find(x => x.AirportName == departureAirport.AirportName).totalDepartureDelay += int.Parse(parts[3]);
                airports.Find(x => x.AirportName == departureAirport.AirportName).departureFlightCount++;

                airports.Find(x => x.AirportName == arrivalAirport.AirportName).totalArrivalDelay += int.Parse(parts[4]);
                airports.Find(x => x.AirportName == arrivalAirport.AirportName).arrivalFlightCount++;

            }

            myFile.Close();

            foreach (Airport item in airports)
            {
                item.calcAvgDepatureDelay();
                item.calcAvgArrivalDelay();
            }

            List<Airport> worstAirportToFlyFrom = airports.OrderByDescending(a => a.avgDepartureDelay).ToList();
            List<Airport> worstAirportToFlyTo = airports.OrderByDescending(a => a.avgArrivalDelay).ToList();


            Console.WriteLine("The worst airport to fly from is {0} with an average departure delay of {1}.",
                worstAirportToFlyFrom.First().AirportName, worstAirportToFlyFrom.First().avgDepartureDelay);
            Console.WriteLine("The worst airport to fly to is {0} with an average arrival delay of {1}.",
                worstAirportToFlyTo.First().AirportName, worstAirportToFlyTo.First().avgArrivalDelay);

        }


        static void Main(string[] args)
        {
            string origin = "";
            string destination = "";                      

            Console.WriteLine("Please enter the origin airport:");
            origin = Console.ReadLine();
            Console.WriteLine("Please enter the destination airport:");
            destination = Console.ReadLine();

            PrintDelaysForEachAirline(origin, destination);

            FindWorstAirports();
        }
               
        class Airline
        {
            public string airlineCode { get; set; }
            public int arrivalDelay { get; set; }

            public Airline(string airlineCode, int arrivalDelay)
            {
                this.airlineCode = airlineCode;
                this.arrivalDelay = arrivalDelay;
            }

        }

        class Airport
        {
            public string AirportName { get; set; }
            public int totalArrivalDelay { get; set; }
            public int totalDepartureDelay { get; set; }
            public int arrivalFlightCount { get; set; }
            public int departureFlightCount { get; set; }
            public int avgDepartureDelay { get; set; }
            public int avgArrivalDelay { get; set; }

            public void calcAvgDepatureDelay()
            {
                if (departureFlightCount != 0) this.avgDepartureDelay = totalDepartureDelay / departureFlightCount;
            }

            public void calcAvgArrivalDelay()
            {
                if (arrivalFlightCount != 0) this.avgArrivalDelay = totalArrivalDelay / arrivalFlightCount;
            }
        }

    }
}
