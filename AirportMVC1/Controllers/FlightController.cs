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
        public ActionResult Find(int number)
        {
            if (number == null)
            {
                return View("Error");
            }
            else
            {
                List<Flight> _flights;
                _flights = Repository.FindByNumberWithPassengerAndTicket(number);
                return View(_flights);
            }
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
            return View(_flights);
        }


    }
}