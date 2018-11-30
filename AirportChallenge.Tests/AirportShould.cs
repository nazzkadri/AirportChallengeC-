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
            Mock<IWeather> weather = new Mock<IWeather>();
            weather.Setup(x => x.IsStormy()).Returns(false);
            

            Airport airport = new Airport(weather.Object);
            Mock<Plane> plane = new Mock<Plane>();
            airport.land(plane.Object);
            Assert.Contains(plane.Object, airport.hanger);
        }

        [Fact]
        public void InstructPlaneToTakeOff()
        {
            Mock<IWeather> weather = new Mock<IWeather>();
            weather.Setup(x => x.IsStormy()).Returns(false);
           
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
            Mock<IWeather> weather = new Mock<IWeather>();
            Airport airport = new Airport(weather.Object);
            weather.Setup(x => x.IsStormy()).Returns(false);
        
            
            airport.land(plane.Object);

            weather.Setup(x => x.IsStormy()).Returns(true);

          
            Assert.Contains(plane.Object, airport.hanger);
          //  Assert.Equal("is stormy", airport.TakeOff(plane.Object));
           Assert.Throws<InvalidOperationException>(() => airport.TakeOff(plane.Object));
            var ex = Assert.Throws<InvalidOperationException>(() => airport.TakeOff(plane.Object));
            Assert.Equal("Weather is bad, can not take off.", ex.Message);

        }
    }
}
