using Engine.Entities;

namespace Engine
{
    public interface IEngine
    {
        public PersonNode CreateTree(IEnumerable<Person> person);
    }
}
