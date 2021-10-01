using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.Entities
{
    public class Giocatore
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }

        public Giocatore()
        {
        }

        public Giocatore(string nome, string password)
        {
            Nome = nome;
            Password = password;
            IsAdmin = false;
            IsAuthenticated = false;
        }

        public Giocatore(int id, string nome, string password, bool isAuthenticated, bool isAdmin)
        {
            Id = id;
            Nome = nome;
            Password = password;
            IsAuthenticated = isAuthenticated;
            IsAdmin = isAdmin;
        }
    }
}
