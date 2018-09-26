using System.Collections.Generic;
using System.Configuration;
using FlightSystem.Business.Query.Interface;
using FlightSystem.Data.Domain;
using FlightSystem.Data.Repository;

namespace FlightSystem.Business.Query.Implementation
{
    public class AircraftQuery : IAircraftQuery
    {
        private readonly AircraftRepository _aircraftRepository;

        public AircraftQuery()
        {
            _aircraftRepository = new AircraftRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public IEnumerable<Aircraft> GetAircraftSelectList()
        {
            return _aircraftRepository.GetAircraftSelectList();
        }
    }
}
