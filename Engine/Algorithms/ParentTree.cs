namespace Engine.Algorithms
{
    internal class ParentTree
    {
        public Node root;

        /// <summary>
        /// Creates a node with key as current,
        /// if current is root, then it changes root,
        /// if parent of current is not created,
        /// then it creates parent first
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="current"></param>
        /// <param name="created"></param>
        public void CreateNode(Dictionary<int, DataMember> parent, KeyValuePair<int, DataMember> current, Dictionary<int, Node> created)
        {
            // If this node is already created
            if(created.ContainsKey(current.Key))
            {
                return;
            }

            // Create a new node
            created.Add(current.Key, new Node(current.Key, current.Value.key, current.Value.value));

            // If current is root, change root
            // and return
            if (current.Value.key == -1)
            {
                root = created[current.Key];
                return;
            }

            // If parent is not created, then
            // create parent first
            if(!created.ContainsKey(current.Value.key))
            {
                CreateNode(parent, parent.SingleOrDefault(p => p.Key == current.Value.key), created);
            }

            // Find parent
            Node p = created[current.Value.key];

            // Add child
            p.childs.Add(created[current.Key]);
        }

        /// <summary>
        /// Creates tree from parent
        /// </summary>
        /// <param name="parent"></param>
        /// <returns>Root of the created tree</returns>
        public Node CreateTree(Dictionary<int, DataMember> parents)
        {
            // Create an dictionary created<int, Node> to
            // keep track of created nodes,
            Dictionary<int, Node> created = new Dictionary<int, Node>();
            //Node[] created = new Node[n];

            foreach(KeyValuePair<int, DataMember> parent in parents)
            {
                CreateNode(parents, parent, created);
            }

            return root;
        }
    }
}
