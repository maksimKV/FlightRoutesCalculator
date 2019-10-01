using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using FlightRoutesCalculator.Models;

namespace FlightRoutesCalculator.Controllers
{
    public class HomeController : Controller
    {
        private Utils.ApiIntegration api = new Utils.ApiIntegration();

        public ActionResult Index()
        {
            JObject allFlights = api.GetFlights();
            List<FlightRouteModel> inboundFlights = api.CastFlights(allFlights, false);
            List<FlightRouteModel> outboundFlights = api.CastFlights(allFlights, true);

            FlightRoutesViewModel model = new FlightRoutesViewModel(inboundFlights, outboundFlights);

            return View(model);
        }
    }
}