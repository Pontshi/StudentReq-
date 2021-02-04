using MongoDB.Driver;
using Students.Models;
using System.Collections.Generic;
using System.Linq;

namespace Students.Services
{
    public class StudentServices
    {
        private readonly IMongoCollection<StudentInfo> _student;

        public StudentServices(IStudentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _student = database.GetCollection<StudentInfo>(settings.StudentInfoCollectionName);
        }

        public List<StudentInfo> GetStudents()
        {
            return _student.Find(student =>true).ToList();
        }

        public StudentInfo GetStudent(string Id)
        {
            return _student.Find<StudentInfo>(x => x.Id == Id).SingleOrDefault();
        }

        public StudentInfo Insert(StudentInfo student)
        {
            _student.InsertOne(student);
            return student;
        }

        public async System.Threading.Tasks.Task UpdateAsync(StudentInfo student, string Id)
        {
           await _student.ReplaceOneAsync(x => x.Id ==Id , student); 
        }

        public StudentInfo Look(string Id)
        {
            return _student.Find(x => x.Id == Id).SingleOrDefault();
        }

        public async System.Threading.Tasks.Task DeleteAsync(string Id)
        {
           await _student.DeleteOneAsync(x => x.Id == Id);
        }


    }
}