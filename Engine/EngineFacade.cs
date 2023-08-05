using Engine.Algorithms;
using Engine.Entities;
using Services;

namespace Engine
{
    public class EngineFacade : IEngine
    {
        private readonly IService _service;
        public EngineFacade(IService service)
        {
                _service = service;
        }
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