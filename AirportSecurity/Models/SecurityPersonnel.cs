using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AirportSecurity.Models
{
    public class SecurityPersonnel
    {
        [Key]
        public int SecurityId { get; set; }
        public int RoleId { get; set; }
    }
}
