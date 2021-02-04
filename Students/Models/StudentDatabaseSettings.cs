using System;

namespace Students.Models
{
    public class StudentDatabaseSettings: IStudentDatabaseSettings
    {
        public string StudentInfoCollectionName { get; set; }
        public string CourseCollectionName { get; set; }
        public string ProfileCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

        public interface IStudentDatabaseSettings
    {
         string StudentInfoCollectionName { get; set; }
        string CourseCollectionName { get; set; }
         string ProfileCollectionName { get; set; }
         string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}