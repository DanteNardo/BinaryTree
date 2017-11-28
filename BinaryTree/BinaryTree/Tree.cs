using System;

namespace BinaryTree
{
    /// <summary>
    /// Author: Dante Nardo
    /// Last Modified: 11/28/2017
    /// Purpose: Creates a binary tree of integers with a set depth.
    /// </summary>
    class Tree
    {
        #region Tree Members
        public Node Root { get; private set; }  // The parent node in the binary tree.
        public int Depth { get; private set; }  // The depth of the current generated tree.
        #endregion

        #region Tree Methods
        public Tree()
        {
            Root = null;
            Depth = 0;
        }

        public void CreateTree(int depth)
        {
            // Instantiate root, depth, and current node
            Depth = depth;
            depth = 1;
            Root = new Node();
            Root.CalculateValue();
            Node start = Root;
            Node current = start;

            CreateBranches(Root, 1);
        }

        /// <summary>
        /// Creates the branching nodes and instantiates a few of their basic data members.
        /// Recursive function that fails to instantiate data that relies on completed branches.
        /// Each node's value and one of their neighbors can only be determined after the function ends.
        /// </summary>
        /// <param name="current">The current node from which to branch</param>
        /// <param name="depth">The current depth to determine the end of the recursive function</param>
        private void CreateBranches(Node current, int depth)
        {
            // Create two children
            current.LeftChild = new Node();
            current.RightChild = new Node();

            // Set left's right, rightNeighbor, and parent
            current.LeftChild.Left = true;
            current.LeftChild.RightNeighbor = current.RightChild;
            current.LeftChild.Parent = current;

            // Set right's right, leftNeighbor, and parent
            current.RightChild.Left = false;
            current.RightChild.LeftNeighbor = current.LeftChild;
            current.RightChild.Parent = current;

            // Calculate initial values
            current.LeftChild.CalculateValue();
            current.RightChild.CalculateValue();

            // Recursive end condition: stop creating branches once we've reached the end
            if (depth < Depth-1)
            {
                depth++;
                CreateBranches(current.LeftChild, depth);
                CreateBranches(current.RightChild, depth);
            }
        }

        /// <summary>
        /// Recursive function that prints the current line and calls itself on the next line if it exists.
        /// </summary>
        /// <param name="start">The starting node</param>
        /// <param name="depth">The current depth</param>
        public void PrintTree(Node start, int depth)
        {
            // Necessary for pretty printing
            int incr = 1;
            int extraSpace = depth * incr;
            for (int i = 0; i < extraSpace; i++)
            {
                Console.Write(" ");
            }

            // Print the leftmost value at this depth.
            Node current = start;
            Console.Write(current.Value + " ");

            // Continue printing until there are no more nodes to the right.
            int index = 1;
            while (current.RightNeighbor != null)
            {
                current = current.RightNeighbor;
                Console.Write(current.Value + " ");
                index++;

                if (current.Value == 2)
                {
                    index++;
                    index--;
                }

                if (index == 2)
                {
                    for (int i = 0; i < extraSpace - 1; i++)
                    {
                        Console.Write(" ");
                    }
                    index = 0;
                }
            }

            // Print next line if it exists
            if (start.LeftChild != null)
            {
                Console.WriteLine();
                PrintTree(start.LeftChild, depth-1);
            }
        }
        #endregion
    }
}
