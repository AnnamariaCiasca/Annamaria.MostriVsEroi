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

        public List<Giocatore> FetchGiocatori()
        {
            return giocatoriRep.Fetch();
        }

        public Giocatore InserisciGiocatore(Giocatore giocatore)
        {
            return giocatoriRep.AddGiocatore(giocatore);
        }

        public Giocatore VerificaAccesso(Giocatore giocatore)
        {
            giocatore = giocatoriRep.GetGiocatoreByNomePassword(giocatore);
            if(giocatore != null)
            {
                giocatore.IsAuthenticated = true;
                giocatore.IsAdmin = false;
            }

            return giocatore;
        }
    }
}
