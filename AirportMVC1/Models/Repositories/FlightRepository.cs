using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirportMVC1.Models.entity;
using AirportMVC1.Models.Repositories;
using AirportMVC1.Models;
using System.Data.Entity;
using System.Data.SqlTypes;
using AirportMVC1.Models.Interfaces;

namespace AirportMVC1.Models.Repositories
{
    public class FlightRepository : IFlight
    {
        AirportContext _db;
        public FlightRepository()
        {
            _db = new AirportContext();
        }

        public List<Flight> Get()
        {
            var fl = _db.Flight.ToList<Flight>();
            var fl1 = from flight in fl
                      select new { flight.Number, flight.CityFrom, flight.CityTo };
            return fl;
        }

        public List<Flight> GetFlightsAll()
        {
            var fl = _db.Flight.ToList<Flight>();
            return fl;
        }

        public void Add(Flight flight)
        {
            _db.Flight.Add(flight);
            _db.SaveChanges();

        }

        public void AddFlights(List <Flight> flights)
        {
            _db.Flight.AddRange(flights);
            _db.SaveChanges();
        }

        public void Update(Flight flight)
        {
            var _flight = _db.Flight.Find(flight.Id);
            if (_flight !=null)
            {
                _db.Entry(_flight).CurrentValues.SetValues(flight);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Current entity does not exists");
            }
        }

        public void Delete(int id)
        {
            var flight = GetFlightById(id);
            _db.Flight.Remove(flight);
            _db.SaveChanges();
        }

        public Flight GetFlightById(int id)
        {
            var res = _db.Flight.FirstOrDefault(x => x.Id == id);
            return res;
        }

    }
    }