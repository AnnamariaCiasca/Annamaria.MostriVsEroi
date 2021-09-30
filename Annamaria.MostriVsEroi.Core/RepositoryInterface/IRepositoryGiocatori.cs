using Annamaria.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.RepositoryInterface
{
    public interface IRepositoryGiocatori : IRepository<Giocatore>
    {
        Giocatore GetGiocatoreByNomePassword(Giocatore giocatore);
     
        Giocatore AddGiocatore(Giocatore giocatore);
        string UserById(int idGiocatore);
    }
}
