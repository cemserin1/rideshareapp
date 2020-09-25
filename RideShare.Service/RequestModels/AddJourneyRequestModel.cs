using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RideShareApp.Models
{
    public class AddJourneyRequestModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string VehicleId { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public int JourneyStatus { get; set; }
        [Required]
        public int AvailableSeats { get; set; }
    }
}
