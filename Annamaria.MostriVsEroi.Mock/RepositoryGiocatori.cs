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
        };
    }
}
