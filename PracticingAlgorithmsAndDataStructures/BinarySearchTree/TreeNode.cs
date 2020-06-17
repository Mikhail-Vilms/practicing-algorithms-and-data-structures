using System;

namespace PracticingAlgorithmsAndDataStructures.BinarySearchTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        
        public TreeNode(int val = 0)
        {
            this.val = val;
        }
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            : this(val)
        {
            this.left = left;
            this.right = right;
        }

        public void Insert(int val)
        {
            if (this == null)
            {
                return;
            }

            if (this.val > val)
            {
                if (this.left == null)
                {
                    this.left = new TreeNode(val);
                }
                else
                {
                    this.left.Insert(val);
                }
            }

            if (this.val < val)
            {
                if (this.right == null)
                {
                    this.right = new TreeNode(val);
                }
                else
                {
                    this.right.Insert(val);
                }
            }
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
