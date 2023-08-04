using Engine.Algorithms;
using Engine.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Engine
{
    internal static class Mapper
    {
        internal static DataMember[] ToDataMembers(this IEnumerable<Person> persons)
        {
            DataMember[] arr = new DataMember[persons.Count() + 1];
            arr[0] = new DataMember(-1, null); //root init
            foreach (Person person in persons)
            {
                if (arr[person.Id] != null)
                {
                    throw new ArgumentException("Duplicated Id");
                }
                else
                {
                    arr[person.Id] = new DataMember(person.ParentId, person.Name);
                }
            }
            return arr;
        }

        internal static IEnumerable<PersonNode> ToEntity(this Node node)
        {
            List<PersonNode> result = new();
            if (node.value == null) //tree root node
            {
                foreach (Node realNode in node.childs)
                {
                    result.Add(new PersonNode(realNode));
                }
            }
            else
            {
                throw new ArgumentException("Error in Parent tree algorithm");
            }
            return result;
        }
    }
}
