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

        //internal static IEnumerable<PersonNode> ToEntity(this Node node)
        //{
        //    PersonNode result = new();
        //    result.Name = node.value;
        //    result.Id = node.key;
        //    result.Childs = node.childs;

        //}

        internal static PersonNode ToEntity(this Node node)
        {
            //PersonNode result = new();
            //result.Name = node.value;
            //result.Id = node.key;
            //result.Childs = new List<PersonNode>();
            //if (node.childs.Any())
            //{
            //    foreach(Node childNode in node.childs)
            //    {
            //        result.Childs.ToList().Add(childNode.ToEntity());
            //    }
            //}
            //return result;
            return new PersonNode(node);
        }
    }
}
