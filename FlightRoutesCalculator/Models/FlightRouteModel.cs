using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRoutesCalculator.Models
{
    public class FlightRouteModel
    {
        public string ID { get; set; }
        public string Airline { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public int Price { get; set; }

        public FlightRouteModel(string id, string airline, string departureCode, string arrivalCode, int price) 
        {
            ID = id;
            Airline = airline;
            DepartureAirportCode = departureCode;
            ArrivalAirportCode = arrivalCode;
            Price = price;
        }
    }
}