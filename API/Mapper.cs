using API.Dtos;

namespace API
{
    internal static class Mapper
    {
        /// <summary>
        /// Map api object to engine object
        /// </summary>
        /// <param name="persons"></param>
        /// <returns>engine object</returns>
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

        /// <summary>
        /// Map api object to engine object
        /// </summary>
        /// <param name="person"></param>
        /// <returns>engine object</returns>
        internal static Engine.Entities.Person? ToEntity(this PersonDto person)
        {
            return new Engine.Entities.Person
            {
                Name = person.Name,
                Id = person.Id,
                ParentId = person.Parent ?? 0
            };
        }

        /// <summary>
        /// Map engine object to api object
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns>api object</returns>
        internal static IEnumerable<PersonResponseDto> ToDto(this IEnumerable<Engine.Entities.PersonNode> nodes)
        {
            List<PersonResponseDto> result = new();
            foreach (Engine.Entities.PersonNode node in nodes)
            {
                result.Add(new PersonResponseDto(node));
            }
            return result;
        }
    }
}
