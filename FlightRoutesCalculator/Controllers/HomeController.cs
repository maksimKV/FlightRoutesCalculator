using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}