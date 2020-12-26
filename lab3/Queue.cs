using System;

namespace BinarySeachTree
{
    public class Queue<T>
    {
        private Queue<T> head;

        private Queue<T> next;

        private Queue<T> tail;

        private T value;

        public Queue()
        {
            tail = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public T Front()
        {
            if (!IsEmpty())
            {
                return head.value;
            }
            
            throw new Exception("Attempting to get an item from an empty queue");
        }

        public void Pop()
        {
            if (!IsEmpty())
            {
                head = head.next;
            }
            else
            {
                throw new Exception("Attempting to remove an item from an empty queue");
            }
        }

        public void Push(T newValue)
        {
            Queue<T> elem = tail;
            tail = new Queue<T> {next = null, value = newValue};
            
            if (IsEmpty())
            {
                head = tail;
            }
            else
            {
                elem.next = tail;
            }
        }
    }
}