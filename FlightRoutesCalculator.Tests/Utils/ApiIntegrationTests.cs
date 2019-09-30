using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using FlightRoutesCalculator.Models;

namespace FlightRoutesCalculator.Tests.Utils
{
    [TestClass]
    public class ApiIntegrationTests
    {
        private FlightRoutesCalculator.Utils.ApiIntegration api = new FlightRoutesCalculator.Utils.ApiIntegration();

        /// <summary>
        /// Test flights response from API.
        ///</summary>
        [TestMethod]
        public void TestGetFlights()
        {
            JObject flights = api.GetFlights();

            Assert.IsNotNull(flights);
            Assert.IsInstanceOfType(flights, typeof(JObject));
        }

        /// <summary>
        /// Test flights json object casting to list of FlightRouteModel objects.
        ///</summary>
        [TestMethod]
        public void TestCastFlights()
        {
            JObject flights = api.GetFlights();

            List<FlightRouteModel> inboundFlights = api.CastFlights(flights, false);

            Assert.IsNotNull(inboundFlights);
            Assert.IsInstanceOfType(inboundFlights, typeof(List<FlightRouteModel>));

            List<FlightRouteModel> outboundFlights = api.CastFlights(flights, true);

            Assert.IsNotNull(outboundFlights);
            Assert.IsInstanceOfType(outboundFlights, typeof(List<FlightRouteModel>));
        }
    }
}
