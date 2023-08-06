using Engine.Algorithms;
using Engine.Entities;
using Services;

namespace Engine
{
    public class ParentEngine : IParentEngine
    {
        private readonly IService _service;
        public ParentEngine(IService service)
        {
                _service = service;
        }

        /// <summary>
        /// Order person array into parrent tree
        /// </summary>
        /// <param name="person"></param>
        /// <returns>parent tree</returns>
        public IEnumerable<PersonNode> CreateTree(IEnumerable<Person> person)
        {
            var dataArray = person.ToDataMembers();
            ParentTree tree = new ParentTree();
            Node node = tree.CreateTree(dataArray);

            //_service.DoSomething();

            return node.ToEntity();
        }
    }
}