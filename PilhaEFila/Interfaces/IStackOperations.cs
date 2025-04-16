using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PilhaEFila.Interfaces
{
    public interface IStackOperations<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        int Count { get; }
        bool IsEmpty();
    }
}
