using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirportSecurity.Models
{
    class Flights
    {
        [Key]
        public int FlightId { get; set; }
    }
}
