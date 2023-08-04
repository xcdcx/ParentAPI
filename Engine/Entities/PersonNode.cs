using Engine.Algorithms;
using System.Xml.Linq;

namespace Engine.Entities
{
    public class PersonNode
    {
        public PersonNode()
        {               
        }
        public PersonNode(Node node)
        {
            this.Id = node.key;
            this.Name = node.value;
            this.Childs = node.childs.Select(n => new PersonNode(n)).ToList();
            //Children = node.Children.Select(n => new NodeA(n)).ToList();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PersonNode> Childs { get; set; }
    }
}
