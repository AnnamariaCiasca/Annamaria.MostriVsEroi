using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.Entities
{
   public class Personaggio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria _Categoria { get; set; }  //unica categoria
        public Arma _Arma { get; set; }  //il personaggio ha una sola arma, che sia mostro o eroe
        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        
    }
}
