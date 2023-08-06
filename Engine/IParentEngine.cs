using Engine.Entities;

namespace Engine
{
    public interface IParentEngine
    {
        /// <summary>
        /// Order person array into parrent tree
        /// </summary>
        /// <param name="person"></param>
        /// <returns>parent tree</returns>
        public IEnumerable<PersonNode> CreateTree(IEnumerable<Person> person);
    }
}
