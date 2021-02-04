using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Students.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CourseName")]
        public string CourseName { get; set; }

        [BsonElement("CourseCode")]
        public string CourseCode { get; set; }
        
    }
}