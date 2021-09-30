using Annamaria.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.AdoRepository
{
  public class DBManager
    {
        AdoRepositoryEroe eroiRep = new AdoRepositoryEroe();
        public Eroe InserisciEroe(Eroe eroe, int categoriaScelta, int armaScelta, Giocatore giocatore)
        {
            return eroiRep.AddEroe(eroe, categoriaScelta, armaScelta, giocatore);

        }
    }
}
