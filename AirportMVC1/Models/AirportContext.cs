using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirportMVC1.Models.entity;
using AirportMVC1.Models.Repositories;
using System.Data.Entity;

namespace AirportMVC1.Models
{
    public class AirportContext : DbContext

    {
       public DbSet <TerminalRepository> Terminal { get; set; }
        public DbSet<FlightRepository> Flight { get; set; }
        public DbSet<PassengerRepository> Passenger { get; set; }
    }
}