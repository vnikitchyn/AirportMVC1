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
        private FlightRepository Repository = new FlightRepository();
        // GET: Flight
        public ActionResult AllFlights()
        {
            List<Flight> _flights;
            _flights = Repository.GetFlightsAll();
            return View(_flights);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Flight _flight = Repository.GetFlightById(id);
            return View(_flight);
        }

        [HttpPost]
        public ActionResult Update (Flight flight)
        {
            Repository.Update(flight);
            return RedirectToAction("Index","Flight");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index", "Flight");
        }


        [HttpPost]
        public ActionResult Create(Flight flight)  //FormCollection collection
        {
            Repository.Add(flight);
            return RedirectToAction("AllFlights","Flight");
        }

        public ActionResult Index()
        {
            List<Flight> _flights;
            _flights = Repository.Get();
            if (_flights.Count == 0)
            {
                BuildDefaultFlights();          
                    }

            return View(_flights);
        }

        private List <Flight> GetDefaultFlights()
        {
            return new List<Flight>()
            {
                new Flight {Id=1, Number="3342", CityFrom ="Kyiv", CityTo="Antalia" },
                new Flight {Id=2, Number="3332", CityFrom ="Kyiv", CityTo="Stambul" }
            };
        }

        private void BuildDefaultFlights()
        {
            var flightRepo = new FlightRepository();
            var f1 = new Flight {  Number = "3342", CityFrom = "Kyiv", CityTo = "Antalia" };
            var f2 = new Flight {  Number = "3332", CityFrom = "Kyiv", CityTo = "Stambul" };

            flightRepo.Add(f1);
            flightRepo.Add(f2);
        }

    }
}