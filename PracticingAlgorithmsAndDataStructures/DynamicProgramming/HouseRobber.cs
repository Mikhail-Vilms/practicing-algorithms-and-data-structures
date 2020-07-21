namespace PracticingAlgorithmsAndDataStructures.DynamicProgramming
{
    public class HouseRobber
    {
        private int[] nums;

        // + MEMOIZATION
        private int[] memo;

        public int Rob(int[] nums)
        {
            this.nums = nums;

            // + MEMOIZATION
            this.memo = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                this.memo[i] = -1;
            }

            return DP(0, false);
        }

        private int DP(int currIndx, bool needToSkip)
        {
            if (currIndx == this.nums.Length)
            {
                return 0;
            }

            if (needToSkip)
            {
                return DP(currIndx + 1, false);
            }

            // + MEMOIZATION
            if (this.memo[currIndx] != -1)
            {
                return this.memo[currIndx];
            }

            int res1 = nums[currIndx] + DP(currIndx + 1, true);

            int res2 = DP(currIndx + 1, false);

            int res = res1 > res2 ? res1 : res2;

            memo[currIndx] = res; // + MEMOIZATION

            return res;
        }
    }
}
