using API.Dtos;
using Shared.Entities;

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
            HashSet<int> ids = new HashSet<int>();
            foreach (PersonDto person in persons)
            {
                if(ids.Contains(person.Id))
                {
                    throw new ArgumentException("Duplicate id");
                }
                else
                {
                    ids.Add(person.Id);
                }
            }
            foreach (PersonDto person in persons)
            {
                if (person != null)
                {
                    if(person.Parent.HasValue && !ids.Contains(person.Parent.Value))
                    {
                        person.Parent = null;
                    }
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
        internal static IEnumerable<PersonResponseDto> ToDto(this Node node)
        {
            List<PersonResponseDto> result = new();
            if (node.value == null) //tree root node
            {
                foreach (Node child in node.childs)
                {
                    result.Add(new PersonResponseDto(child));
                }
            }
            return result;
        }
    }
}
