namespace Shared.Entities
{
    // A parent tree node
    public class Node
    {
        public int id;
        public int key;
        public string value;
        public List<Node> childs;

        public Node(int id, int key, string value)
        {
            this.id = id;
            this.key = key;
            this.value = value;
            childs = new List<Node>();
        }
    }
}
