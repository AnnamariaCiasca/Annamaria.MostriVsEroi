using Annamaria.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.RepositoryInterface
{
    public interface IRepositoryEroi : IRepository<Eroe>
    {
        Eroe AddEroe(Eroe eroe, int categoriaScelta, int armaScelta, Giocatore giocatore);
        List<Eroe> FetchByGiocatore(int idGiocatore);
        Eroe GetById(int scelta);
        void Elimina(Eroe eroeDaCancellare);
        List<Eroe> FetchPerPunti();
    }
}
