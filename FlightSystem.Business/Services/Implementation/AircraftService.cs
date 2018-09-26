using System.Collections.Generic;
using System.Configuration;
using FlightSystem.Business.Services.Interface;
using FlightSystem.Data.Domain;
using FlightSystem.Data.Repository;

namespace FlightSystem.Business.Services.Implementation
{
    public class AircraftService : IAircraftService
    {
        private readonly AircraftRepository _aircraftRepository;

        public AircraftService()
        {
            _aircraftRepository = new AircraftRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public IEnumerable<Aircraft> GetAircraftSelectList()
        {
            return _aircraftRepository.GetAircraftSelectList();
        }
    }
}
