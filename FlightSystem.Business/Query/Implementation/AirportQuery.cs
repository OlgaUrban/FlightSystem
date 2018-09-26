using System.Collections.Generic;
using System.Configuration;
using FlightSystem.Business.Query.Interface;
using FlightSystem.Data.Domain;
using FlightSystem.Data.Repository;

namespace FlightSystem.Business.Query.Implementation
{
    public class AirportQuery : IAirportQuery
    {
        private readonly AirportRepository _airportRepository;

        public AirportQuery()
        {
            _airportRepository = new AirportRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public IEnumerable<Airport> GetAirportSelectList()
        {
            return _airportRepository.GetAirportSelectList();
        }
    }
}
