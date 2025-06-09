
namespace BlogPortfolio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PrintWelcomeMessage();

                Console.Write("Digite a opção desejada: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    continue;
                }

                int option;
                if (!int.TryParse(input, out option))
                {
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        // Adicionar um novo post
                        // AddPostMenu();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do portal de posts do Blog. Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                        break;
                }
            }

            static void PrintWelcomeMessage()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(
                    "\n  ____  _             \n |  _ \\| |            \n | |_) | | ___   __ _ \n |  _ <| |/ _ \\ / _` |\n | |_) | | (_) | (_| |\n |____/|_|\\___/ \\__, |\n                 __/ |\n                |___/ \n");
                Console.WriteLine("Bem-vindo ao Portal de posts do Blog!\n");
                Console.WriteLine(
                    "Este é um exemplo de um portal de posts de blog, onde você pode adicionar, remover e atualizar posts.\n");
                Console.WriteLine("Opções disponíveis:\n");
                Console.WriteLine("1. Adicionar um novo post");
                Console.WriteLine("2. Atualizar um novo post");
                Console.WriteLine("3. Remover um post");
                Console.WriteLine("4. Listar todos os posts");
                Console.WriteLine("5. Listar um post por ID");
                Console.WriteLine("0. Sair\n");

            }

            ;
        }
    }
}