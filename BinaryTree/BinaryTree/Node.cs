namespace BinaryTree
{
    /// <summary>
    /// Author: Dante Nardo
    /// Last Modified: 11/28/2017
    /// Purpose: Acts as a single node in a binary tree. Holds data that creates tree hierarchy.
    /// </summary>
    class Node
    {
        #region Node Members
        public Node Parent          { get; set; }           // The parent node in the binary tree.
        public Node LeftChild       { get; set; }           // The left child node in the binary tree.
        public Node RightChild      { get; set; }           // The right child node in the binary tree.
        public bool Left            { get; set; }           // If Left is true then this node is left, otherwise it is right.
        public int Value            { get; private set; }   // The value of the node at this location in the tree

        // The node directly to the left on this depth level
        // Finds the left neighbor if it is null
        private Node m_leftNeighbor;
        public Node LeftNeighbor
        {
            get
            {
                if (m_leftNeighbor != null)
                {
                    return m_leftNeighbor;
                }
                else
                {
                    // Finds the left neighbor if it does not currently exist
                    // Recalculates value if necessary
                    if (Parent != null &&
                        Parent.LeftNeighbor != null &&
                        Parent.LeftNeighbor.RightChild != null)
                    {
                        m_leftNeighbor = Parent.LeftNeighbor.RightChild;
                        m_leftNeighbor.CalculateValue();
                        CalculateValue();
                    }
                    return m_leftNeighbor;
                }
            }
            set
            {
                m_leftNeighbor = value;
            }
        }

        // The node directly to the right on this depth level
        // Finds the right neighbor if it is null
        private Node m_rightNeighbor;
        public Node RightNeighbor
        {
            get
            {
                if (m_rightNeighbor != null)
                {
                    return m_rightNeighbor;
                }
                // Finds the right neighbor if it does not currently exist
                // Recalculates value if necessary
                else
                {
                    if (Parent != null &&
                        Parent.RightNeighbor != null &&
                        Parent.RightNeighbor.LeftChild != null)
                    {
                        m_rightNeighbor = Parent.RightNeighbor.LeftChild;
                        m_rightNeighbor.CalculateValue();
                        CalculateValue();
                    }
                    return m_rightNeighbor;
                }
            }
            set
            {
                m_rightNeighbor = value;
            }
        }
        #endregion

        #region Node Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public Node()
        {
            Parent = null;
            LeftChild = null;
            RightChild = null;
            LeftNeighbor = null;
            Left = true;
            Value = -1;
        }

        /// <summary>
        /// Determines value based off of whether or not this node
        /// is the Root, a left node, or a right node.
        /// </summary>
        public void CalculateValue()
        {
            // Root node always has value 1
            if (IsRoot())
            {
                Value = 1;
                return;
            }

            if (Left)
            {
                // Left children have a value equal to the sum of their parent and its left neighbor
                // If there is no left neighbor, then the child's value is the same as the parent
                if (Parent.LeftNeighbor == null)
                {
                    Value = Parent.Value;
                }
                else
                {
                    Value = Parent.Value + Parent.LeftNeighbor.Value;
                }
            }
            else
            {
                // Right children have a value equal to the sum of their parent and its right neighbor
                // If there is no right neighbor, then the child's value is the same as the parent
                if (Parent.RightNeighbor == null)
                {
                    Value = Parent.Value;
                }
                else
                {
                    Value = Parent.Value + Parent.RightNeighbor.Value;
                }
            }
        }

        /// <summary>
        /// The root node is at the top of the tree.
        /// If we reach the root node we know to go back down while searching.
        /// </summary>
        /// <returns>Whether or not this node is at the top of the tree.</returns>
        public bool IsRoot()
        {
            // If Parent is null we are at the top of the tree because only root doesn't have parent.
            return Parent == null;
        }

        /// <summary>
        /// Leaf nodes are nodes at the bottom of the tree.
        /// If we reach a leaf node we know to go back up while searching.
        /// </summary>
        /// <returns>Whether or not this node is at the bottom of the tree.</returns>
        public bool IsLeaf()
        {
            // If LeftChild is null, RightChild is null, and we are at the bottom of the tree.
            return LeftChild == null;
        }
        #endregion
    }
}
