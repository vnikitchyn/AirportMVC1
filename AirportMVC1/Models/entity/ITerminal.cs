using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC1.Models.entity
{
    public interface ITerminal
    {
         int Id { get; set; }
         string Name { get; set; }

    }
}