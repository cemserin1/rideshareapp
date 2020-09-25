using RideShare.Data.Interfaces;
using RideShare.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Data.Repositories
{
    public class MapRepository : BaseRepository<Map>, IMapRepository
    {
        public MapRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
