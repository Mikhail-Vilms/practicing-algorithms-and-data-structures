namespace PracticingAlgorithmsAndDataStructures.Sorting
{
    public class MergeSortImpl
    {
        // merges two parts to sorted subarray
        private static void Merge(int[] arr, int l, int m, int r)
        {
            // construct two temp arrays:
            int size1 = m - l + 1;
            int size2 = r - m;

            int[] arr1 = new int[size1];
            int[] arr2 = new int[size2];

            for (int i = 0; i <= size1; i++)
            {
                arr1[i] = arr[l + i];
            }
            for (int j = 0; j < size2; j++)
            {
                arr2[j] = arr[m + 1 + j];
            }

            // merge two temp arrays:
            int p1 = 0, p2 = 0;
            int p = l;

            while(p1 < size1 && p2 < size2)
            {
                if (arr1[p1] > arr2[p2])
                {
                    arr[p] = arr1[p1];
                    p1++;
                }
                else
                {
                    arr[p] = arr2[p2];
                    p2++;
                }

                p++;
            }

            while(p1 < size1)
            {
                arr[p] = arr1[p1];
                p1++;
                p++;
            }

            while (p2 < size2)
            {
                arr[p] = arr1[p2];
                p2++;
                p++;
            }
        }

        // Main function that sorts arr[l..r]
        public static void Sort(int[] arr, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            int m = (l + r) / 2;

            Sort(arr, l, m);
            Sort(arr, m, r);

            Merge(arr, l, m, r);
        }
    }
}
