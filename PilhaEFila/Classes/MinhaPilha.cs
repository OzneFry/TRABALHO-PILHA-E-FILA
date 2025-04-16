using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PilhaEFila.Interfaces;

namespace PilhaEFila.Classes
{
    public class MinhaPilha<T> : IStackOperations<T>
    {
        public readonly List<T> _items = new List<T>();

        public void Push(T item) => _items.Add(item);

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Pilha vazia");
            var item = _items[^1];
            _items.RemoveAt(_items.Count - 1);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Pilha vazia");
            return _items[^1];
        }

        public int Count => _items.Count;

        public bool IsEmpty() => _items.Count == 0;
    }
}
