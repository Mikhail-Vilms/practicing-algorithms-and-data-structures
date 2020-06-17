namespace PracticingAlgorithmsAndDataStructures.BinaryTree
{
    public class DeleteLeavesWithGivenValue
    {
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (root == null || (root.left == null && root.right == null && root.val == target))
            {
                return null;
            }

            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);

            // if after processing root has become leaf and its value is equal to target
            if ((root.left == null && root.right == null && root.val == target))
            {
                return null;
            }
            return root;
        }
    }
}
