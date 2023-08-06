using Engine.Algorithms;
using Engine.Entities;
using Microsoft.Extensions.Logging;
using Services;
using Shared.Entities;

namespace Engine
{
    public class ParentEngine : IParentEngine
    {
        private readonly ILogger _logger;
        private readonly IPeopleService _service;
        public ParentEngine(ILogger<ParentEngine> logger, IPeopleService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Order person array into parrent tree
        /// </summary>
        /// <param name="person"></param>
        /// <returns>parent tree</returns>
        public Node CreateTree(IEnumerable<Person> person)
        {
            try
            {
                var dataDic = person.ToDataMembersDic();
                ParentTree tree = new ParentTree();
                Node node = tree.CreateTree(dataDic);

                _service.Create(node.ToModel());

                return node;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex , "Error in CreateTree");
                throw;
            }
        }
    }
}