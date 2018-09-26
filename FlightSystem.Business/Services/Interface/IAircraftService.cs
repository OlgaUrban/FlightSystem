using System.Collections.Generic;
using FlightSystem.Data.Domain;

namespace FlightSystem.Business.Services.Interface
{
    public interface IAircraftService
    {
        IEnumerable<Aircraft> GetAircraftSelectList();
    }
}