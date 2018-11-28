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
            Mock<Weather> weather = new Mock<Weather>();
            weather.Setup(x => x.isStormy()).Returns(false);
            Airport airport = new Airport(weather.Object);
            Mock<Plane> plane = new Mock<Plane>();
            airport.land(plane.Object);
            Assert.Contains(plane.Object, airport.hanger);
        }

        [Fact]
        public void InstructPlaneToTakeOff()
        {
            Mock<Weather> weather = new Mock<Weather>();
            weather.Setup(x => x.isStormy()).Returns(false);
            Airport airport = new Airport(weather.Object);
            Mock<Plane> plane = new Mock<Plane>();
            airport.land(plane.Object);
            airport.TakeOff(plane.Object);
            Assert.DoesNotContain(plane.Object, airport.hanger);
        }

        [Fact]
        public void NotAllowPlanesToTakeOffIfWeatherIsStormy()
        {
           
            Mock<Plane> plane = new Mock<Plane>();

            Mock<Weather> weather = new Mock<Weather>();
           weather.Setup(x => x.isStormy()).Returns(true);
            Airport airport = new Airport(weather.Object);

            airport.land(plane.Object);

            airport.TakeOff(plane.Object);
            Assert.Contains(plane.Object, airport.hanger);
          //  Assert.Equal("is stormy", airport.TakeOff(plane.Object));
            //Assert.Throws<ArgumentException>(() => airport.TakeOff(plane.Object));
        }
    }
}
