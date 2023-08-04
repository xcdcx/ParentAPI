using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Engine.Algorithms
{
    internal class ParentTree
    {
        public Node root;

        // Creates a node with key as 'i'.
        // If i is root, then it changes
        // root. If parent of i is not created,
        // then it creates parent first
        public void CreateNode(DataMember[] parent, int i, Node[] created)
        {
            // If this node is already created
            if (created[i] != null)
            {
                return;
            }

            // Create a new node and set created[i]
            created[i] = new Node(i, parent[i]._value);

            // If 'i' is root, change root
            // and return
            if (parent[i]._key == -1)
            {
                root = created[i];
                return;
            }

            // If parent is not created, then
            // create parent first
            if (created[parent[i]._key] == null)
            {
                CreateNode(parent, parent[i]._key, created);
            }

            // Find parent
            Node p = created[parent[i]._key];

            // Add child
            p.childs.Add(created[i]);
        }

        /* Creates tree from parent[0..n-1]
        and returns root of the created tree */
        public Node CreateTree(DataMember[] parent)
        {
            // Create an array created[] to
            // keep track of created nodes,
            int n = parent.Length;
            Node[] created = new Node[n];

            for (int i = 0; i < n; i++)
            {
                CreateNode(parent, i, created);
            }

            return root;
        }
    }

    // A parent tree node
    public class Node
    {
        public int key;
        public string value;
        public List<Node> childs;

        public Node(int key, string value)
        {
            this.key = key;
            this.value = value;
            childs = new List<Node>();
        }
    }

    public class DataMember
    {
        public readonly int _key;
        public readonly string _value;
        public DataMember(int key, string value)
        {
            this._key = key;
            this._value = value;
        }
    }
}
