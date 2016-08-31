using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC1.Models.entity
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PassportSerial { get; set; }
        public string PassportNumber { get; set; }
        public string Gender { get; set; }
    }
}