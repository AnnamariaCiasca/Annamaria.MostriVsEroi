using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Mock
{
   public class RepositoryGiocatori: IRepositoryGiocatori
    {
        public static List<Giocatore> giocatori = new List<Giocatore>()
        {
            new Giocatore{Id = 1, Nome="Annamaria", Password="Anna00", IsAdmin = true, IsAuthenticated = true},
            new Giocatore{Id = 2, Nome="Mario", Password="Mario77", IsAdmin = false, IsAuthenticated = true},
            new Giocatore{Id = 3, Nome="Luigi", Password="Gigi11", IsAdmin = false, IsAuthenticated = true},
            new Giocatore{Id = 4, Nome="Maria", Password="1234", IsAdmin = true, IsAuthenticated = true},
            new Giocatore{Id = 5, Nome="Sara", Password="5678", IsAdmin = false, IsAuthenticated = true},
        };

        public Giocatore AddGiocatore(Giocatore giocatore)
        {
            if(giocatori.Count() == 0)
            {
                giocatore.Id = 1;
            }
            else
            {
                giocatore.Id = giocatori.Max(g => g.Id) + 1;
            }

            giocatori.Add(giocatore);
            return giocatore;
        }

        public List<Giocatore> Fetch()
        {
            return giocatori;
        }

        public Giocatore GetGiocatoreByNomePassword(Giocatore giocatore)
        {
            return giocatori.Where(g => g.Nome == giocatore.Nome && g.Password == giocatore.Password).SingleOrDefault();
        }

        public string UserById(int idGiocatore)
        {
         
            return giocatori.Where(g => g.Id == idGiocatore).Select(g => g.Nome).FirstOrDefault();

        }
    }
}
