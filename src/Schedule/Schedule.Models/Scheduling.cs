using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models
{
    public class Scheduling
    {
        [Key]
        public int ScheduleId { get; set; }
        public string Name { get; set; }
        public string No { get; set; }
        public IdentityUser User{ get; set; }
    }
}
