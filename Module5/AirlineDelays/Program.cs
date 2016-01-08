using System;
using System.Collections.Generic;
using System.IO;
using MoreLinq;

namespace Module5
{
    class Program
    {
        static List<Airline> readAndFilterDataFromFile(string origin, string destination)
        {
            StreamReader myFile = new StreamReader("airline-on-time-performance-sep2014-us.csv");

            bool first = true;
            string line = "";
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
                    // Add data to the matching airlines on route list.
                    airlinesOnRoute.Add(new Airline(parts[0], int.Parse(parts[4])));
                }
            }

            myFile.Close();
            return airlinesOnRoute;
        }

        static List<Airport> createAndProcessAirportList()
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

                Airport departureAirport = new Airport();
                Airport arrivalAirport = new Airport();
                departureAirport.AirportName = parts[1];
                arrivalAirport.AirportName = parts[2];

                // TODO Need to check if the object with the name exist, but the below does not work.
                if (!airports.Exists(a => a.AirportName == departureAirport.AirportName)) airports.Add(departureAirport);
                if (!airports.Exists(a => a.AirportName == arrivalAirport.AirportName)) airports.Add(arrivalAirport);

                airports.Find(x => x.AirportName == departureAirport.AirportName).totalDepartureDelay += int.Parse(parts[3]);
                airports.Find(x => x.AirportName == departureAirport.AirportName).departureFlightCount++;

                airports.Find(x => x.AirportName == arrivalAirport.AirportName).totalArrivalDelay += int.Parse(parts[4]);
                airports.Find(x => x.AirportName == arrivalAirport.AirportName).arrivalFlightCount++;

            }

            foreach (Airport item in airports)
            {
                item.calcAvgDepatureDelay();
                item.calcAvgArrivalDelay();
            }

            myFile.Close();
            return airports;
        }

        static void Main(string[] args)
        {

            string origin = "";
            string destination = "";
            int flightTotalForCurrentAirline = 0;
            int avgArrivalDelay = 0;
            int maxDelay = 0;
            int totalArrivalDelay = 0;
            string airlineCodeOfCurrent = "";
            List<Airline> airlinesOnRoute = new List<Airline>();

            Console.WriteLine("Please enter the origin airport:");
            origin = Console.ReadLine();
            Console.WriteLine("Please enter the destination airport:");
            destination = Console.ReadLine();

            airlinesOnRoute = readAndFilterDataFromFile(origin, destination);
            if (airlinesOnRoute.Count == 0) Console.WriteLine("There are no flights on this route.");

            Console.WriteLine("\nThere a total of {0} flights along this route.", airlinesOnRoute.Count);
            Console.WriteLine("Below is the break down of these flights according to airline.\n");

            foreach (Airline item in airlinesOnRoute)
            {
                //Get the first airline 
                if (airlineCodeOfCurrent == "") airlineCodeOfCurrent = item.airlineCode;

                //Get the max delay first time
                if (maxDelay == 0) maxDelay = item.arrivalDelay;

                totalArrivalDelay += item.arrivalDelay;
                if (item.arrivalDelay > maxDelay) maxDelay = item.arrivalDelay;
                flightTotalForCurrentAirline++;

                // If the index moves to the next airline or this was the last item in the list
                // report the data related to the previous one and clear variables
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

            List<Airport> readyAirportList = new List<Airport>();
            readyAirportList = createAndProcessAirportList();

            Airport worstAirportToFlyFrom = new Airport();
            Airport worstAirportToFlyTo = new Airport();

            worstAirportToFlyFrom = readyAirportList.MaxBy(a => a.avgDepartureDelay);
            worstAirportToFlyTo = readyAirportList.MaxBy(a => a.avgArrivalDelay);

            Console.WriteLine("The worst airport to fly from is {0} with an average departure delay of {1}.",
                worstAirportToFlyFrom.AirportName, worstAirportToFlyFrom.avgDepartureDelay);
            Console.WriteLine("The worst airport to fly to is {0} with an average arrival delay of {1}.",
                worstAirportToFlyTo.AirportName, worstAirportToFlyTo.avgArrivalDelay);
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
