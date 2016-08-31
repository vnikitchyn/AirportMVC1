using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirportMVC1.Models.entity;
using AirportMVC1.Models.Interfaces;

namespace AirportMVC1.Models.Repositories
{
    public class PassengerRepository : IPassenger
    {
        DbContext _db;
        
        public PassengerRepository()
        {
            _db = new AirportContext();
        }

     
    }
}