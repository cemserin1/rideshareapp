using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Data
{
    public class Journey
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string VehicleId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureDate { get; set; }
        public int JourneyStatus { get; set; }
        public int AvailableSeats { get; set; }
    }

    public enum JourneyStatus
    {
        Created,
        Active,
        Inactive
    }
}
