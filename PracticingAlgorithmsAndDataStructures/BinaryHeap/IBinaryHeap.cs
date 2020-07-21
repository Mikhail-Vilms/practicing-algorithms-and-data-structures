namespace PracticingAlgorithmsAndDataStructures.BinaryHeap
{
    public interface IBinaryHeap
    {
        public void Add(int item);

        public int Poll();

        public int Peek();

        public int Count();
    }
}
