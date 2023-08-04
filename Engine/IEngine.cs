using Engine.Entities;

namespace Engine
{
    public interface IEngine
    {
        public IEnumerable<PersonNode> CreateTree(IEnumerable<Person> person);
    }
}
