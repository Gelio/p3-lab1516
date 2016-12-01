using System;

namespace Lab9
{
    interface IPriorityQueue<T> : ICloneable where T: struct, IComparable<T>
    {
        int Size {
            get;
        }
        void Put(T element);
        T Get();
    }
}
