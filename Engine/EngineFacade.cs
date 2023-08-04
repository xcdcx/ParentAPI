using Engine.Algorithms;
using Engine.Entities;

namespace Engine
{
    public class EngineFacade : IEngine
    {
        public PersonNode CreateTree(IEnumerable<Person> person)
        {
            var dataArray = person.ToDataMembers();
            ParentTree tree = new ParentTree();
            //int[] parent = new int[] { -1, 0, 0, 0, 0, 1, 1, 3, 5 };
            //int n = parent.Length;
            Node node = tree.CreateTree(dataArray);


            return node.ToEntity();
        }
    }
}