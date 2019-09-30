using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using FlightRoutesCalculator.Models;

namespace FlightRoutesCalculator.Utils
{
    interface IApiIntegration
    {
        /// <summary>
        /// Gets all flights from the api.
        /// </summary>
        /// <returns> A JSON object with api response.</returns>
        JObject GetFlights();

        /// <summary>
        /// Casts flights into a list of FlightRouteModel objects.
        /// </summary>
        /// <param name="flights">A JSON object with api response.</param>
        /// <param name="outboundDirection">A boolean required to figure out the direction of the flights i.e. Outbound or Inbound.</param>
        /// <returns> List with FlightRouteModel objects.</returns>
        List<FlightRouteModel> CastFlights(JObject flights, bool outboundDirection);
    }
}