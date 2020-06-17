namespace PracticingAlgorithmsAndDataStructures.BinaryTree
{
    public class MaximumBinaryTree
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return this.GetRoot(nums, 0, nums.Length - 1);
        }

        private TreeNode GetRoot(int[] nums, int start, int end)
        {
            // 1st base case
            if (start > end)
            {
                return null;
            }

            // 2nd base case
            if (start == end)
            {
                return new TreeNode()
                {
                    val = nums[start]
                };
            }

            // building new node with value being max from remaining array
            int maxIndx = this.GetMaxIndx(nums, start, end);

            TreeNode root = new TreeNode()
            {
                val = nums[maxIndx]
            };

            root.left = GetRoot(nums, start, maxIndx - 1);
            root.right = GetRoot(nums, maxIndx + 1, end);

            return root;
        }

        // Returns max value from remaining elements of array
        private int GetMaxIndx(int[] nums, int start, int end)
        {
            int indx = start;

            for (int i = start; i <= end; i++)
            {
                if (nums[i] > nums[indx])
                {
                    indx = i;
                }
            }

            return indx;
        }
    }
}
