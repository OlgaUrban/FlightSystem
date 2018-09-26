using FlightSystem.Data.Repository;
using FlightSystem.Data.Domain;
using System.Configuration;
using FlightSystem.Business.Services.Interface;

namespace FlightSystem.Business.Services.Implementation
{
    public class FlightService : IFlightService
    {
        private readonly FlightRepository _flightRepository;

        public FlightService()
        {
            _flightRepository = new FlightRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public bool CreateFlight(Flight model)
        {
            return _flightRepository.CreateFlight(model);
        }

        public bool UpdateFlight(Flight model)
        {
            return _flightRepository.UpdateFlight(model);
        }
    }
}
