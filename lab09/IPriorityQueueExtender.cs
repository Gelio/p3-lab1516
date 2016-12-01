using System;

namespace Lab9
{
    static class IPriorityQueueExtender
    {
        static public T[] ToSortedArray<T>(this IPriorityQueue<T> queue) where T : struct, IComparable<T>
        {
            IPriorityQueue<T> clonedQueue = (IPriorityQueue<T>)queue.Clone();
            int elementsCount = clonedQueue.Size;
            T[] sortedArray = new T[elementsCount];

            for (int i = 0; i < elementsCount; i++)
                sortedArray[i] = clonedQueue.Get();

            return sortedArray;
        }
    }
}
