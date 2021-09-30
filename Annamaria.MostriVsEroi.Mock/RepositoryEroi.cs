using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using System;
using System.Collections;
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
            new Eroe { Id = 1, Nome = "Frodo", _Categoria = new Categoria(1, "Guerriero", false) , _Arma = new Arma(1, "Alabarda", 15, 1), Livello = 1, PuntiVita = 20, PuntiAccumulati = 20, IdGiocatore = 1 },
            new Eroe { Id = 2, Nome = "Gandalf", _Categoria = new Categoria(2, "Mago", false) , _Arma = new Arma(9, "Onda d’urto", 15, 2), Livello = 3, PuntiVita = 60, PuntiAccumulati = 50, IdGiocatore = 1 },
            new Eroe { Id = 3, Nome = "Saruman", _Categoria = new Categoria(2, "Mago", false) , _Arma = new Arma(8, "Bastone Magico", 10, 2), Livello = 4, PuntiVita = 80, PuntiAccumulati = 90, IdGiocatore = 2 },
            new Eroe { Id = 4, Nome = "Aragorn", _Categoria = new Categoria(1, "Guerriero", false) , _Arma = new Arma(4, "Spada", 10, 1), Livello = 2, PuntiVita = 40, PuntiAccumulati = 50, IdGiocatore = 3 },
            new Eroe { Id = 5, Nome = "Arwen", _Categoria = new Categoria(1, "Guerriero", false) , _Arma = new Arma(2, "Ascia", 8, 1), Livello = 2, PuntiVita = 40, PuntiAccumulati = 30, IdGiocatore = 3 },
            new Eroe { Id = 6, Nome = "Harry Potter", _Categoria = new Categoria(2, "Mago", false) , _Arma = new Arma(7, "Bacchetta", 5, 2), Livello = 1, PuntiVita = 20, PuntiAccumulati = 25, IdGiocatore = 4 },

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

        public void Elimina(Eroe eroeDaCancellare)
        {
            eroi.Remove(eroeDaCancellare);
        }

        public List<Eroe> Fetch()
        {
            return eroi;
        }

        public List<Eroe> FetchByGiocatore(int idGiocatore)
        {
            return eroi.Where(e => e.IdGiocatore == idGiocatore).ToList();
        }

        public List<Eroe> FetchPerPunti()
        {
            
            return eroi.OrderByDescending(e => e.Livello).ThenByDescending(e => e.PuntiAccumulati).ToList();
        }

        public Eroe GetById(int scelta)
        {
            return eroi.Where(e => e.Id == scelta).FirstOrDefault();
        }
    }
}
