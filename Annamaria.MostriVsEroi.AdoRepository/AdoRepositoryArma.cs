using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using Annamaria.MostriVsEroi.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.AdoRepository
{
    public class AdoRepositoryArma : IRepositoryArmi
    {
        public List<Arma> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Arma> FetchArmiPerCategoria(int categoriaScelta)
        {
            throw new NotImplementedException();
        }

        public Arma GetById(int armaScelta)
        {
            throw new NotImplementedException();
        }
    }
}
