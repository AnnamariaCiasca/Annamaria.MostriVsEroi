using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Core.BusinessLayer
{
   public class BusinessLayer: IBusinessLayer
    {
        private readonly IRepositoryArmi armiRep;
        private readonly IRepositoryCategorie categorieRep;
        private readonly IRepositoryEroi eroiRep;
        private readonly IRepositoryGiocatori giocatoriRep;
        private readonly IRepositoryMostri mostriRep;

      
        public BusinessLayer(IRepositoryArmi armi, IRepositoryCategorie categorie, IRepositoryEroi eroi, IRepositoryGiocatori giocatori, IRepositoryMostri mostri)
        {
            armiRep = armi;
            categorieRep = categorie;
            eroiRep = eroi;
            giocatoriRep = giocatori;
            mostriRep = mostri;
        }

        public void EliminaEroe(Eroe eroeDaCancellare)
        {
            eroiRep.Elimina(eroeDaCancellare);
        }

        public List<Arma> FetchArmiPerCategoria(int categoriaScelta)
        {
           return armiRep.FetchArmiPerCategoria(categoriaScelta);
        }

        public List<Categoria> FetchCategorie()
        {
            return categorieRep.Fetch();
        }
        public List<Categoria> FetchCategorieEroi()
        {
            return categorieRep.FetchCategorieEroi();
        }
        public List<Categoria> FetchCategorieMostri()
        {
            return categorieRep.FetchCategorieMostri();
        }

        public List<Eroe> FetchEroi()
        {
            return eroiRep.Fetch();
        }

        public List<Eroe> FetchEroiByGiocatore(int idGiocatore)
        {
            return eroiRep.FetchByGiocatore(idGiocatore);
        }

        public List<Eroe> FetchEroiPerPunti()
        {
            return eroiRep.FetchPerPunti();
        }

        public List<Giocatore> FetchGiocatori()
        {
            return giocatoriRep.Fetch();
        }

        public List<Mostro> FetchMostri()
        {
            return mostriRep.Fetch();
        }

        public Mostro GeneraMostro(int livello)
        {
            List<Mostro> mostri = mostriRep.GetByLivello(livello);
            var random = new Random();

            int index = random.Next(0, mostri.Count);
            return mostri[index];
        }

        public Arma GetArmaByEroe(Eroe eroe)
        {
            return armiRep.GetArmaByEroe(eroe);
        }

        public Arma GetArmaById(int armaScelta)
        {
            return armiRep.GetById(armaScelta);
        }

        public Arma GetArmaByMostro(Mostro mostroScelto)
        {
            return armiRep.GetArmaByMostro(mostroScelto);
        }

        public Categoria GetCategoriaByEroe(Eroe eroe)
        {
            return categorieRep.GetCategoriaByEroe(eroe);
        }

        public Categoria GetCategoriaById(int categoriaScelta)
        {
            return categorieRep.GetById(categoriaScelta);
        }

        public Categoria GetCategoriaByMostro(Mostro mostroScelto)
        {
            return categorieRep.GetCategoriaByMostro(mostroScelto);
        }

        public Eroe GetEroeById(int scelta)
        {
            return eroiRep.GetById(scelta);
        }

        public Eroe InserisciEroe(Eroe eroe, int categoriaScelta, int armaScelta, Giocatore giocatore)
        {
            return eroiRep.AddEroe(eroe, categoriaScelta, armaScelta, giocatore);

        }

        public Giocatore InserisciGiocatore(Giocatore giocatore)
        {
            return giocatoriRep.AddGiocatore(giocatore);
        }

        public Mostro InserisciMostro(Mostro mostro, int categoriaScelta, int armaScelta)
        {
            return mostriRep.AddMostro(mostro, categoriaScelta, armaScelta);
        }

        public string UserGiocatoreById(int idGiocatore)
        {
            string username = giocatoriRep.UserById(idGiocatore);
            return username;
        }

        public Giocatore VerificaAccesso(Giocatore giocatore)
        {
          return giocatoriRep.GetGiocatoreByNomePassword(giocatore);
      
        }
    }
}
