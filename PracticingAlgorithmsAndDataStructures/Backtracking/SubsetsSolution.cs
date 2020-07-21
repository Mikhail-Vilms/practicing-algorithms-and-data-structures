using System.Collections.Generic;
using System.Linq;

namespace PracticingAlgorithmsAndDataStructures.Backtracking
{
    public class SubsetsSolution
    {
        private IList<IList<int>> res = new List<IList<int>>();
        private Stack<int> stack = new Stack<int>();
        private int[] nums;
        private int length;

        public IList<IList<int>> Subsets(int[] nums)
        {
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
                // adding element to stack
                stack.Push(nums[i]);
                // moving to next element
                PlaceElement(i + 1);
                // delete element from stack (in this case we will just skip current element)
                stack.Pop();
            }
        }
    }
}
