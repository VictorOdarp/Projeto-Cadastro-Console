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
            string path = @"C:\Users\Victo\Desktop\Projeto Cadastro\Formulario.txt";

            user.Inicio(path);

            MenuPrincipal(list, user, path);
            

            static void MenuPrincipal(List<User> list, User user, string path)
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
                    MenuPrincipal(list, user, path);
                }
                if (validação == 2)
                {
                    user.ListarUsuárioName(list);
                    MenuPrincipal(list,user, path);
                }
                if (validação == 3)
                {
                    user.AdicionarPergunta(path);
                    MenuPrincipal(list,user, path);
                }
                if (validação == 4)
                {
                    user.RemoverPergunta(path);
                    MenuPrincipal(list,user, path);
                }
                if (validação == 5)
                {
                    user.PesquisarUsuario(list,user);
                    MenuPrincipal(list,user, path);
                  
                }
            }

          
            
           
            

            







        }
    }
}
