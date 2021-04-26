using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public int SquareFootage { get; set; }
        public Grass Grass { get; set; }
        public bool IsProjectAreaCleared {get;set;}
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Cost { get; set; }
        public string StreetAddress { get; set; }
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string ZipAddress { get; set; }
        public string LatAddress { get; set; }
        public string LongAddress { get; set; }
        public List<Appointment> Appointments { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Salesperson")]
        public int SalespersonID { get; set; }
        public virtual Salesperson Salesperson { get; set; }

    }
}
