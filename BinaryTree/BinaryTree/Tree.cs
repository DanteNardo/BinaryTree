using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Tree
    {
        #region Tree Members
        public Node Root { get; set; }          // The parent node in the binary tree.
        public int Depth { get; private set; }  // 
        #endregion

        #region Tree Methods
        public Tree()
        {
            
        }
        #endregion
    }
}
