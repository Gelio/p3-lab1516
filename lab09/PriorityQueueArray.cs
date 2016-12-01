using System;

namespace Lab9
{
    class MinPriorityQueueArray<T> : IPriorityQueue<T> where T: struct, IComparable<T>
    {
        public MinPriorityQueueArray()
        {
            queue = new T[4];
            existingElements = 0;
        }

        public int Size
        {
            get
            {
                return existingElements;
            }
        }

        public void Put(T element)
        {
            if (Size == queue.Length)
            {
                T[] resizedQueue = new T[queue.Length * 2];
                for (int i = 0; i < Size; i++)
                    resizedQueue[i] = queue[i];
                queue = resizedQueue;
            }

            queue[Size] = element;
            existingElements++;
        }

        public T Get()
        {
            if (Size == 0)
                throw new Exception("Pusta kolejka");

            int smallestElementIndex = 0;
            for (int i=1; i < Size; i++)
            {
                if (queue[i].CompareTo(queue[smallestElementIndex]) < 0)
                    smallestElementIndex = i;
                    
            }

            T smallestElement = queue[smallestElementIndex];
            queue[smallestElementIndex] = queue[Size - 1];
            existingElements--;
            return smallestElement;
        }

        public object Clone()
        {
            var clonedQueue = new MinPriorityQueueArray<T>();
            for (int i = 0; i < Size; i++)
                clonedQueue.Put(queue[i]);

            return clonedQueue;
        }

        private T[] queue;
        private int existingElements;
    }
}
