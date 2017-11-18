namespace BinaryTree
{
    /// <summary>
    /// Author: Dante Nardo
    /// Last Modified: 11/17/2017
    /// Purpose: Creates a binary tree of integers with a set depth.
    /// </summary>
    class Tree
    {
        #region Tree Members
        public Node Root { get; set; }          // The parent node in the binary tree.
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
            Root = new Node();
            Root.CalculateValue();

            // A recursive function that creates all of the tree branches
            CreateBranches(Root, 1);
            CompleteNodes(Root, 1);
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

            // Recursive end condition: stop creating branches once we've reached the end
            if (depth < Depth-1)
            {
                depth++;
                CreateBranches(current.LeftChild, depth);
                CreateBranches(current.RightChild, depth);
            }
        }

        /// <summary>
        /// We need all of the nodes to be created in order to assign all of their neighbors
        /// and then from there we can determine each node's value.
        /// </summary>
        /// <param name="current">The current node to complete the data for</param>
        /// <param name="depth">The current depth to determine the end of the recursive function</param>
        private void CompleteNodes(Node current, int depth)
        {
            // Do not check the Root since it has no neighbors
            // Do not check the Leaves since their parents calculate their neighbors for them
            if (!current.IsRoot() && !current.IsLeaf())
            {
                // Find left's left neighbor
                if (current.Parent.LeftNeighbor != null &&
                    current.Parent.LeftNeighbor.RightChild != null)
                {
                    current.LeftChild.LeftNeighbor = current.Parent.LeftNeighbor.RightChild;
                }

                // Find right's right neighbor
                if (current.Parent.RightNeighbor != null &&
                    current.Parent.RightNeighbor.LeftChild != null)
                {
                    current.RightChild.RightNeighbor = current.Parent.RightNeighbor.LeftChild;
                }

                // Determine the value for both child nodes
                current.LeftChild.CalculateValue();
                current.RightChild.CalculateValue();
            }

            // Complete their child nodes if we are not at the lowest depth
            if (depth < Depth)
            {
                CompleteNodes(current.LeftChild, ++depth);
                CompleteNodes(current.RightChild, ++depth);
            }
        }
        #endregion
    }
}
