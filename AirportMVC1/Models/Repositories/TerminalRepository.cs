using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirportMVC1.Models;
using AirportMVC1.Models.entity;

namespace AirportMVC1.Models.Repositories 
{
    public class TerminalRepository : ITerminal
    {
        DbContext _db;

        public TerminalRepository(){
            _db = new AirportContext();
            }

        public int Id
        { get; set; }


        public string Name
        { get; set; }

    }
}