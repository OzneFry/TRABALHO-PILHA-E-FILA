using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PilhaEFila.Classes;
using PilhaEFila.Interfaces;

namespace PilhaEFila.Exercicios
{
    public static class ExerciciosDificeis
    {
        public static void Exercicio15()
        {
            Console.WriteLine("\n\nExercício 15: Estacionamento com pilha");
            IStackOperations<string> estacionamento = new MinhaPilha<string>();
            IStackOperations<string> temp = new MinhaPilha<string>();
            int capacidade = 5;

            while (true)
            {
                Console.WriteLine("\n1 - Estacionar carro");
                Console.WriteLine("2 - Retirar carro");
                Console.WriteLine("3 - Ver estacionamento");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (estacionamento.Count >= capacidade)
                        {
                            Console.WriteLine("Estacionamento cheio!");
                            break;
                        }
                        Console.Write("Placa do carro: ");
                        estacionamento.Push(Console.ReadLine());
                        Console.WriteLine("Carro estacionado!");
                        break;
                    case "2":
                        Console.Write("Placa do carro a retirar: ");
                        string placa = Console.ReadLine();
                        bool encontrado = false;

                        while (!estacionamento.IsEmpty())
                        {
                            string carro = estacionamento.Pop();
                            if (carro == placa)
                            {
                                Console.WriteLine($"Carro {placa} retirado!");
                                encontrado = true;
                                break;
                            }
                            temp.Push(carro);
                        }
                        
                        while (!temp.IsEmpty())
                            estacionamento.Push(temp.Pop());

                        if (!encontrado)
                            Console.WriteLine("Carro não encontrado!");
                        break;
                    case "3":
                        Console.WriteLine("Carros no estacionamento (do último ao primeiro):");
                        foreach (var carro in ((MinhaPilha<string>)estacionamento)._items)
                            Console.WriteLine(carro);
                        break;
                    case "4":
                        return;
                }
            }
        }

        public class Deque<T> : IQueueOperations<T>
        {
            private readonly List<T> _items = new List<T>();

            public void Enqueue(T item) => _items.Add(item);

            public T Dequeue() => RemoveAt(0);

            public T Peek() => _items[0];

            public void EnqueueFront(T item) => _items.Insert(0, item);

            public T DequeueBack() => RemoveAt(_items.Count - 1);

            public T PeekBack() => _items[^1];

            private T RemoveAt(int index)
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Deque vazio");
                T item = _items[index];
                _items.RemoveAt(index);
                return item;
            }

            public int Count => _items.Count;

            public bool IsEmpty() => _items.Count == 0;
        }

        public static void Exercicio16()
        {
            Console.WriteLine("\nExercício 16: Deque (Fila Dupla)");
            var deque = new Deque<int>();

            deque.Enqueue(1);
            deque.Enqueue(2);
            deque.EnqueueFront(3);
            deque.Enqueue(4);

            Console.WriteLine($"DequeueFront: {deque.Dequeue()}");
            Console.WriteLine($"DequeueBack: {deque.DequeueBack()}");
            Console.WriteLine($"PeekFront: {deque.Peek()}");
            Console.WriteLine($"PeekBack: {deque.PeekBack()}");
        }

        public class Documento
        {
            public string Nome { get; }
            public int Prioridade { get; }

            public Documento(string nome, int prioridade)
            {
                Nome = nome;
                Prioridade = prioridade;
            }
        }

        public class GerenciadorImpressao
        {
            private readonly PriorityQueue<Documento, int> _filaPrioridade = new();

            public void AdicionarDocumento(Documento doc) =>
                _filaPrioridade.Enqueue(doc, doc.Prioridade);

            public Documento ImprimirProximo() => _filaPrioridade.Dequeue();

            public bool TemDocumentos() => _filaPrioridade.Count > 0;
        }

        public static void Exercicio17()
        {
            Console.WriteLine("\n\nExercício 17: Sistema de impressão com prioridade");
            var gerenciador = new GerenciadorImpressao();

            gerenciador.AdicionarDocumento(new Documento("Doc1", 2));
            gerenciador.AdicionarDocumento(new Documento("Doc2", 1));
            gerenciador.AdicionarDocumento(new Documento("Doc3", 3));
            gerenciador.AdicionarDocumento(new Documento("Doc4", 1));

            Console.WriteLine("Imprimindo documentos por prioridade:");
            while (gerenciador.TemDocumentos())
            {
                var doc = gerenciador.ImprimirProximo();
                Console.WriteLine($"{doc.Nome} (Prioridade: {doc.Prioridade})");
            }
        }

        public static void Exercicio18()
        {
            Console.WriteLine("\nExercício 18: Resolver expressões pós-fixadas");
            Console.Write("Digite a expressão pós-fixada (ex: '3 4 + 2 *'): ");
            string expressao = Console.ReadLine();

            IStackOperations<double> pilha = new MinhaPilha<double>();
            string[] tokens = expressao.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double numero))
                {
                    pilha.Push(numero);
                }
                else
                {
                    double b = pilha.Pop();
                    double a = pilha.Pop();

                    switch (token)
                    {
                        case "+":
                            pilha.Push(a + b);
                            break;
                        case "-":
                            pilha.Push(a - b);
                            break;
                        case "*":
                            pilha.Push(a * b);
                            break;
                        case "/":
                            pilha.Push(a / b);
                            break;
                        default:
                            throw new ArgumentException($"Operador inválido: {token}");
                    }
                }
            }

            Console.WriteLine($"Resultado: {pilha.Pop()}");
        }

        public class EditorTexto
        {
            private IStackOperations<string> _undoStack = new MinhaPilha<string>();
            private IStackOperations<string> _redoStack = new MinhaPilha<string>();
            private string _textoAtual = "";

            public void Digitar(string texto)
            {
                _undoStack.Push(_textoAtual);
                _textoAtual += texto;
                _redoStack = new MinhaPilha<string>();
            }

            public void Undo()
            {
                if (_undoStack.IsEmpty())
                    return;
                _redoStack.Push(_textoAtual);
                _textoAtual = _undoStack.Pop();
            }

            public void Redo()
            {
                if (_redoStack.IsEmpty())
                    return;
                _undoStack.Push(_textoAtual);
                _textoAtual = _redoStack.Pop();
            }

            public string GetTexto() => _textoAtual;
        }

        public static void Exercicio19()
        {
            Console.WriteLine("\n\nExercício 19: Undo/Redo com duas pilhas");
            var editor = new EditorTexto();

            editor.Digitar("Hello");
            Console.WriteLine($"Texto: {editor.GetTexto()}");

            editor.Digitar(" World");
            Console.WriteLine($"Texto: {editor.GetTexto()}");

            editor.Undo();
            Console.WriteLine($"Undo: {editor.GetTexto()}");

            editor.Redo();
            Console.WriteLine($"Redo: {editor.GetTexto()}");
        }

        public class LRUCache<TKey, TValue>
        {
            private readonly int _capacidade;
            private readonly Dictionary<TKey, TValue> _cache = new Dictionary<TKey, TValue>();
            private readonly Queue<TKey> _filaAcesso = new Queue<TKey>();

            public LRUCache(int capacidade)
            {
                _capacidade = capacidade;
            }

            public TValue Get(TKey key)
            {
                if (!_cache.ContainsKey(key))
                    throw new KeyNotFoundException();

                _filaAcesso.Enqueue(key);
                return _cache[key];
            }

            public void Put(TKey key, TValue value)
            {
                if (_cache.Count >= _capacidade && !_cache.ContainsKey(key))
                {
                    TKey lruKey = _filaAcesso.Dequeue();
                    while (!_cache.ContainsKey(lruKey))
                        lruKey = _filaAcesso.Dequeue();
                    _cache.Remove(lruKey);
                }

                _cache[key] = value;
                _filaAcesso.Enqueue(key);
            }
        }

        public static void Exercicio20()
        {
            Console.WriteLine("\nExercício 20: LRU Cache");
            var cache = new LRUCache<int, string>(3);

            cache.Put(1, "A");
            cache.Put(2, "B");
            cache.Put(3, "C");

            Console.WriteLine($"Get(1): {cache.Get(1)}"); // A
            cache.Put(4, "D");

            try
            {
                Console.WriteLine($"Get(2): {cache.Get(2)}");
            }
            catch
            {
                Console.WriteLine("Get(2): Key not found (como esperado)");
            }
        }
    }
}
