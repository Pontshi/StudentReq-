using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Students.Models
{
    public class Profile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FileName")]
        public string FileName { get; set; }

        [BsonElement("FileData")]
        public byte FileData { get; set; }
    }
}