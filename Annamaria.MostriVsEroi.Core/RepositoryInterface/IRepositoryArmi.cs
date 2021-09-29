using Annamaria.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.RepositoryInterface
{
    public interface IRepositoryArmi : IRepository<Arma>
    {
        List<Arma> FetchArmiPerCategoria(int categoriaScelta);
        Arma GetById(int armaScelta);
    }
}
