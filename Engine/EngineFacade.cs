using Engine.Algorithms;
using Engine.Entities;

namespace Engine
{
    public class EngineFacade : IEngine
    {
        public IEnumerable<PersonNode> CreateTree(IEnumerable<Person> person)
        {
            var dataArray = person.ToDataMembers();
            ParentTree tree = new ParentTree();
            Node node = tree.CreateTree(dataArray);


            return node.ToEntity();
        }
    }
}