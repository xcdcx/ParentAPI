using API.Dtos;

namespace API
{
    internal static class Mapper
    {
        internal static IEnumerable<Engine.Entities.Person> ToEntity(this IEnumerable<PersonDto> persons)
        {
            List<Engine.Entities.Person> result = new();
            foreach (PersonDto person in persons)
            {
                if (person != null)
                {
                    result.Add(person.ToEntity());
                }
            }
            return result;
        }
        internal static Engine.Entities.Person? ToEntity(this PersonDto person)
        {
            return new Engine.Entities.Person
            {
                Name = person.Name,
                Id = person.Id,
                ParentId = person.Parent ?? 0
            };
        }
    }
}
