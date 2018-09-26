using FlightSystem.Data.Repository;
using System.Collections.Generic;
using FlightSystem.Data.Domain;
using System.Configuration;
using FlightSystem.Business.Helper;
using FlightSystem.Business.Models;
using FlightSystem.Business.Services.Interface;

namespace FlightSystem.Business.Services.Implementation
{
    public class FlightService : IFlightService
    {
        private readonly FlightRepository _flightRepository;

        public FlightService()
        {
            _flightRepository = new FlightRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _flightRepository.GetFlights();
        }

        public Flight GetFlightById(int id)
        {
            return _flightRepository.GetFlightById(id);
        }

        public bool CreateFlight(Flight model)
        {
            return _flightRepository.CreateFlight(model);
        }

        public bool UpdateFlight(Flight model)
        {
            return _flightRepository.UpdateFlight(model);
        }

        public IEnumerable<FlightReport> GetReport()
        {
            var flights = _flightRepository.GetFlights();
            var report = new List<FlightReport>();

            foreach (var flight in flights)
            {
                //Calculate distance and fuel for each flight
                var distance = new Coordinates(flight.DepartureAirport.Latitude, flight.DepartureAirport.Longitude)
                    .DistanceTo(new Coordinates(flight.DestinationAirport.Latitude, flight.DestinationAirport.Longitude));

                var fuel = flight.Aircraft.FuelConsumption * distance + flight.Aircraft.TakeoffEffort;

                report.Add(new FlightReport
                {
                    Aircraft = flight.Aircraft.Name,
                    DepartureAirport = flight.DepartureAirport.Name,
                    DepartureDateTime = flight.DepartureDateTime,
                    DestinationAirport = flight.DestinationAirport.Name,
                    DestinationDateTime = flight.DestinationDateTime,
                    Distance = distance,
                    Fuel = fuel
                });
            }

            return report;
        }
    }
}
