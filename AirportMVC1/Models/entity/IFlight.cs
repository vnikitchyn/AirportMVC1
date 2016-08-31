using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC1.Models.entity
{
    public interface IFlight
    {
         int Id { get; set; }
         string Number { get; set; }
         DateTime? ArrivalTime
        {
            get; set;
        }

        DateTime? DepartureTime
        {
            get; set;
        }

        
        string CityFrom { get; set; }
        string CityTo { get; set; }
        
         ITerminal Terminal {get; set;}
         List <IPassenger> Passenger { get; set; }
    }
}