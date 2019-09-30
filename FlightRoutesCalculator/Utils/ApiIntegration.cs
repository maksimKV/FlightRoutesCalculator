using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FlightRoutesCalculator.Models;

namespace FlightRoutesCalculator.Utils
{
    public class ApiIntegration : IApiIntegration
    {
        /// <inheritdoc/>
        public JObject GetFlights()
        {
            using (var client = new HttpClient())
            {
                // Working query: http://www.mocky.io/v2/5ce66fb8330000660073156e

                string baseAddress = "http://www.mocky.io/v2/5ce66fb8330000660073156e";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(baseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    string cleanResult = result.Replace("=", ":"); // Replacing equals signs as the string can't be serealised like this.
                    return JsonConvert.DeserializeObject<JObject>(cleanResult);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <inheritdoc/>
        public List<FlightRouteModel> CastFlights(JObject flights, bool outboundDirection)
        {
            List<FlightRouteModel> flightsList = new List<FlightRouteModel>();

            // Getting an array of the flights based on their direction.
            JArray flightsArray = flights["inboundFlights"] as JArray;
            if (outboundDirection)
            {
                flightsArray = flights["outboundFlights"] as JArray;
            }
            
            foreach (JObject flight in flightsArray)
            {
                flightsList.Add(
                    new FlightRouteModel(flight["id"].ToString(), flight["airline"].ToString(), flight["departureAirportCode"].ToString(),
                                             flight["arrivalAirportCode"].ToString(), Convert.ToInt32(flight["price"].ToString())));
            }

            return flightsList;
        }
    }
}