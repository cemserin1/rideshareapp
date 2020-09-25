using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Data.Models
{
    public class Map
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string CityName { get; set; }
    }
}
