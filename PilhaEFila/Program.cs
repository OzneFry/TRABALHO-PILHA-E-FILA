using PilhaEFila.Exercicios;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("TRABALHO DE ALGORÍTMOS - PILHAS E FILAS");

        while (true)
        {
            Console.WriteLine("\nEscolha a categoria de exercícios:");
            Console.WriteLine("1 - Fáceis (1-7)");
            Console.WriteLine("2 - Médios (8-14)");
            Console.WriteLine("3 - Difíceis (15-20)");
            Console.WriteLine("4 - Sair");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    MenuExerciciosFaceis();
                    break;
                case "2":
                    MenuExerciciosMedios();
                    break;
                case "3":
                    MenuExerciciosDificeis();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void MenuExerciciosFaceis()
    {
        while (true)
        {
            Console.WriteLine("\nEXERCÍCIOS FÁCEIS (1-7)");
            Console.WriteLine("Digite o número do exercício (1-7) ou 0 para voltar");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    return;
                case "1":
                    ExerciciosFaceis.Exercicio1();
                    break;
                case "2":
                    ExerciciosFaceis.Exercicio2();
                    break;
                case "3":
                    ExerciciosFaceis.Exercicio3();
                    break;
                case "4":
                    ExerciciosFaceis.Exercicio4();
                    break;
                case "5":
                    ExerciciosFaceis.Exercicio5();
                    break;
                case "6":
                    ExerciciosFaceis.Exercicio6();
                    break;
                case "7":
                    ExerciciosFaceis.Exercicio7();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void MenuExerciciosMedios()
    {
        while (true)
        {
            Console.WriteLine("\nEXERCÍCIOS MÉDIOS (8-14)");
            Console.WriteLine("Digite o número do exercício (8-14) ou 0 para voltar");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    return;
                case "8":
                    ExerciciosMedios.Exercicio8();
                    break;
                case "9":
                    ExerciciosMedios.Exercicio9();
                    break;
                case "12":
                    ExerciciosMedios.Exercicio12();
                    break;
                case "13":
                    ExerciciosMedios.Exercicio13();
                    break;
                case "14":
                    ExerciciosMedios.Exercicio14();
                    break;
                default:
                    Console.WriteLine("Opção inválida ou exercício não implementado no menu!");
                    break;
            }
        }
    }

    static void MenuExerciciosDificeis()
    {
        while (true)
        {
            Console.WriteLine("\nEXERCÍCIOS DIFÍCEIS (15-20)");
            Console.WriteLine("Digite o número do exercício (15-20) ou 0 para voltar");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    return;
                case "15":
                    ExerciciosDificeis.Exercicio15();
                    break;
                case "16":
                    ExerciciosDificeis.Exercicio16();
                    break;
                case "17":
                    ExerciciosDificeis.Exercicio17();
                    break;
                case "18":
                    ExerciciosDificeis.Exercicio18();
                    break;
                case "19":
                    ExerciciosDificeis.Exercicio19();
                    break;
                case "20":
                    ExerciciosDificeis.Exercicio20();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
