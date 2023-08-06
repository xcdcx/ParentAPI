using Services.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Logging;

namespace Service.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly ILogger _logger;
        private readonly IMongoCollection<Person> _people;

        public PeopleService(ILogger<PeopleService> logger, IPersonStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            _logger = logger;
            var db = mongoClient.GetDatabase(settings.DatabaseName);
            _people = db.GetCollection<Person>(settings.PersonCollectionName);
        }

        /// <summary>
        /// Create or replace if exists specific entry in DB
        /// </summary>
        /// <param name="persons"></param>
        public void Create(IEnumerable<Person> persons)
        {
            try
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
                        _logger.LogWarning("Overriding existing entry", entry.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Eroor in Create");
                throw;
            }
        }
    }
}