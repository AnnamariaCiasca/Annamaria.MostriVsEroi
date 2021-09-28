using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.Entities
{
    public class Eroe : Personaggio
    {
        public int IdGiocatore { get; set; }
        public int PuntiAccumulati { get; set; }
        

        public Eroe()
        {

        }
    }
}
