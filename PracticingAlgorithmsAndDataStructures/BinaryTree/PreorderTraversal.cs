using System.Collections.Generic;

namespace PracticingAlgorithmsAndDataStructures.BinaryTree
{
    public class PreorderTraversal
    {
        private IList<int> resultList = new List<int>();

        public IList<int> Traverse(TreeNode root)
        {
            VisitNode(root);
            return resultList;
        }

        private void VisitNode(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            resultList.Add(root.val);
            VisitNode(root.left);
            VisitNode(root.right);
        }
    }
}
