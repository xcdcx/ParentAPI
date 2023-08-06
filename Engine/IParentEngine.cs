using Engine.Entities;
using Shared.Entities;

namespace Engine
{
    public interface IParentEngine
    {
        /// <summary>
        /// Order person array into parrent tree
        /// </summary>
        /// <param name="person"></param>
        /// <returns>parent tree</returns>
        public Node CreateTree(IEnumerable<Person> person);
    }
}
