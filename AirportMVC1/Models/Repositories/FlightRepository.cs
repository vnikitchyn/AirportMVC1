using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirportMVC1.Models.entity;
using AirportMVC1.Models.Repositories;
using AirportMVC1.Models;
using System.Data.Entity;
using System.Data.SqlTypes;

namespace AirportMVC1.Models.Repositories
{
    public class FlightRepository : IFlight
    {
        AirportContext _db;
        public FlightRepository()
        {
            _db = new AirportContext();
        }

        public List <IFlight> GetFlights()
        {
            var fl = _db.Flight.ToList<IFlight>();
            var fl1 = from flight in fl
                      select new { flight.Number, flight.CityFrom, flight.CityTo}; 
            return fl;

        }

        public void AddFlight(FlightRepository flight)
        {
            _db.Flight.Add(flight);
            _db.SaveChanges();
        }

        public void AddFlights(List <FlightRepository> flights)
        {
            _db.Flight.AddRange(flights);
            _db.SaveChanges();
        }



        public DateTime? ArrivalTime
        //{
        //    get
        //    {
        //        if (ArrivalTime < (DateTime)SqlDateTime.MinValue)
        //            ArrivalTime = null;
        //        return ArrivalTime;
        //    }
        //    set
        //    { ArrivalTime = value; }
        //}
             { get; set; }

    public string CityFrom
        { get; set; }


        public string CityTo
        { get; set; }


        public DateTime? DepartureTime
        //{
        //    get
        //    {
        //        if (DepartureTime < (DateTime)SqlDateTime.MinValue)
        //            DepartureTime = null;
        //        return DepartureTime;
        //    }
        //    set
        //    { DepartureTime = value; }
        //}
                     { get; set; }



    public int Id
        { get; set; }


        public string Number
        { get; set; }


        public List<IPassenger> Passenger
        { get; set; }


        public ITerminal Terminal
        { get; set; }
    }
    }