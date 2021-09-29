using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Mock
{
    public class RepositoryEroi : IRepositoryEroi
    {
        public static List<Eroe> eroi = new List<Eroe>()
        {
            new Eroe { Id = 1, Nome = "Frodo", _Categoria = new Categoria(1, "Guerriero", false) , _Arma = new Arma(1, "Alabarda", 15, 1), Livello = 1, PuntiVita = 20, PuntiAccumulati = 30, IdGiocatore = 1 },
            new Eroe { Id = 2, Nome = "Gandalf", _Categoria = new Categoria(2, "Mago", false) , _Arma = new Arma(9, "Onda d’urto", 15, 2), Livello = 3, PuntiVita = 60, PuntiAccumulati = 20, IdGiocatore = 1 },

        };

        public Eroe AddEroe(Eroe eroe)
        {

            if (eroi.Count() == 0)
            {
                eroe.Id = 1;
            }
            else
            {
                eroe.Id = eroi.Max(g => g.Id) + 1;
            }

            eroi.Add(eroe);
            return eroe;
        }

        public List<Eroe> Fetch()
        {
            return eroi;
        }

        public List<Eroe> FetchByGiocatore(int idGiocatore)
        {
            return eroi.Where(e => e.IdGiocatore == idGiocatore).ToList();
        }
    }
}
