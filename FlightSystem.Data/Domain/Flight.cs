using System;

namespace FlightSystem.Data.Domain
{
    public class Flight
    {
        public int Id { get; set; }
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }

        public int DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; set; }
        public DateTime DepartureDateTime { get; set; }

        public int DestinationAirportId { get; set; }
        public Airport DestinationAirport { get; set; }
        public DateTime DestinationDateTime { get; set; }
    }
}
