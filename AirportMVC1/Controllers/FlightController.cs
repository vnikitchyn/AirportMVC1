using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportMVC1.Models.Repositories;
using AirportMVC1.Models.entity;


namespace AirportMVC1.Controllers
{
    public class FlightController : Controller
    {
        // GET: Flight
        public ActionResult Index()
        {
            List<IFlight> _flights;
            var flightRepo = new FlightRepository();
            _flights = flightRepo.GetFlights();
            if (_flights.Count == 0)
            {
                BuildDefaultFlights();          
                    }

            return View(_flights);
        }

        private List <IFlight> GetDefaultFlights()
        {
            return new List<IFlight>()
            {
                new FlightRepository {Id=1, Number="3342", CityFrom ="Kyiv", CityTo="Antalia" },
                new FlightRepository {Id=2, Number="3332", CityFrom ="Kyiv", CityTo="Stambul" }
            };
        }

        private void BuildDefaultFlights()
        {
            var flightRepo = new FlightRepository();
            var f1 = new FlightRepository { Id = 1, Number = "3342", CityFrom = "Kyiv", CityTo = "Antalia" };
            var f2 = new FlightRepository { Id = 2, Number = "3332", CityFrom = "Kyiv", CityTo = "Stambul" };

            flightRepo.AddFlight(f1);
            flightRepo.AddFlight(f2);
        }

    }
}