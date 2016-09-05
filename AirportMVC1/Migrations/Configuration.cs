namespace AirportMVC1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static AirportMVC1.Models.Helper;

    internal sealed class Configuration : DbMigrationsConfiguration<AirportMVC1.Models.AirportContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AirportMVC1.Models.AirportContext context)
        {

            if (context.Flights.ToList().Count() <= 0)
                context.Flights.AddRange(BuildInitialFlights());
            if (context.Tickets.ToList().Count() <= 0)
                context.Tickets.AddRange(BuildInitialTickets());
            if (context.Passengers.ToList().Count() <= 0)
                context.Passengers.AddRange(BuildInitialPassengers());

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
