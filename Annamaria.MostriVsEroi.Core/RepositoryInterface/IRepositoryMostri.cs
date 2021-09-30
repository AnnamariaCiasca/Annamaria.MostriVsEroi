using Annamaria.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.RepositoryInterface
{
    public interface IRepositoryMostri : IRepository<Mostro>
    {
        List<Mostro> GetByLivello(int livello);
        Mostro AddMostro(Mostro mostro);
    }
}
