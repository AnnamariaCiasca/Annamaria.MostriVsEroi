using Annamaria.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.RepositoryInterface
{
  public interface IRepositoryCategorie: IRepository<Categoria>
    {
        List<Categoria> FetchCategorieEroi();
        List<Categoria> FetchCategorieMostri();
        Categoria GetById(int categoriaScelta);
        Categoria GetCategoriaByEroe(Eroe eroe);
        Categoria GetCategoriaByMostro(Mostro mostroScelto);
    }
}
