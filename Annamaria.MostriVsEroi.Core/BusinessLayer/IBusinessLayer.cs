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
        Eroe InserisciEroe(Eroe eroe, int categoriaScelta, int armaScelta, Giocatore giocatore);
        List<Eroe> FetchEroiByGiocatore(int id);
        Eroe GetEroeById(int scelta);
        Mostro GeneraMostro(int livello);
        void EliminaEroe(Eroe eroeDaCancellare);
        List<Mostro> FetchMostri();
        Mostro InserisciMostro(Mostro mostro, int categoriaScelta, int armaScelta);
        List<Eroe> FetchEroiPerPunti();
        string UserGiocatoreById(int idGiocatore);
        Categoria GetCategoriaByEroe(Eroe item);
        Arma GetArmaByEroe(Eroe item);
        Categoria GetCategoriaByMostro(Mostro mostroScelto);
        Arma GetArmaByMostro(Mostro mostroScelto);
    }
}
