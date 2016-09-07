using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirportMVC1.Models.Repositories;

namespace AirportMVC1.Tests.Repositories
{
    [TestClass]
    public class FlightRepositoryTest
    {
        [TestMethod]
        public void SuccessFlightCount()
        {
            //Arrange
            var repo = new FlightRepository();
            //Act
            int count = repo.GetFlightsAll().Count;
            //Assert
            Assert.IsTrue(count > 0, "ok");
        }
    }
}
