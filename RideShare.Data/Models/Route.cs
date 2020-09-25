using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Data.Models
{
    public class Route
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Map StartCity { get; set; }
        public Map EndCity { get; set; }
        public List<Map> RoutesPassedBy { get; set; }
    }
}
