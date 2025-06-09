
using System.Diagnostics;

namespace BlogPortfolio
{
    internal class Program
    {
        static PostService postService = new PostService();

        
        static void Menu()
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
                        AddPostMenu();
                        break;
                    case 2:
                        //Atualizar um post
                        UpdatePostMenu();
                        break;
                    case 3:
                        //Remover um post
                        RemovePostMenu();
                        break;
                    case 4:
                        ListAllPostsMenu();
                        break;
                    case 5: 
                        // Listar um post por ID
                        GetPostByIdMenu();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do portal de posts do Blog. Até logo!");
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                        break;
                }
            }
        }
        
        static void PrintWelcomeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ____  _             \n |  _ \\| |            \n | |_) | | ___   __ _ \n |  _ <| |/ _ \\ / _` |\n | |_) | | (_) | (_| |\n |____/|_|\\___/ \\__, |\n                 __/ |\n                |___/ \n");
            Console.WriteLine("Bem-vindo ao Portal de posts do Blog!\n");
            Console.WriteLine("Este é um exemplo de um portal de posts de blog, onde você pode adicionar, remover e atualizar posts.\n");
            Console.WriteLine("Opções disponíveis:\n");
            Console.WriteLine("1. Adicionar um novo post");
            Console.WriteLine("2. Atualizar um novo post");
            Console.WriteLine("3. Remover um post");
            Console.WriteLine("4. Listar todos os posts");
            Console.WriteLine("5. Listar um post por ID");
            Console.WriteLine("0. Sair\n");

        }

        static void Main(string[] args)
        {

           Menu();
            
        }
        
        // TODO: implementar verificações de entrada para regras de negócio como o título não pode ser simplesmente um número, assim como o autor.
        static void AddPostMenu()
        {
            Console.Clear();
            Console.WriteLine("Adicionar um novo post\n");
            Console.Write("Digite o título do post: ");
            string title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Título não pode ser vazio. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }
            Console.Write("Digite o conteúdo do post: ");
            string content = Console.ReadLine();
            if (string.IsNullOrEmpty(content))
            {
                Console.WriteLine("Conteúdo não pode ser vazio. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }
            Console.Write("Digite o autor do post: ");
            string author = Console.ReadLine();
                
            if (string.IsNullOrEmpty(author))
            {
                Console.WriteLine("Autor não pode ser vazio. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }

            Post newPost = new Post
            {
                Title = title,
                Content = content,
                Author = author
            };
            
            postService.AddPost(newPost);
            Console.WriteLine("Post adicionado com sucesso! Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Menu();
                
        }

        static void UpdatePostMenu()
        {
            Console.Clear();
            Console.WriteLine("Atualizar um post\n");
            List<Post> posts = postService.GetAllPosts();
            if (posts.Count == 0)
            {
                Console.WriteLine("Nenhum post encontrado. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }
            Console.WriteLine("Lista de posts disponíveis para atualização:\n");
            foreach (var post in posts)
            {
                Console.WriteLine($"ID: {post.Id},\n Título: {post.Title},\n Autor: {post.Author},\n Criado em: {post.CreatedAt},\n Atualizado em: {post.UpdatedAt}");
            }
            Console.Write("Digite o ID do post que deseja atualizar: ");
            int input = int.Parse(Console.ReadLine());
            if (input <= 0)
            {
                Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }
            Post postToUpdate = posts.FirstOrDefault(p => p.Id == input);
            if (postToUpdate == null)
            {
                Console.WriteLine($"Post com ID {input} não encontrado. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }
            Console.Write("Digite o novo título do post (deixe em branco para manter o atual): ");
            string newTitle = Console.ReadLine();
            if (string.IsNullOrEmpty(newTitle))
            {
                newTitle = postToUpdate.Title; // Mantém o título atual se não for fornecido um novo
            }
            Console.Write("Digite o novo conteúdo do post (deixe em branco para manter o atual): ");
            string newContent = Console.ReadLine();
            if (string.IsNullOrEmpty(newContent))
            {
                newContent = postToUpdate.Content; // Mantém o conteúdo atual se não for fornecido um novo
            }
            Post updatedPost = new Post
            {
                Title = newTitle,
                Content = newContent,
                Author = postToUpdate.Author // O autor não pode ser atualizado
            };
            try
            {
                postService.UpdatePost(input, updatedPost);
                Console.WriteLine($"Post com ID {input} atualizado com sucesso! Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void RemovePostMenu()
        {
            Console.Clear();
            Console.WriteLine("Remover um post\n");
            Console.Write("Digite o ID do post que deseja remover: ");
            int input = int.Parse(Console.ReadLine());
            if (input <= 0)
            {
                Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }
            
            
            try
            {
                postService.RemovePost(input);
                Console.WriteLine(
                    $"Post com ID {input} removido com sucesso! Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }
            catch
            {
                throw new KeyNotFoundException($"Post com ID {input} não encontrado.");
            }
            Menu();
        }
        static void ListAllPostsMenu()
        {
            Console.Clear();
            List<Post> posts = postService.GetAllPosts();

            if (posts.Count == 0)
            {
                Console.WriteLine("Nenhum post encontrado. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }
            Console.WriteLine("Lista de posts:\n");
            foreach (var post in posts)
            {
                Console.WriteLine($"ID: {post.Id},\n Título: {post.Title},\n Autor: {post.Author},\n Criado em: {post.CreatedAt},\n Atualizado em: {post.UpdatedAt}\n Conteúdo: {post.Content}\n");
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Menu();

        }

        static void GetPostByIdMenu()
        {
            Console.Clear();
            Console.WriteLine("Buscar um post por ID\n");
            Console.Write("Digite o ID do post que deseja buscar: ");
            int input = int.Parse(Console.ReadLine());
            if (input <= 0)
            {
                Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }
            Post post = postService.GetAllPosts().FirstOrDefault(p => p.Id == input);
            if (post == null)
            {
                Console.WriteLine($"Post com ID {input} não encontrado. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }
            Console.WriteLine($"ID: {post.Id},\n Título: {post.Title},\n Autor: {post.Author},\n Criado em: {post.CreatedAt},\n Atualizado em: {post.UpdatedAt}\n Conteúdo: {post.Content}\n");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Menu();
        }
    }
}