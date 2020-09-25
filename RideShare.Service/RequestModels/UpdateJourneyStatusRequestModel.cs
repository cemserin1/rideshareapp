using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShareApp.Models
{
    public class UpdateJourneyStatusRequestModel
    {
        public string JourneyId { get; set; }
        //new status
        public int Status { get; set; }
    }
}
