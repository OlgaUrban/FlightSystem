using System.Collections.Generic;
using FlightSystem.Business.Models;
using FlightSystem.Data.Domain;

namespace FlightSystem.Business.Services.Interface
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFlights();

        Flight GetFlightById(int id);

        bool CreateFlight(Flight model);

        bool UpdateFlight(Flight model);

        IEnumerable<FlightReport> GetReport();
    }
}