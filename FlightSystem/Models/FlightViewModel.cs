using System.Collections.Generic;
using System.Web.Mvc;

namespace FlightSystem.Web.Models
{
    public class FlightViewModel
    {
        public IEnumerable<SelectListItem> AirportSelectList { get; set; }
        public IEnumerable<SelectListItem> AircraftSelectList { get; set; }

        public int Id { get; set; }
        public int AircraftId { get; set; }
        public AirportViewModel Departure { get; set; }
        public AirportViewModel Destination { get; set; }
    }
}