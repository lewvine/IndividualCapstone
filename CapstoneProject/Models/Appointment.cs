using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        public string InteractionType { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }

        [ForeignKey("Project")]
        public int ID { get; set; }
        public Project Project { get; set; }

    }
}
