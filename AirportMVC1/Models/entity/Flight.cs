using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC1.Models.entity
{
    public class Flight
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime? ArrivalTime
        {
            get; set;
        }

        public DateTime? DepartureTime
        {
            get; set;
        }


        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        
         Terminal Terminal {get; set;}
         List <Passenger> Passenger { get; set; }
    }
}