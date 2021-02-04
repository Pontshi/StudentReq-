using MongoDB.Driver;
using Students.Models;
using System.Collections.Generic;
using System.Linq;

namespace Students.Services
{
    public class ProfileServices
    {
        private readonly IMongoCollection<Profile> _profile;

        public ProfileServices(IStudentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _profile = database.GetCollection<Profile>(settings.ProfileCollectionName);
        }

        public List<Profile> GetCourse()
        {
            return _profile.Find(pro =>true).ToList();
        }

        public Profile GetStudent(string Id)
        {
            return _profile.Find<Profile>(x => x.Id == Id).SingleOrDefault();
        }

        public Profile Insert(Profile profile)
        {
            _profile.InsertOne(profile);
            return profile;
        }

        public void Update(Profile profile, string Id)
        {
            _profile.ReplaceOne(x => x.Id ==Id , profile); 
        }

        public void Delete(string Id)
        {
            _profile.DeleteOne(x => x.Id == Id);
        }

    }
}