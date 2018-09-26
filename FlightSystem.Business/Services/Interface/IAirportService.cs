using System.Collections.Generic;
using FlightSystem.Data.Domain;

namespace FlightSystem.Business.Services.Interface
{
    public interface IAirportService
    {
        IEnumerable<Airport> GetAirportSelectList();
    }
}
