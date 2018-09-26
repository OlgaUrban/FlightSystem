using System;

namespace FlightSystem.Business.Helper
{
    public class Coordinates
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        //Calculate distance from base Coordinates to target Coordinates
        public double DistanceTo(Coordinates targetCoordinates)
        {
            var baseRad = Math.PI * Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            var theta = Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1.609344; //MilesFactor, convert to Kilometers
        }
    }
}
