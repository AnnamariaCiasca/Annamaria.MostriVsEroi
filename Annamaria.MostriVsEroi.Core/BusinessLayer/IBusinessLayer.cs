using Annamaria.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        Giocatore VerificaAccesso(Giocatore giocatore);
        Giocatore InserisciGiocatore(Giocatore giocatore);
        List<Giocatore> FetchGiocatori();
        List<Eroe> FetchEroi();
        List<Categoria> FetchCategorie();

        List<Categoria> FetchCategorieEroi();
        List<Categoria> FetchCategorieMostri();
        List<Arma> FetchArmiPerCategoria(int categoriaScelta);
        Categoria GetCategoriaById(int categoriaScelta);
        Arma GetArmaById(int armaScelta);
        Eroe InserisciEroe(Eroe eroe);
        List<Eroe> FetchEroiByGiocatore(int id);
    }
}
