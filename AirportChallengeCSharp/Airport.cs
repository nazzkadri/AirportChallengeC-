using System;
using System.Collections.Generic;

namespace AirportChallengeCSharp
{
    public class Airport
    {
        public List<Plane> hanger;
        public Weather weather;


        public Airport(Weather weatherObj)
        {
            weather = weatherObj;
            hanger = new List<Plane>();
        }
        public void land(Plane plane)
        {
            hanger.Add(plane);
        }

        public String TakeOff(Plane plane)
        {
            if (weather.isStormy())
            {
                //throw new Exception("Weather is bad, can not take off.");
                return "is stormy";
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
