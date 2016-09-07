using AirportMVC1.Models.entity;
using AirportMVC1.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportMVC1.Controllers
{
    public class PassengerController : Controller
    {
        // GET: Passenger
        private PassengerRepository Repository = new PassengerRepository();


        public ActionResult All()
        {
            List<Passenger> pas;
            pas = Repository.AllPassengersToList();
            return View(pas);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Passenger p = Repository.GetById(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Update(Passenger p)
        {
            Repository.Update(p);
            return RedirectToAction("Index", "Flight");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index", "Flight");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Passenger p)  //FormCollection collection
        {
            Repository.Add(p);
            return RedirectToAction("Index", "Flight"); //"AllFlights", "Flight"
        }


    }
}
