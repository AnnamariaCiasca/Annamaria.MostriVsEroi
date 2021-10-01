using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Mock
{
   public class RepositoryArmi: IRepositoryArmi
    {
        public static List<Arma> armi = new List<Arma>()
        {
            new Arma {Id = 1, Nome = "Alabarda", PuntiDanno = 15, IdCategoria = 1},
            new Arma {Id = 2, Nome = "Ascia", PuntiDanno = 8, IdCategoria = 1},
            new Arma {Id = 3, Nome = "Mazza", PuntiDanno = 5, IdCategoria = 1},
            new Arma {Id = 4, Nome = "Spada", PuntiDanno = 10, IdCategoria = 1},
            new Arma {Id = 5, Nome = "Spadone", PuntiDanno = 15, IdCategoria = 1},

            new Arma {Id = 6, Nome = "Arco e frecce", PuntiDanno = 8, IdCategoria = 2},
            new Arma {Id = 7, Nome = "Bacchetta", PuntiDanno = 5, IdCategoria = 2},
            new Arma {Id = 8, Nome = "Bastone Magico", PuntiDanno = 10, IdCategoria = 2},
            new Arma {Id = 9, Nome = "Onda d'urto", PuntiDanno = 15, IdCategoria = 2},
            new Arma {Id = 10, Nome = "Pugnale", PuntiDanno = 5, IdCategoria = 2},

            new Arma {Id = 11, Nome = "Discorso noioso", PuntiDanno = 4, IdCategoria = 3},
            new Arma {Id = 12, Nome = "Farneticazione", PuntiDanno = 7, IdCategoria = 3},
            new Arma {Id = 13, Nome = "Imprecazione", PuntiDanno = 5, IdCategoria = 3},
            new Arma {Id = 14, Nome = "Magia nera", PuntiDanno = 3, IdCategoria = 3},

            new Arma {Id = 15, Nome = "Arco", PuntiDanno = 7, IdCategoria = 4},
            new Arma {Id = 16, Nome = "Clava", PuntiDanno = 5, IdCategoria = 4},
            new Arma {Id = 17, Nome = "Spada rotta", PuntiDanno = 3, IdCategoria = 4},
            new Arma {Id = 18, Nome = "Mazza chiodata", PuntiDanno = 10, IdCategoria = 4},
          
            new Arma {Id = 19, Nome = "Alabarda del drago", PuntiDanno = 30, IdCategoria = 5},
            new Arma {Id = 20, Nome = "Divinazione", PuntiDanno = 15, IdCategoria = 5},
            new Arma {Id = 21, Nome = "Fulmine", PuntiDanno = 10, IdCategoria = 5},
            new Arma {Id = 22, Nome = "Fulmine Celeste", PuntiDanno = 15, IdCategoria = 5},
            new Arma {Id = 23, Nome = "Tempesta", PuntiDanno = 8, IdCategoria = 5},
            new Arma {Id = 24, Nome = "Tempesta Oscura", PuntiDanno = 15, IdCategoria = 5},

        };

        public List<Arma> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Arma> FetchArmiPerCategoria(int categoriaScelta)
        {
            return armi.Where(a => a.IdCategoria == categoriaScelta).ToList();
        }

        public Arma GetArmaByEroe(Eroe eroe)
        {
            throw new NotImplementedException();
        }

        public Arma GetArmaByMostro(Mostro mostroScelto)
        {
            throw new NotImplementedException();
        }

        public Arma GetById(int armaScelta)
        {
            return armi.Where(a => a.Id == armaScelta).FirstOrDefault();
        }
    }
}
