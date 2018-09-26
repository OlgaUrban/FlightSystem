using System;

namespace FlightSystem.Web.Models
{
    public class ReportListViewModel
    {
        public string Aircraft { get; set; }
        public string DepartureAirport { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime? DestinationDate { get; set; }

        public double Distance { get; set; }
        public double Fuel { get; set; }
    }
}