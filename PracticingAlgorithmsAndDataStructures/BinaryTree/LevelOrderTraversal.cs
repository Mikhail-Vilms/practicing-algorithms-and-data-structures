using System.Collections.Generic;

namespace PracticingAlgorithmsAndDataStructures.BinaryTree
{
    public class LevelOrderTraversal
    {
        static public IList<IList<int>> LevelOrder(TreeNode root)
        {
            // list lo integer arrays - values of nodel level by level
            IList<IList<int>> listOfLevels = new List<IList<int>>();

            if (root == null)
            {
                return listOfLevels;
            }

            // first level - just one element - the root of the tree
            List<TreeNode> level = new List<TreeNode>
            {
                root
            };

            // each iteration goes through one level of nodes 
            while (level.Count > 0)
            {
                List<int> listOfInts = new List<int>();
                List<TreeNode> nextLevel = new List<TreeNode>();

                foreach (TreeNode node in level)
                {
                    if (node.left != null)
                    {
                        nextLevel.Add(node.left);
                    }
                    if (node.right != null)
                    {
                        nextLevel.Add(node.right);
                    }
                    listOfInts.Add(node.val);
                }

                listOfLevels.Add(listOfInts);
                level = nextLevel;
            }

            return listOfLevels;
        }
    }
}
