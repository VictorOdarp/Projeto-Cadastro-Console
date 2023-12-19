using ProjetoCadastro.Entities;
using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace ProjetoCadastro
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\Victo\Desktop\Projeto Cadastro\Formulario.txt";
            User user = new User();
            List<User> list = new List<User>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }

            CadastrarUsuario();

            void CadastrarUsuario()
            {
                int count = list.Count; 
                

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

                string targetPath = (@"C:\Users\Victo\Desktop\Projeto Cadastro\" + (count + 1) + "-" + user.Name + ".txt");

                try
                {
                    using (StreamWriter sw = new StreamWriter(targetPath))
                    {
                        sw.WriteLine("Name: " + user.Name);
                        sw.WriteLine("Email: " + user.Email);
                        sw.WriteLine("Year: " + user.Year);
                        sw.WriteLine("Heigh: " + user.Height);
                        Console.WriteLine("Usuário cadastrado com sucesso!");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred");
                    Console.WriteLine(ex.Message);
                }
            }

            CadastrarUsuario();







        }
    }
}
