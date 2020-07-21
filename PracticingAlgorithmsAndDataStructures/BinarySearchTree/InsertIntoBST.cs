namespace PracticingAlgorithmsAndDataStructures.BinarySearchTree
{
    public class InsertIntoBST
    {
        public static TreeNode Insert(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }

            if (root.val > val)
            {
                if (root.left == null)
                {
                    root.left = new TreeNode(val);
                }
                else
                {
                    root.left = Insert(root.left, val);
                }
            }

            if (root.val < val)
            {
                if (root.right == null)
                {
                    root.right = new TreeNode(val);
                }
                else
                {
                    root.right = Insert(root.right, val);
                }
            }

            return root;
        }
    }
}
