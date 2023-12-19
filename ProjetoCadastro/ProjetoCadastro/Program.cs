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
            User user = new User();
            List<User> list = new List<User>();

            Console.WriteLine("Perguntas iniciais!");
            Console.WriteLine();

            string path = @"C:\Users\Victo\Desktop\Projeto Cadastro\Formulario.txt";

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

            Console.WriteLine();
            Inicio(list, user);

            static void Inicio(List<User> list, User user)
            {

                Console.WriteLine("1 - Cadastrar o usuário");
                Console.WriteLine("2 - Listar todos os usuários cadastrados");
                Console.WriteLine("3 - Cadastrar nova pergunta no formulário");
                Console.WriteLine("4 - Deletar perguntado formulário");
                Console.WriteLine("5 - Pesquisar usuário por nome, idade ou email");

                Console.Write("Digite a sua opçao: ");
                int validação = int.Parse(Console.ReadLine());
                Console.WriteLine();


                if (validação == 1)
                {
                    user.CadastrarUsuario(list);
                    Inicio(list, user);
                }
                if (validação == 2)
                {
                    user.ListarUsuárioName(list);
                    Inicio(list,user);
                }
            }

          
            
           
            

            







        }
    }
}
