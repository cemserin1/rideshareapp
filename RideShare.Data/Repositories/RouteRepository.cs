using RideShare.Data.Interfaces;
using RideShare.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Data.Repositories
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
