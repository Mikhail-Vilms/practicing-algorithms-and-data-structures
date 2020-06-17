namespace PracticingAlgorithmsAndDataStructures.BinarySearchTree
{
    public class DeleteNodeInBST
    {
        public static TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
            {
                return null;
            }

            if (key < root.val)
            {
                root.left = DeleteNode(root.left, key);
            }

            if (key > root.val)
            {
                root.right = DeleteNode(root.right, key);
            }

            if (root.val == key)
            {
                if (root.left == null && root.right == null)
                {
                    return null;
                }

                if (root.left == null)
                {
                    return root.right;
                }

                if (root.right == null)
                {
                    return root.left;
                }

                TreeNode _prev = root;
                TreeNode _newRoot = root.right;

                while (_newRoot.left != null)
                {
                    _prev = _newRoot;
                    _newRoot = _newRoot.left;
                }

                _newRoot.left = root.left;

                if (_newRoot == root.right)
                {
                    return _newRoot;
                }
                else
                {
                    _prev.left = _newRoot.right;
                    _newRoot.right = root.right;
                    return _newRoot;
                }
            }

            return root;
        }
    }
}
