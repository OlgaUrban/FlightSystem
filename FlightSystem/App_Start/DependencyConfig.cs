using FlightSystem.Business.Query.Implementation;
using FlightSystem.Business.Query.Interface;
using FlightSystem.Business.Query.Interfaces;
using FlightSystem.Business.Services.Implementation;
using FlightSystem.Business.Services.Interface;
using Ninject.Modules;

namespace FlightSystem.Web
{
    public class DependencyConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IAircraftQuery>().To<AircraftQuery>();
            Bind<IAirportQuery>().To<AirportQuery>();
            Bind<IFlightService>().To<FlightService>();
            Bind<IFlightQuery>().To<FlightQuery>();
        }
    }
}