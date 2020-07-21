using System.Collections.Generic;

namespace PracticingAlgorithmsAndDataStructures.BinarySearchTree
{
    public class BSTIterator
    {
        private Stack<TreeNode> _stack = new Stack<TreeNode>();

        public BSTIterator(TreeNode root)
        {
            while (root != null)
            {
                this._stack.Push(root);
                root = root.left;
            }
        }

        /** @return the next smallest number */
        public int Next()
        {
            if (this._stack.Count == 0)
            {
                throw new System.Exception("All elements already have been traversed");
            }

            TreeNode targetNode = this._stack.Pop();
            TreeNode nodeToBeAdded = targetNode.right;

            while (nodeToBeAdded != null)
            {
                _stack.Push(nodeToBeAdded);
                nodeToBeAdded = nodeToBeAdded.left;
            }

            return targetNode.val;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return this._stack.Count > 0;
        }
    }
}
