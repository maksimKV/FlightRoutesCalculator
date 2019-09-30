using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRoutesCalculator.Models
{
    public class FlightRoutesViewModel
    {
        public List<FlightRouteModel> InboundFlights { get; set; }
        public List<FlightRouteModel> OutboundFlights { get; set; }

        public FlightRoutesViewModel(List<FlightRouteModel> inboundFlights, List<FlightRouteModel> outboundFlights)
        {
            InboundFlights = inboundFlights.OrderBy(f => f.Price).ToList();
            OutboundFlights = outboundFlights.OrderBy(f => f.Price).ToList();
        }
    }
}