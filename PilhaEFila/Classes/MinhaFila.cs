using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PilhaEFila.Interfaces;

namespace PilhaEFila.Classes
{
    public class MinhaFila<T> : IQueueOperations<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Enqueue(T item) => _items.Add(item);

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Fila vazia");
            var item = _items[0];
            _items.RemoveAt(0);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Fila vazia");
            return _items[0];
        }

        public int Count => _items.Count;

        public bool IsEmpty() => _items.Count == 0;
    }
}
