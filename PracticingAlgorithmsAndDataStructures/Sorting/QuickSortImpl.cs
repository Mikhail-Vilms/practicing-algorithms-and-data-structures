namespace PracticingAlgorithmsAndDataStructures.Sorting
{
    public class QuickSortImpl
    {
        // swaps two elements in array
        static void Swap(int[] array, int indx1, int indx2)
        {
            if (indx1 == indx2)
            {
                return;
            }

            int temp = array[indx1];
            array[indx1] = array[indx2];
            array[indx2] = temp;
        }

        // partitioning of array using rightmost element as pivot
        static private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int tail = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    tail++;
                    Swap(array, tail, j);
                }

            }

            Swap(array, tail + 1, high);

            return tail + 1;
        }

        public static void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                // _pi is partitioning index, array[_pi] is now at right place
                int _pi = Partition(array, low, high);

                // Recursively sort elements before partition and after partition
                Sort(array, low, _pi - 1);
                Sort(array, low, _pi - 1);
            }
        }
    }
}
