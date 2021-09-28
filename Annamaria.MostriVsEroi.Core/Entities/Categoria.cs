using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Flag { get; set; }  //0 Eroe, 1 Mostro

        public Categoria(int id, string nome, bool flag)
        {
            Id = id;
            Nome = nome;
            Flag = flag;
        }

        public Categoria()
        {
        }
    }
}
