using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirportMVC1.Models.entity;

namespace AirportMVC1.Models.Repositories
{
    public class PassengerRepository : IPassenger
    {
        DbContext _db;
        
        public PassengerRepository()
        {
            _db = new AirportContext();
        }

        public string FirstName
        { get; set; }


        public string Gender
        { get; set; }


        public int Id
        { get; set; }


        public string PassportNumber
        { get; set; }


        public string PassportSerial
        { get; set; }


        public string SecondName
        { get; set; }

    }
}