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
        internal static List<Flight> flightList = new List<Flight>();
        AirportContext _db;
        public FlightRepository()
        {
            _db = new AirportContext();
        }

        public List<Flight> Get()
        {
            var fl = _db.Flights.ToList<Flight>();
            var fl1 = from flight in fl
                      select new { flight.Number, flight.PortArrival, flight.PortDeparture };
            return fl;
        }


        internal static List<Flight> AllFlightsToList()
        {
            using (var db = new AirportContext())
            {
                flightList = db.Flights.ToList();
            }
            return flightList;
        }
        internal static List<Passenger> AllPassengersToList()
        {
            using (var db = new AirportContext())
            {
                List <Passenger> passList = db.Passengers.ToList();
                return passList;
            }
        }

        internal static List<Ticket> AllTicketsToList()
        {
            using (var db = new AirportContext())
            {
               var TicketsList = db.Tickets.ToList();
                return TicketsList;
            }
        }


        public List <Flight> FindByNumberOnlyFlight(int number)
        {
            var flights = from f in AllFlightsToList()
                          where f.Number == number
                          select f;
            return flights.ToList<Flight>();

        }



        public Ticket  FindByNumberWithPassengerAndTicket2(int number)
        {
            IEnumerable<Ticket> flickets =
                from t in AllTicketsToList()
                join f in AllFlightsToList() on t.FlightId equals f.FlightId
                join p in AllPassengersToList() on t.PassId equals p.PassId
                where f.Number == number
                select new Ticket
                {
                    Flight = f, Passenger = p
                    //FlightNumber = f.Number,
                    //f.Airline,
                    //f.PortArrival,
                    //f.PortDeparture,
                    //f.Status,
                    //f.Terminal,
                    //f.Gate,
                    //Departure = f.TimeDeparture,
                    //ETA = f.TimeExpected,
                    //ATA = f.TimeArrival,
                    //t.Price,
                    //TicketNumber = t.Number,
                    //t.Place,
                    //p.Name,
                    //p.Surname,
                    //FullName = string.Format("{0} {1}", p.Name, p.Surname),
                    //p.Passport
                };
            foreach (Ticket flicket in flickets)
            {
                //Console.WriteLine("Flights with tikcets: {0} \n", flicket.ToString());
            }
            return flickets.First();
        }




        public dynamic FindByNumberWithPassengerAndTicket (int number)
        {
            IEnumerable<dynamic> flickets =
                from t in AllTicketsToList()
                join f in AllFlightsToList() on t.FlightId equals f.FlightId
                join p in AllPassengersToList() on t.PassId equals p.PassId
                where f.Number == number
                select new
                {
                    FlightNumber = f.Number,
                    f.Airline,
                    f.PortArrival,
                    f.PortDeparture,
                    f.Status,
                    f.Terminal,
                    f.Gate,
                    Departure = f.TimeDeparture,
                    ETA = f.TimeExpected,
                    ATA = f.TimeArrival,
                    t.Price,
                    TicketNumber = t.Number,
                    t.Place,
                    p.Name,
                    p.Surname,
                    FullName = string.Format("{0} {1}", p.Name, p.Surname),
                    p.Passport
                };
            foreach (dynamic flicket in flickets)
            {
                //Console.WriteLine("Flights with tikcets: {0} \n", flicket.ToString());
            }
            return flickets;
        }


        internal static int FindFlightID(int number)
        {
            using (var db = new AirportContext())
            {
                List<Flight> allFlights = db.Flights.ToList<Flight>();
                IEnumerable<Flight> filtered =
                    from flight in allFlights
                    where flight.Number == number
                    select flight;
                if (filtered.Any())
                    return filtered.FirstOrDefault().FlightId;
                else return 0;
            }

        }


        internal static int CountAllFlights()
        {
            using (var db = new AirportContext())
            {
                List<Flight> allFlights = db.Flights.ToList<Flight>();
                int count = allFlights.Count();
                return count;
            }

        }


        public List<Flight> GetFlightsAll()
        {
            var fl = _db.Flights.ToList<Flight>();
            return fl;
        }

        public void Add(Flight flight)
        {
            _db.Flights.Add(flight);
            _db.SaveChanges();

        }

        public void AddFlights(List <Flight> flights)
        {
            _db.Flights.AddRange(flights);
            _db.SaveChanges();
        }

        public void Update(Flight flight)
        {
            var _flight = _db.Flights.Find(flight.FlightId);
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
            _db.Flights.Remove(flight);
            _db.SaveChanges();
        }

        public Flight GetFlightById(int id)
        {
            var res = _db.Flights.FirstOrDefault(x => x.FlightId== id);
            return res;
        }
    }
    }