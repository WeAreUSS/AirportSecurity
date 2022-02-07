using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AirportSecurity.Interfaces;

namespace AirportSecurity.Models
{
    public class SecStations
    {
        [Key]
        public int Key {get { return _key; } }
        public List<IScreeningStation> ScreeningStations { get; set; }
       

        private int _key;
        
        public SecStations(int key)
        {
            _key = key;
        }
    }
}
