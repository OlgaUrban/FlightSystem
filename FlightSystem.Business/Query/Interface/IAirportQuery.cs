using System.Collections.Generic;
using FlightSystem.Data.Domain;

namespace FlightSystem.Business.Query.Interface
{
    public interface IAirportQuery
    {
        IEnumerable<Airport> GetAirports();
    }
}
