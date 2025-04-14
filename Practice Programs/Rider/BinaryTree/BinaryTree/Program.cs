using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace BinaryTree
{
    // Define the structure for a node
    struct TreeNode
    {
        public int Value;
        public int Left; // Index of the left child in the array (-1 if no child)
        public int Right; // Index of the right child in the array (-1 if no child)

        public TreeNode(int value, int left, int right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }
    }

    class BinaryTree
    {
        private TreeNode[] tree; // Array to store tree nodes
        private int nodeCount; // Number of nodes currently in the tree

        public BinaryTree(int size)
        {
            tree = new TreeNode[size];
            nodeCount = 0;
        }

        // Add a value to the tree
        public void Insert(int value)
        {
            if (nodeCount == 0)
            {
                tree[0] = new TreeNode(value, -1, -1);
                nodeCount++;
            }
            else
            {
                InsertRecursive(0, value);
            }
        }

        private void InsertRecursive(int currentIndex, int insertion)
        {
            if (insertion < tree[currentIndex].Value)
            {
                if (tree[currentIndex].Left == -1)
                {
                    tree[currentIndex].Left = nodeCount;
                    tree[nodeCount] = new TreeNode(insertion, -1, -1);
                    nodeCount++;
                }
                else
                {
                    InsertRecursive(tree[currentIndex].Left, insertion);
                }
            }
            else
            {
                if (tree[currentIndex].Right == -1)
                {
                    tree[currentIndex].Right = nodeCount;
                    tree[nodeCount] = new TreeNode(insertion, -1, -1);
                    nodeCount++;
                }
                else
                {
                    InsertRecursive(tree[currentIndex].Right, insertion);
                }
            }
        }

        // Pre-order traversal of the tree
        public void TraversePreOrderRecursive(int index)
        {
            if ()
        }
        // In-order traversal of the tree
        public void TraverseInOrderRecursive(int index)
        {
            // Your code here
        }
        // Post-order traversal of the tree
        public void TraversePostOrderRecursive(int index)
        {
            // Your code here
        }

        // Search method to check if a value is in the tree
        public bool Search(int target)
        {
            // Your code here, currently function just returns True
            return true;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree(10);

            // Insert values
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(70);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(60);
            tree.Insert(80);

            /* To test your functions:
            // Pre-order traversal
            Console.WriteLine("Pre-order traversal:");
            tree.TraversePreOrderRecursive(0);
            // In-order traversal
            Console.WriteLine("In-order traversal:");
            tree.TraverseInOrderRecursive(0);
            // Post-order traversal
            Console.WriteLine("Post-order traversal:");
            tree.TraversePostOrderRecursive(0);

            // Checking Search function
            Console.WriteLine("\nSearch results:");
            Console.WriteLine(tree.Search(40) ? "40 found in tree." : "40 not found.");
            Console.WriteLine(tree.Search(100) ? "100 found in tree." : "100 not found.");
            */
        }
    }
}

