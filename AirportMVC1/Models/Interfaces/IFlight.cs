using AirportMVC1.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportMVC1.Models.Interfaces
{
    interface IFlight
    {
        void Add(Flight flight);
        List<Flight> Get();
        void Update(Flight flight);
        void Delete(int id);
        Flight GetFlightById(int id);
    }
}
