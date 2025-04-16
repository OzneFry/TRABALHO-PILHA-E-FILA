using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PilhaEFila.Classes;
using PilhaEFila.Interfaces;

namespace PilhaEFila.Exercicios
{
    public static class ExerciciosFaceis
    {
        public static void Exercicio1()
        {
            Console.WriteLine("\nExercício 1: Criar uma pilha com números 1-5");
            IStackOperations<int> pilha = new MinhaPilha<int>();

            for (int i = 1; i <= 5; i++)
                pilha.Push(i);

            Console.WriteLine("Elementos da pilha (do topo para a base):");
            while (!pilha.IsEmpty())
                Console.Write(pilha.Pop() + " ");
        }

        public static void Exercicio2()
        {
            Console.WriteLine("\n\nExercício 2: Criar uma fila com nomes");
            IQueueOperations<string> fila = new MinhaFila<string>();
            string[] nomes = { "Ana", "Carlos", "Beatriz", "Daniel" };

            foreach (var nome in nomes)
                fila.Enqueue(nome);

            // Remove o primeiro
            fila.Dequeue();

            Console.WriteLine("Elementos restantes na fila:");
            while (!fila.IsEmpty())
                Console.Write(fila.Dequeue() + " ");
        }

        public static void Exercicio3()
        {
            Console.WriteLine("\n\nExercício 3: Verificar pilha vazia");
            IStackOperations<string> pilha = new MinhaPilha<string>();

            Console.WriteLine($"Pilha vazia? {pilha.IsEmpty()}");
            pilha.Push("Item");
            Console.WriteLine($"Pilha vazia após adicionar item? {pilha.IsEmpty()}");
        }

        public static void Exercicio4()
        {
            Console.WriteLine("\nExercício 4: Verificar fila vazia");
            IQueueOperations<string> fila = new MinhaFila<string>();

            Console.WriteLine($"Fila vazia? {fila.IsEmpty()}");
            fila.Enqueue("Item");
            Console.WriteLine($"Fila vazia após adicionar item? {fila.IsEmpty()}");
        }

        public static void Exercicio5()
        {
            Console.WriteLine("\nExercício 5: Inverter palavra");
            Console.Write("Digite uma palavra: ");
            string palavra = Console.ReadLine();

            IStackOperations<char> pilha = new MinhaPilha<char>();
            foreach (char c in palavra)
                pilha.Push(c);

            string invertida = "";
            while (!pilha.IsEmpty())
                invertida += pilha.Pop();

            Console.WriteLine($"Palavra invertida: {invertida}");
        }

        public static void Exercicio6()
        {
            Console.WriteLine("\nExercício 6: Histórico de navegação");
            IStackOperations<string> historico = new MinhaPilha<string>();
            string paginaAtual = null;

            while (true)
            {
                Console.WriteLine("\n1 - Acessar nova página");
                Console.WriteLine("2 - Voltar à página anterior");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Digite a página: ");
                        string novaPagina = Console.ReadLine();
                        if (paginaAtual != null)
                            historico.Push(paginaAtual);
                        paginaAtual = novaPagina;
                        Console.WriteLine($"Página atual: {paginaAtual}");
                        break;
                    case "2":
                        if (historico.IsEmpty())
                            Console.WriteLine("Não há páginas anteriores!");
                        else
                        {
                            paginaAtual = historico.Pop();
                            Console.WriteLine($"Voltou para: {paginaAtual}");
                        }
                        break;
                    case "3":
                        return;
                }
            }
        }

        public static void Exercicio7()
        {
            Console.WriteLine("\nExercício 7: Atendimento por ordem de chegada");
            IQueueOperations<string> filaAtendimento = new MinhaFila<string>();

            while (true)
            {
                Console.WriteLine("\n1 - Adicionar cliente");
                Console.WriteLine("2 - Atender próximo cliente");
                Console.WriteLine("3 - Ver próximo cliente");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Nome do cliente: ");
                        filaAtendimento.Enqueue(Console.ReadLine());
                        Console.WriteLine("Cliente adicionado à fila!");
                        break;
                    case "2":
                        if (filaAtendimento.IsEmpty())
                            Console.WriteLine("Nenhum cliente na fila!");
                        else
                            Console.WriteLine($"Atendendo: {filaAtendimento.Dequeue()}");
                        break;
                    case "3":
                        if (filaAtendimento.IsEmpty())
                            Console.WriteLine("Nenhum cliente na fila!");
                        else
                            Console.WriteLine($"Próximo: {filaAtendimento.Peek()}");
                        break;
                    case "4":
                        return;
                }
            }
        }
    }
}
