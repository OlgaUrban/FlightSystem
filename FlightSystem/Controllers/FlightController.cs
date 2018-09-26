using System.Web.Mvc;
using FlightSystem.Business.Query.Interface;
using FlightSystem.Business.Query.Interfaces;
using FlightSystem.Business.Services.Interface;
using FlightSystem.Web.Helpers;
using FlightSystem.Web.Models;

namespace FlightSystem.Web.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IFlightQuery _flightQuery;
        private readonly IAircraftQuery _aircraftService;
        private readonly IAirportQuery _airportService;

        public FlightController(IFlightService flightService,
            IFlightQuery flightQuery,
            IAircraftQuery aircraftService,
            IAirportQuery airportService)
        {
            _flightService = flightService;
            _flightQuery = flightQuery;
            _aircraftService = aircraftService;
            _airportService = airportService;
        }

        public ActionResult Index()
        {
            var model = _flightQuery.GetFlights().ToViewModel();

            return View(model);
        }

        public ActionResult Report()
        {
            var model = _flightQuery.GetReport().ToViewModel();

            return View(model);
        }

        //Get edit form
        public ActionResult Edit(int id)
        {
            var flight = _flightQuery.GetFlightById(id).ToViewModel();

            flight.AircraftSelectList = _aircraftService.GetAircraftSelectList().ToViewModel();
            flight.AirportSelectList = _airportService.GetAirportSelectList().ToViewModel();

            return View(flight);
        }

        // Get Create form
        public ActionResult Create()
        {
            var model = new FlightViewModel
            {
                AircraftSelectList = _aircraftService.GetAircraftSelectList().ToViewModel(),
                AirportSelectList = _airportService.GetAirportSelectList().ToViewModel()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrUpdate(FlightViewModel model)
        {
            var request = model.ToDomainModel();

            var result = (model.Id == 0)
                ? _flightService.CreateFlight(request)
                : _flightService.UpdateFlight(request);

            return result
                ? RedirectToAction("Index", "Flight")
                : RedirectToAction("Error", "Flight");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}