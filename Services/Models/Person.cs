using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shared.Entities;

namespace Services.Models
{
    [BsonIgnoreExtraElements]
    public class Person
    {
        public Person() { }
        public Person(Node node)
        {
            this.Id = node.id;
            this.Name = node.value;
            this.Childs = node.childs.Select(n => new Person(n)).ToList();
        }
        [BsonId]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("childs")]
        public IEnumerable<Person> Childs { get; set; } = new List<Person>();
    }
}
