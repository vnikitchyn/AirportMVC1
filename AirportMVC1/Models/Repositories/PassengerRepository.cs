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

        DbContext _db;
        
        public PassengerRepository()
        {
            _db = new AirportContext();
        }


        internal static List<Flight> AllFlightsToList()
        {
            using (var db = new AirportContext())
            {
                return db.Flights.ToList();
            }
            
        }
        internal static List<Passenger> AllPassengersToList()
        {
            using (var db = new AirportContext())
            {
                return db.Passengers.ToList();
            }
         
        }

        internal static List<Ticket> AllTicketsToList()
        {
            using (var db = new AirportContext())
            {
                return db.Tickets.ToList();
            }
            
        }


        internal static IEnumerable FindSQLPassengerOnly(string passport)
        {
            IEnumerable<Passenger> filtered =
              from passenger in AllPassengersToList()
              where passenger.Passport.Equals(passport)
              select passenger;
            return filtered;
        }

        internal static IEnumerable FindSQLPassengerOnly(string name, string surname)
        {
            IEnumerable<Passenger> filtered =
              from passenger in AllPassengersToList()
              where passenger.Name.Equals(name) && passenger.Surname.Equals(surname)
              select passenger;
            return filtered;
        }
    }
}