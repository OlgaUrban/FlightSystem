using System.Collections.Generic;
using FlightSystem.Business.Models;
using FlightSystem.Data.Domain;

namespace FlightSystem.Business.Query.Interfaces
{
    public interface IFlightQuery
    {
        IEnumerable<Flight> GetFlights();

        Flight GetFlightById(int id);

        IEnumerable<FlightReport> GetReport();
    }
}
