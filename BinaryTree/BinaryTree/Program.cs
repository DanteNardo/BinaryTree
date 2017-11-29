using System;

namespace BinaryTree
{
    /// <summary>
    /// Author: Dante Nardo
    /// Last Modified: 11/29/2017
    /// Purpose: Creates a binary tree object, populates the tree, and then prints the tree.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Tree binaryTree = new Tree();

            #region INPUT
            int depth;
            Console.Write("Please enter a single integer to determine tree depth: ");
            string s = Console.ReadLine();
            if (Int32.TryParse(s, out depth) == false)
            {
                Console.WriteLine("\nInvalid Integer. Closing program.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
            #endregion
            else
            {
                // Tree creation and printing
                binaryTree.CreateTree(depth);
                binaryTree.PrintTree(binaryTree.Root, 1);
                Console.ReadLine();
            }
        }
    }
}
