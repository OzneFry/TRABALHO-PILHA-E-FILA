using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PilhaEFila.Classes;
using PilhaEFila.Interfaces;

namespace PilhaEFila.Exercicios
{
    public static class ExerciciosMedios
    {
        public static void Exercicio8()
        {
            Console.WriteLine("\nExercício 8: Verificar parênteses balanceados");
            Console.Write("Digite a sequência de parênteses: ");
            string input = Console.ReadLine();

            IStackOperations<char> pilha = new MinhaPilha<char>();
            bool balanceado = true;

            foreach (char c in input)
            {
                if (c == '(')
                    pilha.Push(c);
                else if (c == ')')
                {
                    if (pilha.IsEmpty() || pilha.Pop() != '(')
                    {
                        balanceado = false;
                        break;
                    }
                }
            }

            if (!pilha.IsEmpty())
                balanceado = false;
            Console.WriteLine($"A sequência está {(balanceado ? "balanceada" : "desbalanceada")}");
        }

        public static void Exercicio9()
        {
            Console.WriteLine("\nExercício 9: Inverter fila com pilha");
            IQueueOperations<int> fila = new MinhaFila<int>();
            IStackOperations<int> pilha = new MinhaPilha<int>();

            // Preenche a fila
            for (int i = 1; i <= 5; i++)
                fila.Enqueue(i);

            // Transfere para pilha
            while (!fila.IsEmpty())
                pilha.Push(fila.Dequeue());

            // Devolve para fila (invertido)
            while (!pilha.IsEmpty())
                fila.Enqueue(pilha.Pop());

            Console.WriteLine("Fila invertida:");
            while (!fila.IsEmpty())
                Console.Write(fila.Dequeue() + " ");
        }

        // Exercício 10 já implementada na estrutura base
        // Exercício 11  já implementada na estrutura base

        public static void Exercicio12()
        {
            Console.WriteLine("\n\nExercício 12: Converter decimal para binário");
            Console.Write("Digite um número decimal: ");
            int decimalNumber = int.Parse(Console.ReadLine());

            IStackOperations<int> pilha = new MinhaPilha<int>();
            int num = decimalNumber;

            if (num == 0)
                pilha.Push(0);

            while (num > 0)
            {
                pilha.Push(num % 2);
                num /= 2;
            }

            Console.Write($"Binário: ");
            while (!pilha.IsEmpty())
                Console.Write(pilha.Pop());
        }

        public class FilaCircular<T> : IQueueOperations<T>
        {
            private readonly T[] _items;
            private int _front = -1;
            private int _rear = -1;
            private int _count = 0;

            public FilaCircular(int capacity)
            {
                _items = new T[capacity];
            }

            public void Enqueue(T item)
            {
                if (_count == _items.Length)
                    throw new InvalidOperationException("Fila cheia");

                _rear = (_rear + 1) % _items.Length;
                _items[_rear] = item;
                _count++;

                if (_front == -1)
                    _front = _rear;
            }

            public T Dequeue()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Fila vazia");

                T item = _items[_front];
                _items[_front] = default;
                _front = (_front + 1) % _items.Length;
                _count--;

                if (_count == 0)
                {
                    _front = -1;
                    _rear = -1;
                }

                return item;
            }

            public T Peek()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Fila vazia");

                return _items[_front];
            }

            public int Count => _count;

            public bool IsEmpty() => _count == 0;
        }

        public static void Exercicio13()
        {
            Console.WriteLine("\n\nExercício 13: Fila circular");
            var filaCircular = new FilaCircular<int>(3);

            filaCircular.Enqueue(1);
            filaCircular.Enqueue(2);
            filaCircular.Enqueue(3);

            Console.WriteLine($"Dequeue: {filaCircular.Dequeue()}");

            filaCircular.Enqueue(4);

            Console.WriteLine("Itens na fila circular:");
            while (!filaCircular.IsEmpty())
                Console.Write(filaCircular.Dequeue() + " ");
        }

        public class FilaPrioridade<T>
            where T : IComparable<T>
        {
            private readonly List<T> _items = new List<T>();

            public void Enqueue(T item)
            {
                _items.Add(item);
                _items.Sort((a, b) => b.CompareTo(a));
            }

            public T Dequeue()
            {
                if (_items.Count == 0)
                    throw new InvalidOperationException("Fila vazia");

                var item = _items[0];
                _items.RemoveAt(0);
                return item;
            }

            public T Peek()
            {
                if (_items.Count == 0)
                    throw new InvalidOperationException("Fila vazia");

                return _items[0];
            }

            public int Count => _items.Count;

            public bool IsEmpty() => _items.Count == 0;
        }

        public static void Exercicio14()
        {
            Console.WriteLine("\n\nExercício 14: Fila de prioridade");
            var filaPrioridade = new FilaPrioridade<int>();

            filaPrioridade.Enqueue(3);
            filaPrioridade.Enqueue(1);
            filaPrioridade.Enqueue(5);
            filaPrioridade.Enqueue(2);

            Console.WriteLine("Atendendo por prioridade:");
            while (!filaPrioridade.IsEmpty())
                Console.Write(filaPrioridade.Dequeue() + " ");
        }
    }
}
