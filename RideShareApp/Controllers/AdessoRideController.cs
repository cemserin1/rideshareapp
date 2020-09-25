using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RideShare.Data.Models;
using RideShare.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideShareApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdessoRideController : ControllerBase
    {
        private readonly IMapService _mapService;

        public AdessoRideController(IMapService mapService)
        {
            _mapService = mapService;
        }

        // GET: api/<AdessoRideController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var cityNames = _mapService.GetCityNames();
            return cityNames;
        }

        /// <summary>
        /// Gets all available routes that include selected destinations
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet("{from}/{to}")]
        public List<Route> Get(string from, string to)
        {
            var routeList = _mapService.GetAvailableRoutes(from, to);
            return routeList;
        }


        /// <summary>
        /// Creates a route from city A to city B
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post(string from, string to)
        {
            _mapService.CreateRoute(from, to);
        }
    }
}
