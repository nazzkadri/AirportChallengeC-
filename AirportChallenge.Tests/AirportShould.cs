using System;
using Xunit;
using Moq;
using AirportChallengeCSharp;

namespace AirportChallenge.Tests
{
    public class AirportShould
    {
        [Fact]
        public void InstructPlaneToLand()
        {
            Airport airport = new Airport();
            Mock<Plane> plane = new Mock<Plane>();
            airport.land(plane.Object);
            Assert.Contains(plane.Object, airport.hanger);
        }
    }
}
