using FlightSystem.Data.Domain;

namespace FlightSystem.Business.Models
{
    public class Fuel
    {
        private readonly double _distance;
        private readonly double _fuelConsumption;
        private readonly double _takeoffEffort;

        public Fuel(Aircraft aircraft, double distance)
        {
            _distance = distance;
            _fuelConsumption = aircraft.FuelConsumption;
            _takeoffEffort = aircraft.TakeoffEffort;
        }

        public double Value => _fuelConsumption * _distance + _takeoffEffort;
    }
}
