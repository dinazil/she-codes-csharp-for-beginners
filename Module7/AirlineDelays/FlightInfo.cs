using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDelays
{
    class FlightInfo
    {
        public string Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int DepartureDelay { get; set; }
        public int ArrivalDelay { get; set; }
        public bool Cancelled { get; set; }
        public int Distance { get; set; }

        public FlightInfo(string[] fields)
        {
            Airline = fields[0];
            Origin = fields[1];
            Destination = fields[2];
            DepartureDelay = int.Parse(fields[3]);
            ArrivalDelay = int.Parse(fields[4]);
            Cancelled = int.Parse(fields[5]) == 1;
            Distance = int.Parse(fields[6]);
        }

        public static List<FlightInfo> ReadFlightsFromFile(string fileName)
        {
            List<FlightInfo> flights = new List<FlightInfo>();
            bool first = true;
            using (var reader = new StreamReader(fileName))
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

                    flights.Add(new FlightInfo(parts));
                }
            }
            return flights;
        }
    }
}
