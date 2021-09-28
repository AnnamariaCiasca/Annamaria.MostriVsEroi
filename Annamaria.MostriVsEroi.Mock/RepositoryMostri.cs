using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Mock
{
  public  class RepositoryMostri: IRepositoryMostri
    {
        public static List<Mostro> mostri = new List<Mostro>()
        {
            new Mostro {Id = 1, Nome = "Gollum", _Categoria = new Categoria(4, "Orco", true), _Arma = new Arma(15, "Arco", 7, 4), Livello = 1, PuntiVita = 20 },
            new Mostro {Id = 2, Nome = "Voldemort", _Categoria = new Categoria(5, "Signore del male", true), _Arma = new Arma(19, "Alabarda del drago", 30, 5), Livello = 5, PuntiVita = 100 }
       
        };
    }
}
