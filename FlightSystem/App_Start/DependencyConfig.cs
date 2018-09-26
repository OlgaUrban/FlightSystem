using FlightSystem.Business.Services.Implementation;
using FlightSystem.Business.Services.Interface;
using Ninject.Modules;

namespace FlightSystem.Web
{
    public class DependencyConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IAircraftService>().To<AircraftService>();
            Bind<IAirportService>().To<AirportService>();
            Bind<IFlightService>().To<FlightService>();
        }
    }
}