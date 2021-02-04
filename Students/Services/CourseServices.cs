using MongoDB.Driver;
using Students.Models;
using System.Collections.Generic;
using System.Linq;

namespace Students.Services
{
    public class CourseServices
    {
        private readonly IMongoCollection<Course> _course;

        public CourseServices(IStudentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _course = database.GetCollection<Course>(settings.CourseCollectionName);
        }

        public List<Course> GetCourse()
        {
            return _course.Find(student =>true).ToList();
        }

        public Course GetStudent(string Id)
        {
            return _course.Find<Course>(x => x.Id == Id).SingleOrDefault();
        }

        public Course Insert(Course course)
        {
            _course.InsertOne(course);
            return course;
        }

        public void Update(Course course, string Id)
        {
            _course.ReplaceOne(x => x.Id ==Id , course); 
        }

        public void Delete(string Id)
        {
            _course.DeleteOne(x => x.Id == Id);
        }

    }
}