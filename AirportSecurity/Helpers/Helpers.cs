using System;
using System.Collections.Generic;
using AirportSecurity.Interfaces;

namespace AirportSecurity.Helpers
{
  
    public class Helpers:IHelpers
    {

        // Method to get the abbreviated month name
        public string GetAbbreviatedName(int day, int month, int year) 
        {
            DateTime date = new DateTime(year, month, day);
         
            return date.ToString("MMM");
        }

        public List<T> CreateList<T>(params T[] values)
        {
            return new List<T>(values);
        }
    }
}
