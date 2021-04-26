using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class Grass
    {
        [Key]
        public int GrassID { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
