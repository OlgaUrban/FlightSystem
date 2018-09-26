﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FlightSystem.Business.Models;
using FlightSystem.Data.Domain;
using FlightSystem.Web.Models;

namespace FlightSystem.Web.Helpers
{
    public static class Mapping
    {
        public static IEnumerable<FlightListViewModel> ToViewModel(this IEnumerable<Flight> model)
        {
            return model.Select(e => new FlightListViewModel
            {
                Id = e.Id,
                Aircraft = e.Aircraft.Name,
                DepartureAirport = e.DepartureAirport.Name,
                DepartureDate = e.DepartureDateTime,
                DestinationAirport = e.DestinationAirport.Name,
                DestinationDate = e.DestinationDateTime
            });
        }

        public static IEnumerable<ReportListViewModel> ToViewModel(this IEnumerable<FlightReport> model)
        {
            return model.Select(e => new ReportListViewModel
            {
                Aircraft = e.Aircraft,
                DepartureAirport = e.DepartureAirport,
                DepartureDate = e.DepartureDateTime,
                DestinationAirport = e.DestinationAirport,
                DestinationDate = e.DestinationDateTime,
                Fuel = e.Fuel,
                Distance = e.Distance
            });
        }

        public static IEnumerable<SelectListItem> ToViewModel(this IEnumerable<Aircraft> model)
        {
            return model.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
        }

        public static IEnumerable<SelectListItem> ToViewModel(this IEnumerable<Airport> model)
        {
            return model.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
        }

        public static FlightViewModel ToViewModel(this Flight model)
        {
            return new FlightViewModel
            {
                AircraftId = model.AircraftId,
                Departure = new AirportViewModel
                {
                    AirportId = model.DepartureAirportId,
                    DateTime = model.DepartureDateTime,
                },
                Destination = new AirportViewModel
                {
                    AirportId = model.DestinationAirportId,
                    DateTime = model.DestinationDateTime
                },
                Id = model.Id
            };
        }

        public static Flight ToDomainModel(this FlightViewModel model)
        {
            return new Flight
            {
                Id = model.Id,
                AircraftId = model.AircraftId,
                DepartureAirportId = model.Departure.AirportId,
                DestinationAirportId = model.Destination.AirportId,
                DepartureDateTime = model.Departure.DateTime,
                DestinationDateTime = model.Destination.DateTime
            };
        }
    }
}