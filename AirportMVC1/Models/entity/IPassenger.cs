using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC1.Models.entity
{
    public interface IPassenger
    {
         int Id { get; set; }
         string FirstName { get; set; }
         string SecondName { get; set; }
         string PassportSerial { get; set; }
         string PassportNumber { get; set; }
         string Gender { get; set; }
    }
}