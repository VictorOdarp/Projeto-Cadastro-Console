using System.Globalization;
using System.Numerics;

namespace ProjetoCadastro.Entities
{
    internal class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Year { get; set; }
        public double Height { get; set; }

        public User()
        {

        }
        
        public User(string name, string email, int year, double height)
        {
            Name = name;
            Email = email;
            Year = year;
            Height = height;
        }

        public void CadastrarUsuario(List<User> list)
        {
            int count = list.Count + 1;


            Console.Write("Name: ");
            string name = Console.ReadLine();
            while (name.Length < 10)
            {
                
                Console.WriteLine("Seu nome deve ter no minímo 10 caracteres!");
                Console.Write("Name: ");
                name = Console.ReadLine();
            }
            Console.Write("Email: ");
            string email = Console.ReadLine();
            while (!email.Contains("@") || list.Any(x => x.Email == email))
            {
                Console.WriteLine("Seu email precisa ser válido ou já é existente");
                Console.Write("Email: ");
                email = Console.ReadLine();

            }
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            User user = new User(name, email, year, height);
            list.Add(user);

            string targetPath = (@"C:\Users\Victo\Desktop\Projeto Cadastro\Usuarios\" + count + "-" + user.Name + ".txt");

            try
            {
                using (StreamWriter sw = new StreamWriter(targetPath))
                {
                    sw.WriteLine("Name: " + user.Name);
                    sw.WriteLine("Email: " + user.Email);
                    sw.WriteLine("Year: " + user.Year);
                    sw.WriteLine("Heigh: " + user.Height);
                    Console.WriteLine("Usuário cadastrado com sucesso!");
                    Console.WriteLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }

        public void ListarUsuárioName(List<User> list)
        {
            int count = 1;

            if(list.Count == 0)
            {
                Console.WriteLine("Você não tem usuários cadastrados!");
                Console.WriteLine();
            }

            foreach (User item in list)
            {
                Console.WriteLine(count + " - " + item.Name);
                count++;
            }
            Console.WriteLine();
        }

        public void AdicionarPergunta(string path)
        {
            string numero = null;

            Console.Write("Digite sua pergunta a ser adicionada: ");
            string pergunta = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(path);

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine((lines.Count() + 1) + " - " + pergunta);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }

        public void RemoverPergunta(string path)
        {

            Console.Write("Digite o número da pergunta a ser removida: ");
            int num = int.Parse(Console.ReadLine());

            try
            {
                List<string> strings = File.ReadAllLines(path).ToList();

                if(num > 4)
                {
                    strings.RemoveAt(num - 1);
                    File.WriteAllLines(path, strings);
                }
                else
                {
                    Console.WriteLine("Não é possível deletar as primeiras 4 perguntas");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
        public void PesquisarUsuario(List<User> list, User user)
        {
            Console.WriteLine("Digite a informação do usuário: ");
            string usuário = Console.ReadLine();

            var result = list.Where(x => x.Name.Contains(usuário)).ToList();

            foreach (User item in result)
            {
                Console.WriteLine(item.Name + " - " + item.Email + " - " + item.Year + " - " + item.Height.ToString(CultureInfo.InvariantCulture));
            }
            Console.WriteLine();
           
        }

    }
}
