using Services.Models;
using MongoDB.Driver;

namespace Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IMongoCollection<Person> _people;

        public PeopleService(IPersonStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase(settings.DatabaseName);
            _people = db.GetCollection<Person>(settings.PersonCollectionName);
        }
        public int Create(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                var entry = _people.Find(entry => entry.Id == person.Id).FirstOrDefault();
                if (entry == null)
                {
                    _people.InsertOne(person);
                }
                else
                {
                    _people.ReplaceOne(per => per.Id == entry.Id, person);
                }
            }
            //_people.InsertOne(person);
            //return person;
            //_people.InsertMany(persons);
            return persons.Count();
        }
    }
}