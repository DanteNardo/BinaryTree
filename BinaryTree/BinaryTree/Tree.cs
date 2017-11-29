using System;

namespace BinaryTree
{
    /// <summary>
    /// Author: Dante Nardo
    /// Last Modified: 11/29/2017
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

        /// <summary>
        /// Sets the initial Root values, then calls CreateBranches and FinishReferences.
        /// </summary>
        /// <param name="depth">The depth of the new tree to create</param>
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
            FinishReferences(Root, 1);
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
            if (depth < Depth - 1)
            {
                depth++;
                CreateBranches(current.LeftChild, depth);
                CreateBranches(current.RightChild, depth);
            }
        }

        /// <summary>
        /// Finds every missing LeftNeighbor and RightNeighbor reference.
        /// Recursive function that instantiates missing data that relies on completed branches.
        /// Must be run after CreateBranches because not all nodes exist before (or during) that function.
        /// </summary>
        /// <param name="current">The current node to update references of</param>
        /// <param name="depth">The current depth to determine the end of the recursive function</param>
        private void FinishReferences(Node current, int depth)
        {
            current.LeftChild.FindLeft();
            current.LeftChild.FindRight();
            current.RightChild.FindLeft();
            current.RightChild.FindRight();

            if (depth < Depth - 1)
            {
                depth++;
                FinishReferences(current.LeftChild, depth);
                FinishReferences(current.RightChild, depth);
            }
        }

        /// <summary>
        /// Recursive function that prints the current line and calls itself on the next line if it exists.
        /// </summary>
        /// <param name="start">The starting node</param>
        /// <param name="depth">The current depth to determine the end of the recursive function</param>
        public void PrintTree(Node start, int depth)
        {
            #region Pretty Printing 1
            //int maxSpace = 2 * Depth * Depth + 1;
            //int incr = maxSpace / (depth + 1);
            //for (int i = 0; i < incr; i++)
            //{
            //    Console.Write(" ");
            //}
            #endregion

            // Print the leftmost value at this depth.
            Node current = start;
            Console.Write(current.Value + " ");

            #region Pretty Printing 2
            //for (int i = 0; i < incr; i++)
            //{
            //    Console.Write(" ");
            //}
            #endregion

            // Continue printing until there are no more nodes to the right.
            while (current.RightNeighbor != null)
            {
                current = current.RightNeighbor;
                Console.Write(current.Value + " ");
            }

            // Print next line if it exists
            if (depth < Depth)
            {
                depth++;
                Console.WriteLine();
                PrintTree(start.LeftChild, depth);
            }
        }
        #endregion
    }
}
