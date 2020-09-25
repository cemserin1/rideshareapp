using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RideShare.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideShareApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideShareController : ControllerBase
    {

        private readonly IRideShareService _rideShareService;

        public RideShareController(IRideShareService rideShareService)
        {
            _rideShareService = rideShareService;
        }

        /// <summary>
        /// Initiates the sharing ride process. Returns false if there are no available seats. 
        /// </summary>
        /// <param name="journeyId">Journey Id</param>
        [HttpPost]
        public void Post(string journeyId)
        {
            _rideShareService.ShareRide(journeyId);
        }
    }
}
