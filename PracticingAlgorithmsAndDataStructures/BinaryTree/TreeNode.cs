using System;

namespace PracticingAlgorithmsAndDataStructures.BinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public void PrintInorderTraversal()
        {
            if (this.left != null)
            {
                this.left.PrintInorderTraversal();
            }

            Console.Write(this.val + " ");

            if (this.right != null)
            {
                this.right.PrintInorderTraversal();
            }
        }

        public void PrintPreorderTraversal()
        {
            Console.Write(this.val + " ");

            if (this.left != null)
            {
                this.left.PrintPreorderTraversal();
            }

            if (this.right != null)
            {
                this.right.PrintPreorderTraversal();
            }
        }

        public void PrintPostorderTraversal()
        {
            if (this.left != null)
            {
                this.left.PrintPostorderTraversal();
            }

            if (this.right != null)
            {
                this.right.PrintPostorderTraversal();
            }

            Console.Write(this.val + " ");
        }
    }
}
