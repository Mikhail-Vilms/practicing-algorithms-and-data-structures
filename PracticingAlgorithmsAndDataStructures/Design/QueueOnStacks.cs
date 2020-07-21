using System.Collections.Generic;

namespace PracticingAlgorithmsAndDataStructures.Design
{
    public class QueueOnStacks<T>
    {
        private Stack<T> _stack1;
        private Stack<T> _stack2;
        private T _top;

        QueueOnStacks()
        {
            this._stack1 = new Stack<T>();
            this._stack2 = new Stack<T>();
        }

        public void Enqueue(T item)
        {
            if (_stack1.Count == 0)
            {
                _top = item;
            }

            _stack1.Push(item);
        }

        public T Dequeue()
        {
            if (_stack2.Count == 0)
            {
                while(_stack1.Count > 0)
                {
                    _stack2.Push(_stack1.Pop());
                }
            }

            return _stack2.Pop();
        }

        public T Peek()
        {
            if (_stack2.Count == 0)
            {
                return _top;
            }

            return _stack2.Peek();
        }

        public bool IsEmpty()
        {
            return _stack1.Count == 0 && _stack2.Count == 0;
        }
    }
}
