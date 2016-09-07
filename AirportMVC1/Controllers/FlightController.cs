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

        //[HttpPost]
        //public ActionResult Find(int number)
        //{
        //    List<Flight> _flights;
        //    _flights = Repository.FindByNumberWithPassengerAndTicket(number);
        //    return View(_flights);

        //}

        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Find( string numberS)
        {

            return RedirectToAction("ShowFlight", "Flight", new { numberS = Request.Form["number"] });

        }



        public ActionResult ShowFlight(string numberS)
        {
            int number;
            int.TryParse(numberS, out number);

            if (number == 0)
            {
                return View("Such number does not exist");
            }
            else
            {
                List <Flight> flights;
                flights = Repository.FindByNumberOnlyFlight(number);
                return View(flights);
            }
        }

        public ActionResult Show(string numberS)
        {
            int number;
            int.TryParse(numberS, out number);

            if (number == 0)
            {
                return View("Such number does not exist");
            }
            else
            {
                Ticket ticket;
                ticket = Repository.FindByNumberWithPassengerAndTicket2(number);
                return View(ticket);
            }
        }


        [HttpGet]
        public ActionResult FindFull()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindFull(string numberS)
        {

            return RedirectToAction("Show", "Flight", new { numberS = Request.Form["number"] });

        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Flight flight)  //FormCollection collection
        {
            Repository.Add(flight);
            return RedirectToAction("Index", "Flight"); //"AllFlights", "Flight"
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


        public ActionResult Index()
        {
            List<Flight> _flights;
            _flights = Repository.Get();
            return View(_flights);
        }


    }
}