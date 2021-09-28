using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.Entities
{
    public class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PuntiDanno { get; set; }


        public Arma(int id, string nome, int puntiDanno)
        {
            Id = id;
            Nome = nome;
            PuntiDanno = puntiDanno;

        }

        public Arma()
        {
        }
    }
}

