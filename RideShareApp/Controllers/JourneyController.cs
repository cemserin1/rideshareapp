using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RideShare.Data;
using RideShare.Service;
using RideShareApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideShareApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public JourneyController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }

        /// <summary>
        /// Gets all the available Journeys within given destination parameters.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Journey> Get(string from, string to)
        {
            var journeyList = _journeyService.GetAvailableJourneys(from, to);
            return journeyList;
        }
        /// <summary>
        /// Adds a new journey.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public void Post([FromBody] AddJourneyRequestModel request)
        {
            _journeyService.AddJourney(request);
        }
        /// <summary>
        /// Updates selected journey's availability status. 1 = Active, 2 = Inactive
        /// </summary>
        /// <param name="journeyId"></param>
        /// <param name="journeyStatus"></param>
        [HttpPut("{journeyId}")]
        public void Put(string journeyId, int journeyStatus)
        {
            _journeyService.UpdateJourneyStatus(journeyId, journeyStatus);
        }
    }
}
