using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Data
{
    public interface IMongoDbContext
    {   
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
