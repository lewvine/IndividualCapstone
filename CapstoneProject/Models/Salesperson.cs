using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class Salesperson
    {
        [Key]
        public int SalespersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string ZipAddress { get; set; }
        public string? LatAddress { get; set; }
        public string? LongAddress { get; set; }
        public string EMailAddress { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
