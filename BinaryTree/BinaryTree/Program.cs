namespace BinaryTree
{
    /// <summary>
    /// Author: Dante Nardo
    /// Last Modified: 11/28/2017
    /// Purpose: Creates a binary tree object, populates the tree, and then prints the tree.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Tree binaryTree = new Tree();
            binaryTree.CreateTree(4);
            binaryTree.PrintTree(binaryTree.Root, binaryTree.Depth);
        }
    }
}
