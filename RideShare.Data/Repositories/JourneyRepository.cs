using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Data
{
    public class JourneyRepository : BaseRepository<Journey>, IJourneyRepository
    {
        public JourneyRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
