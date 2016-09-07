using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirportMVC1.Models.entity;
using AirportMVC1.Models.Interfaces;
using System.Collections;

namespace AirportMVC1.Models.Repositories
{
    public class PassengerRepository : IPassenger
    {
        internal static List<Passenger> passList = new List<Passenger>();

        AirportContext _db;

        public PassengerRepository()
        {
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


        internal  IEnumerable FindSQLPassengerOnly(string passport)
        {
            IEnumerable<Passenger> filtered =
              from passenger in AllPassengersToList()
              where passenger.Passport.Equals(passport)
              select passenger;
            return filtered;
        }

        internal  IEnumerable FindSQLPassengerOnly(string name, string surname)
        {
            IEnumerable<Passenger> filtered =
              from passenger in AllPassengersToList()
              where passenger.Name.Equals(name) && passenger.Surname.Equals(surname)
              select passenger;
            return filtered;
        }

        public Passenger GetById(int id)
        {
            var res = _db.Passengers.FirstOrDefault(n => n.PassId == id);                
            return res;
        }

        public void Delete(int id)
        {
            var p = GetById (id);
            _db.Passengers.Remove(p);
            _db.SaveChanges();
        }

        public void Update(Passenger p)
        {
            var _p = _db.Passengers.Find(p.PassId);
            if (_p != null)
            {
                _db.Entry(_p).CurrentValues.SetValues(p);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Current entity does not exists");
            }
        }
        public void Add(Passenger p)
        {
            _db.Passengers.Add(p);
            _db.SaveChanges();

        }

    }
}