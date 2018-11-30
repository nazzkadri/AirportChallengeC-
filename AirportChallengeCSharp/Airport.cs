using System;
using System.Collections.Generic;

namespace AirportChallengeCSharp
{
    public class Airport
    {
        public List<Plane> hanger;
        private readonly IWeather _weather;


        public Airport(IWeather weatherObj)
        {
            _weather = weatherObj;
            hanger = new List<Plane>();
        }
        public void land(Plane plane)
        {

            if (_weather.IsStormy())
            {
                throw new InvalidOperationException("Weather is bad, can not land.");
                //return "is stormy";
            }
            else
            {
                hanger.Add(plane);
            }
        }

        public String TakeOff(Plane plane)
        {
            if (_weather.IsStormy())
            {
                throw new InvalidOperationException("Weather is bad, can not take off.");
                //return "is stormy";
            } else
            {
                hanger.Remove(plane);
                return "plane took off";
            }
            
        }

        static void Main(string[] args)
        {
           
        }
    }
}
