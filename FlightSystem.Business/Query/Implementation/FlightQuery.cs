using System.Collections.Generic;
using System.Configuration;
using FlightSystem.Business.Helper;
using FlightSystem.Business.Models;
using FlightSystem.Business.Query.Interfaces;
using FlightSystem.Data.Domain;
using FlightSystem.Data.Repository;

namespace FlightSystem.Business.Query.Implementation
{
    public class FlightQuery : IFlightQuery
    {
        private readonly FlightRepository _flightRepository;

        public FlightQuery()
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

        public IEnumerable<FlightReport> GetReport()
        {
            var flights = _flightRepository.GetFlights();
            var report = new List<FlightReport>();

            foreach (var flight in flights)
            {
                //Calculate distance and fuel for each flight
                var distance = new Coordinates(flight.DepartureAirport.Latitude, flight.DepartureAirport.Longitude)
                    .DistanceTo(new Coordinates(flight.DestinationAirport.Latitude, flight.DestinationAirport.Longitude));

                report.Add(new FlightReport
                {
                    Aircraft = flight.Aircraft.Name,
                    DepartureAirport = flight.DepartureAirport.Name,
                    DepartureDateTime = flight.DepartureDateTime,
                    DestinationAirport = flight.DestinationAirport.Name,
                    DestinationDateTime = flight.DestinationDateTime,
                    Distance = distance,
                    Fuel = new Fuel(flight.Aircraft, distance)
                });
            }

            return report;
        }
    }
}
