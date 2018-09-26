using System;

namespace FlightSystem.Web.Models
{
    public class FlightListViewModel
    {
        public int Id { get; set; }
        public string Aircraft { get; set; }
        public string DepartureAirport { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime? DestinationDate { get; set; }
    }
}