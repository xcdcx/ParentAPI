using Engine.Algorithms;
using Engine.Entities;
using Services;
using Shared.Entities;

namespace Engine
{
    public class ParentEngine : IParentEngine
    {
        private readonly IPeopleService _service;
        public ParentEngine(IPeopleService service)
        {
                _service = service;
        }

        /// <summary>
        /// Order person array into parrent tree
        /// </summary>
        /// <param name="person"></param>
        /// <returns>parent tree</returns>
        public Node CreateTree(IEnumerable<Person> person)
        {
            var dataDic = person.ToDataMembersDic();
            ParentTree tree = new ParentTree();
            Node node = tree.CreateTree(dataDic);
            //var result = node.ToEntity();

            _service.Create(node.ToModel());

            return node;
        }
    }
}