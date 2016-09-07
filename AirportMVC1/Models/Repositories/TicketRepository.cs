using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirportMVC1.Models;
using AirportMVC1.Models.entity;
using AirportMVC1.Models.Interfaces;
using static AirportMVC1.Models.Repositories.FlightRepository;

namespace AirportMVC1.Models.Repositories 
{
    public class TicketRepository : ITicket
    {

        public static List<Ticket> TicketsList { get; set; }
        AirportContext _db;

        public TicketRepository(){
            _db = new AirportContext();
            }



        internal  List<Flight> AllFlightsToList()
        {
            using (var db = new AirportContext())
            {
                return db.Flights.ToList();
            }

        }
        internal  List<Passenger> AllPassengersToList()
        {
            using (var db = new AirportContext())
            {
                return db.Passengers.ToList();
            }

        }

        internal  List<Ticket> AllTicketsToList()
        {
            using (var db = new AirportContext())
            {
                return db.Tickets.ToList();
            }

        }

        internal  void AddTickets(List<Ticket> tickets)
        {
            using (var db = new AirportContext())
            {
                foreach (Ticket ticket in tickets)
                {
                    if (ticket.Flight.FlightId > 0)
                        ticket.Flight = null;
                    if (ticket.Passenger.PassId > 0)
                        ticket.Passenger = null;
                }
                db.Tickets.AddRange(tickets);
                db.SaveChanges();
            }
        }


        internal  void AddTicket(Ticket ticket) // worked method!
        {
            using (var db = new AirportContext())
            {
                if (ticket.Flight.FlightId > 0)
                {
                    ticket.FlightId = ticket.Flight.FlightId;
                    ticket.Flight = null;
                }
                if (ticket.Passenger.PassId > 0)
                {
                    ticket.PassId = ticket.Passenger.PassId;
                    ticket.Passenger = null;
                }
                db.Tickets.Add(ticket);
                db.SaveChanges();
            }
        }


        internal  void AddTicket(Ticket ticket, int flightNumber) // worked method!
        {
            using (var db = new AirportContext())
            {
                int flId = FindFlightID(flightNumber);
                if (flId > 0)
                {
                    ticket.Flight = null;
                    ticket.FlightId = flId;
                }
                if (ticket.Passenger.PassId > 0)
                {
                    ticket.PassId = ticket.Passenger.PassId;
                    ticket.Passenger = null;
                }
                db.Tickets.Add(ticket);
                //db.Flights.Attach(flight);
                //ticket.Flight = flight;
                db.SaveChanges();
            }
        }


        internal  void PriceMore(double price) //IComparer for sorting
        {
            bool find = false;
            PriceCompare<Ticket> pCompare = new PriceCompare<Ticket>();
            TicketsList.Sort(pCompare);
            foreach (Ticket ticket in TicketsList)
            {
                if (ticket.Price > price)
                    Console.WriteLine(ticket.ToString());
                find = true;
            }
            if (find == false)
            {
                throw new Exception ("Such flight is not found");
            }
            else
            {
                
            }
        }

        internal  void PriceLess(double price) //IComparable for sorting
        {
            bool find = false;
            TicketsList.Sort();
            foreach (Ticket ticket in TicketsList)
            {
                if (ticket.Price < price)
                    Console.WriteLine(ticket.ToString());
                find = true;
            }
            if (find == false)
            {
                throw new Exception("Such flight is not found");
            }
            else
            {
            }
        }

        public Ticket GetById(int id)
        {
            var res = _db.Tickets.FirstOrDefault(n => n.PassId == id);
            return res;
        }

        public void Delete(int id)
        {
            var t = GetById(id);
            _db.Tickets.Remove(t);
            _db.SaveChanges();
        }

        public void Add(Ticket t)
        {
            _db.Tickets.Add(t);
            _db.SaveChanges();

        }

        public void Update(Ticket t)
        {
            var _t = _db.Tickets.Find(t.PassId);
            if (_t != null)
            {
                _db.Entry(_t).CurrentValues.SetValues(t);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Current entity does not exists");
            }
        }


    }


    class PriceCompare<T> : IComparer<T> //IComparer
        where T : Ticket
    {
        public int Compare(T x, T y)
        {
            if (x.Price < y.Price)
                return -1;
            if (x.Price > y.Price)
                return 1;
            else return 0;
        }
    }

   


}
