using System.Collections.Generic;
using FlightSystem.Data.Domain;

namespace FlightSystem.Business.Query.Interface
{
    public interface IAircraftQuery
    {
        IEnumerable<Aircraft> GetAircraftSelectList();
    }
}