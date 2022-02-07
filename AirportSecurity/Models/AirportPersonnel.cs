using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AirportSecurity.Models
{
    class AirportPersonnel
    {
        [Key]
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
     

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
