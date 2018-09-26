using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FlightSystem.Business.Models;
using FlightSystem.Business.Services.Interface;
using FlightSystem.Data.Domain;
using FlightSystem.Web.Controllers;
using FlightSystem.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlightSystem.Test
{
    [TestClass]
    public class FlightControllerTest
    {
        private readonly Mock<IAircraftService> _aircraftServiceMock = new Mock<IAircraftService>();
        private readonly Mock<IAirportService> _airportServiceMock = new Mock<IAirportService>();
        private readonly Mock<IFlightService> _flightServiceMock = new Mock<IFlightService>();

        private readonly FlightController _controller;

        public FlightControllerTest()
        {

            _aircraftServiceMock.Setup(a => a.GetAircraftSelectList()).Returns(new List<Aircraft>());
            _airportServiceMock.Setup(a => a.GetAirportSelectList()).Returns(new List<Airport>());
            _flightServiceMock.Setup(a => a.GetFlights()).Returns(new List<Flight>());
            _flightServiceMock.Setup(a => a.GetReport()).Returns(new List<FlightReport>());
            _flightServiceMock.Setup(a => a.CreateFlight(It.IsAny<Flight>())).Returns(new bool());
            _flightServiceMock.Setup(a => a.GetFlightById(It.IsAny<int>())).Returns(new Flight());

            _controller = new FlightController(
                _flightServiceMock.Object, 
                _aircraftServiceMock.Object,
                _airportServiceMock.Object);
        }

        [TestMethod]
        public void Verify_GetFlights_From_FlightService()
        {
            var result = _controller.Index();

            Assert.IsNotNull(result);
            var resultView = result as ViewResult;
            Assert.IsNotNull(resultView);
            Assert.IsNotNull(resultView.Model);
            _flightServiceMock.Verify(e => e.GetFlights());
        }

        [TestMethod]
        public void Verify_GetReport_From_FlightService()
        {
            var result = _controller.Report();

            Assert.IsNotNull(result);
            var resultView = result as ViewResult;
            Assert.IsNotNull(resultView);
            Assert.IsNotNull(resultView.Model);
            _flightServiceMock.Verify(e => e.GetReport());
        }

        [TestMethod]
        public void Verify_GetFlightById_From_FlightService()
        {
            var result = _controller.Edit(It.IsAny<int>());

            Assert.IsNotNull(result);
            var resultView = result as ViewResult;
            Assert.IsNotNull(resultView);
            Assert.IsNotNull(resultView.Model);
            _flightServiceMock.Verify(e => e.GetFlightById(It.IsAny<int>()));
        }

        [TestMethod]
        public void Verify_CreateFlight_From_FlightService()
        {
            var model = new FlightViewModel
            {
                Id = 0,
                AircraftId = 1,
                Departure = new AirportViewModel
                {
                    AirportId = 1,
                    DateTime = DateTime.Now
                },
                Destination = new AirportViewModel
                {
                    AirportId = 2,
                    DateTime = DateTime.Now
                }
            };

            var result = _controller.CreateOrUpdate(model);

            Assert.IsNotNull(result);
            _flightServiceMock.Verify(e => e.CreateFlight(It.IsAny<Flight>()));
        }

        [TestMethod]
        public void Verify_UpdateFlight_From_FlightService()
        {
            var model = new FlightViewModel
            {
                Id = 2,
                AircraftId = 1,
                Departure = new AirportViewModel
                {
                    AirportId = 1,
                    DateTime = DateTime.Now
                },
                Destination = new AirportViewModel
                {
                    AirportId = 2,
                    DateTime = DateTime.Now
                }
            };

            var result = _controller.CreateOrUpdate(model);

            Assert.IsNotNull(result);
            _flightServiceMock.Verify(e => e.UpdateFlight(It.IsAny<Flight>()));
        }
    }
}
