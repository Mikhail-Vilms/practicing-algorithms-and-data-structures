using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticingAlgorithmsAndDataStructures.Backtracking
{
    public class CombinationSumSoluitonII
    {
        private IList<IList<int>> res = new List<IList<int>>();
        private int[] arr;
        private int length;
        private Stack<int> stack = new Stack<int>();

        public IList<IList<int>> FindAllCombinations(int[] candidates, int target)
        {
            Array.Sort(candidates);
            this.arr = candidates;
            this.length = candidates.Length;

            OnNextStep(0, target);

            return this.res;
        }

        // Add one element for final set on every step of recursion
        // Element should be chosen from right part of array - elements that were not used yet (We need only unique combinations)
        // After considering all options with element 
        private void OnNextStep(int indx, int sum)
        {
            // base case - current sum doesn't match target sum.
            if (sum < 0)
            {
                return;
            }

            // base case - one of the combinaitons we need to find.
            if (sum == 0)
            {
                res.Add(stack.ToList());
                return;
            }

            // Add one element from set of available ones - those we didn't considered so far. 
            for (int i = indx; i < length; i++)
            {
                // skip duplicate elements
                if (i != indx && arr[i] == arr[i - 1])
                {
                    continue;
                }

                this.stack.Push(this.arr[i]);
                this.OnNextStep(i + 1, sum - arr[i]);
                this.stack.Pop();
            }
        }
    }
}
