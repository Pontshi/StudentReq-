using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Students.Models
{
    
    public class StudentInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        [Required(ErrorMessage = "Name of the student is required")]
        public string Name { get; set; }

        [BsonElement("LastName")]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        
        [BsonElement("Qualification")]
        [Required(ErrorMessage = "Qualification is required")]
        public string Qualification { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Course { get; set; }

        [BsonIgnore]
        public List<string> CourseList { get; set; }

        public List<string> Email { get; set; }
    }
}