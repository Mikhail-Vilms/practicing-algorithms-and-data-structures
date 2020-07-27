using System;

namespace PracticingAlgorithmsAndDataStructures.DynamicProgramming
{
    public class LongestIncreasingSubsequenceSolution
    {
        private int[] _nums;
        private int[,] _memo; // +MEMO

        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            _nums = nums;

            _memo = new int[nums.Length, nums.Length + 1]; // +MEMO
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j <= nums.Length; j++)
                {
                    _memo[i, j] = -1;
                }
            }

            return FindFor(nums.Length - 1, nums.Length);
        }

        // we starting without next element;
        // "nums.Length" means we don't have next element in subsequence since we don't have any element in it
        // function returns length of the longest increasing subsequence
        private int FindFor(int curr, int next)
        {
            if (curr == 0) // base case: we have only one element to consider for adding to subsequence
            {
                if (next == _nums.Length || _nums[curr] < _nums[next])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            if (_memo[curr, next] != -1) // +MEMO
            {
                return _memo[curr, next];
            }

            int opt1 = FindFor(curr - 1, next); // Skip current element: moving without including current element into subsequence

            int opt2 = 0;                                           // Include current element, if possible: if current is less that next element,
            if (next == _nums.Length || _nums[curr] < _nums[next])  // we can include it into subsequence - that means that from now on new "next"
            {                                                       // is going to be current element;
                opt2 = 1 + FindFor(curr - 1, curr);
            }

            _memo[curr, next] = Math.Max(opt1, opt2); // +MEMO

            return _memo[curr, next];
        }
    }
}
