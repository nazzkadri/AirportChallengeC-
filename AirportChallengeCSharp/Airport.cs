using System;
using System.Collections.Generic;

namespace AirportChallengeCSharp
{
    public class Airport
    {
        public List<Plane> hanger;

        public Airport()
        {
            hanger = new List<Plane>();
        }
        public void land(Plane plane)
        {
            hanger.Add(plane);
        }

        static void Main(string[] args)
        {
           
        }
    }
}
