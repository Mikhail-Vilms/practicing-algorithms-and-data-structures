namespace PracticingAlgorithmsAndDataStructures.DynamicProgramming
{
    public class MaximumSubarrayPlainRecursionSolution
    {
        private int[] A;

        public int MaxSubArray(int[] nums)
        {
            A = nums;
            return DP(A.Length - 1);
        }

        // this method returns solution for array that 
        // starts at beginning and has length indx
        private int DP(int indx)
        {
            // base case: if we consider only one first element, then
            // we have no choice but to select it as an answer
            if (indx == 0)
            {
                return A[0];
            }

            // option 1: consider array that just adds current element to it
            int option1 = DP(indx - 1) + A[indx];
            // option 2: 
            int option2 = A[indx];

            // return maximum of these two values
            return option1 > option2 ? option1 : option2;
        }
    }
}
