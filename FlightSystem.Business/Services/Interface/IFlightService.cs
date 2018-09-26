using FlightSystem.Data.Domain;

namespace FlightSystem.Business.Services.Interface
{
    public interface IFlightService
    {
        bool CreateFlight(Flight model);

        bool UpdateFlight(Flight model);
    }
}