using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingAlgorithmsAndDataStructures.BinaryHeap
{
    public class PriorityQueueImpl<T> 
    {
        #region Fields

        private const int DEFAULT_INITIAL_CAPACITY = 11;

        private T[] _arr;

        private int _size;

        private readonly IComparer<T> _comparer;

        #endregion Fields

        #region Constructors

        public PriorityQueueImpl()
            : this(DEFAULT_INITIAL_CAPACITY, null)
        {
        }

        public PriorityQueueImpl(int capacity)
            : this(capacity, null)
        {
        }

        public PriorityQueueImpl(IComparer<T> comparer)
            : this(DEFAULT_INITIAL_CAPACITY, comparer)
        {
        }

        public PriorityQueueImpl(int capacity,
                     IComparer<T> comparer)
        {
            if (capacity < 1)
                throw new ArgumentException();

            _arr = new T[capacity];

            if (comparer == null)
            {
                _comparer = Comparer<T>.Default;
            } else
            {
                _comparer = comparer;
            }
            
        }

        #endregion Constructors

        #region Private Methods

        private int GetParentIndex(int indx)
        {
            return (indx - 1) / 2;
        }

        private int GetLeftChildIndx(int indx)
        {
            return indx * 2 + 1;
        }

        private int GetRightChildIndx(int indx)
        {
            return indx * 2 + 2;
        }

        private bool HasParent(int indx)
        {
            return GetParentIndex(indx) >= 0;
        }

        private bool HasLeftChild(int indx)
        {
            return GetLeftChildIndx(indx) < _size;
        }

        private bool HasRightChild(int indx)
        {
            return GetRightChildIndx(indx) < _size;
        }

        private T Parent(int indx)
        {
            return _arr[GetParentIndex(indx)];
        }

        private T LeftChild(int indx)
        {
            return _arr[GetLeftChildIndx(indx)];
        }

        private T RightChild(int indx)
        {
            return _arr[GetRightChildIndx(indx)];
        }

        private void Swap(int indx1, int indx2)
        {
            T temp = _arr[indx1];
            _arr[indx1] = _arr[indx2];
            _arr[indx2] = temp;
        }

        private void HeapifyUp()
        {
            int indx = _size - 1;
            while (HasParent(indx) && 
                _comparer.Compare(_arr[indx], Parent(indx)) > 0)
            {
                Swap(GetParentIndex(indx), indx);
                indx = GetParentIndex(indx);
            }
        }

        private void HeapifyDown()
        {
            int indx = 0;

            while (HasLeftChild(indx))
            {
                int biggerChildIndx = GetLeftChildIndx(indx);
                if (HasRightChild(indx) 
                    && _comparer.Compare(RightChild(indx), LeftChild(indx)) > 0)
                {
                    biggerChildIndx = GetRightChildIndx(indx);
                }

                if (_comparer.Compare(_arr[biggerChildIndx], _arr[indx]) < 0)
                {
                    break;
                }

                Swap(indx, biggerChildIndx);

                indx = biggerChildIndx;
            }
        }

        private void EnsureExtraCapacity()
        {
            if (_size < _arr.Length)
            {
                return;
            }

            Array.Resize(ref _arr, _arr.Length * 2);
        }

        #endregion Private Methods

        #region Public Methods

        public int Count
        {
            get { return _size; }
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }

            return _arr[0];
        }

        public void Add(T item)
        {
            EnsureExtraCapacity();

            _arr[_size] = item;
            _size++;

            HeapifyUp();
        }

        public T Poll()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }

            T item = _arr[0];

            _arr[0] = _arr[_size - 1];
            _size--;

            HeapifyDown();

            return item;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Heap elements: { ");

            int indx = 0;
            while (indx < _size)
            {
                sb.Append(_arr[indx].ToString() + "; ");
                indx++;
            }

            sb.Append("}");

            return sb.ToString();
        }

        #endregion Public Methods
    }
}
