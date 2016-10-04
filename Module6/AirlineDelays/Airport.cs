namespace AirlineDelays
{
    class Airport
    {
        public string AirportName { get; set; }
        public int TotalArrivalDelay { get; set; }
        public int TotalDepartureDelay { get; set; }
        public int ArrivalFlightCount { get; set; }
        public int DepartureFlightCount { get; set; }

        public int AverageDepartureDelay
        {
            get
            {
                return TotalDepartureDelay / DepartureFlightCount;
            }
        }
        public int AverageArrivalDelay
        {
            get
            {
                return TotalArrivalDelay / ArrivalFlightCount;
            }
        }
    }
}
