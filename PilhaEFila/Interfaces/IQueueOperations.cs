using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PilhaEFila.Interfaces
{
    public interface IQueueOperations<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
        int Count { get; }
        bool IsEmpty();
    }
}
