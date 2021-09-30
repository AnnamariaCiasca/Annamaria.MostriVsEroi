using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.AdoRepository
{
    public class AdoRepositoryCategoria : IRepositoryCategorie
    {
        public List<Categoria> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Categoria> FetchCategorieEroi()
        {
            throw new NotImplementedException();
        }

        public List<Categoria> FetchCategorieMostri()
        {
            throw new NotImplementedException();
        }

        public Categoria GetById(int categoriaScelta)
        {
            throw new NotImplementedException();
        }
    }
}
