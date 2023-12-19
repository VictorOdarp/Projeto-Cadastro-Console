using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

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
            Console.Write("Email: ");
            string email = Console.ReadLine();
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
    }
}
