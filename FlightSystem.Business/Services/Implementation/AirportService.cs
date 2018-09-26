using System.Collections.Generic;
using System.Configuration;
using FlightSystem.Data.Domain;
using FlightSystem.Data.Repository;
using FlightSystem.Business.Services.Interface;

namespace FlightSystem.Business.Services.Implementation
{
    public class AirportService : IAirportService
    {
        private readonly AirportRepository _airportRepository;

        public AirportService()
        {
            _airportRepository = new AirportRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public IEnumerable<Airport> GetAirportSelectList()
        {
            return _airportRepository.GetAirportSelectList();
        }
    }
}
