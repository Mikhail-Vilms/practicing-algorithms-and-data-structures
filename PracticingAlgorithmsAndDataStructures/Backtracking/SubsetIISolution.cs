using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticingAlgorithmsAndDataStructures.Backtracking
{
    public class SubsetIISolution
    {
        private IList<IList<int>> res = new List<IList<int>>();
        private Stack<int> stack = new Stack<int>();
        private int[] nums;
        private int length;

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);

            this.nums = nums;
            length = nums.Length;

            PlaceElement(0);

            return res;
        }

        private void PlaceElement(int indx)
        {
            res.Add(stack.ToList());

            for (int i = indx; i < length; i++)
            {
                if (i != indx && nums[i] == nums[i - 1])
                {
                    continue;
                }

                stack.Push(nums[i]);
                PlaceElement(i + 1);
                stack.Pop();
            }
        }
    }
}
