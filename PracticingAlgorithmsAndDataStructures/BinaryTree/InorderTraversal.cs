using System.Collections.Generic;

namespace PracticingAlgorithmsAndDataStructures.BinaryTree
{
    public class InorderTraversal
    {
        private IList<int> result = new List<int>();

        public IList<int> TraverseByRecursion(TreeNode root)
        {
            this.VisitNode(root);
            return this.result;
        }

        private void VisitNode(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            this.VisitNode(node.left);
            this.result.Add(node.val);
            this.VisitNode(node.right);
        }

        public IList<int> TraverseByIterations(TreeNode root)
        {
            this.VisitNode(root);
            IList<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                result.Add(root.val);

                root = root.right;
            }

            return result;
        }
    }
}
