using System;

namespace FlightSystem.Business.Models
{
    public class FlightReport
    {
        public string Aircraft { get; set; }

        public string DepartureAirport { get; set; }
        public DateTime? DepartureDateTime { get; set; }

        public string DestinationAirport { get; set; }
        public DateTime? DestinationDateTime { get; set; }

        public double Distance { get; set; }
        public double Fuel { get; set; }
    }
}
