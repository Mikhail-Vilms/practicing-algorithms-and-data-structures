using System.Collections.Generic;
using System.Linq;

namespace PracticingAlgorithmsAndDataStructures.Backtracking
{
    public class CombinationSumSolution
    {
        private IList<IList<int>> res = new List<IList<int>>();
        private Stack<int> stack = new Stack<int>();
        private int[] arr;
        private int length;

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            arr = candidates;
            length = candidates.Length;

            OnNextStep(target, 0);

            return res;
        }

        // On every step we add one of the elements that are availabe from array
        // "available" means elements that were not considering for adding to result combination before
        private void OnNextStep(int sum, int indx)
        {
            // base case: if sum < 0 we failed to compose combination with target sum
            if (sum < 0)
            {
                return;
            }

            // base case: if sum = 0  - we found one of the target combinations
            if (sum == 0)
            {
                res.Add(stack.ToList());
            }

            // try to add every available element from array to final combination 
            for (int i = indx; i < length; i++)
            {
                stack.Push(arr[i]);
                OnNextStep(sum - arr[i], i);
                stack.Pop();
            }
        }
    }
}
