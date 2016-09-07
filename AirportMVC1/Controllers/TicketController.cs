using AirportMVC1.Models.entity;
using AirportMVC1.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportMVC1.Controllers
{
    public class TicketController : Controller
    {

        private TicketRepository Repository = new TicketRepository();
        public ActionResult All()
        {
            List<Ticket> pas;
            pas = Repository.AllTicketsToList();
            return View(pas);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Ticket p = Repository.GetById(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Update(Ticket p)
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
        public ActionResult Create(Ticket p)  //FormCollection collection
        {
            Repository.Add(p);
            return RedirectToAction("Index", "Flight"); //"AllFlights", "Flight"
        }
    }
}
