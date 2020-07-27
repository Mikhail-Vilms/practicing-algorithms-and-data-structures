namespace PracticingAlgorithmsAndDataStructures.BinarySearchTree
{
    public class ValidateBinarySearchTreeSolution
    {
        public bool IsValidBST(TreeNode root, int? left = null, int? right = null)
        {
            if (root == null)
            {
                return true;
            }

            if (left != null && root.val <= left)
            {
                return false;
            }

            if (right != null && root.val >= right)
            {
                return false;
            }

            if (!IsValidBST(root.left, left, root.val))
            {
                return false;
            }

            if (!IsValidBST(root.right, root.val, right))
            {
                return false;
            }

            return true;
        }
    }
}
