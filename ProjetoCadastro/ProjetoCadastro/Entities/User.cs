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


    }
}
