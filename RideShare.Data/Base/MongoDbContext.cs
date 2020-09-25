using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Data
{
    public class MongoDBContext : IMongoDbContext
    {
        public IMongoDatabase _db;

        public MongoClient _mongoClient;

        public MongoDBContext()
        {   
            _mongoClient = new MongoClient("mongodb+srv://admin:rideadmin@adesso.zmskj.mongodb.net/<dbname>?retryWrites=true&w=majority");
            _db = _mongoClient.GetDatabase("RideShareDb");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }

       
    }
}
