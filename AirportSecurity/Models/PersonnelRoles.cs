using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AirportSecurity.Models
{
    class PersonnelRoles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Title { get; set; }
    }
}
