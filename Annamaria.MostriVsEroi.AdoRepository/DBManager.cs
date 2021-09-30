using Annamaria.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.AdoRepository
{
  public class DBManager
    {
        AdoRepositoryEroe eroiRep = new AdoRepositoryEroe();
        AdoRepositoryGiocatore giocatoriRep = new AdoRepositoryGiocatore();
        public Eroe InserisciEroe(Eroe eroe, int categoriaScelta, int armaScelta, Giocatore giocatore)
        {
            return eroiRep.AddEroe(eroe, categoriaScelta, armaScelta, giocatore);

        }

        public Giocatore VerificaAccesso(Giocatore giocatore)
        {
            giocatore = giocatoriRep.GetGiocatoreByNomePassword(giocatore);
            if (giocatore != null)
            {
                giocatore.IsAuthenticated = true;
            }

            return giocatore;
        }

        public List<Giocatore> FetchGiocatori()
        {
            return giocatoriRep.Fetch();
        }

        public Giocatore InserisciGiocatore(Giocatore giocatore)
        {
            return giocatoriRep.AddGiocatore(giocatore);
        }

        public string UserGiocatoreById(int idGiocatore)
        {
            string username = giocatoriRep.UserById(idGiocatore);
            return username;
        }

        public List<Eroe> FetchEroiPerPunti()
        {
            return eroiRep.FetchPerPunti();
        }

        public List<Eroe> FetchEroiByGiocatore(int idGiocatore)
        {
            return eroiRep.FetchByGiocatore(idGiocatore);
        }

        public Eroe GetEroeById(int scelta)
        {
            return eroiRep.GetById(scelta);
        }

        public void EliminaEroe(Eroe eroeDaCancellare)
        {
            eroiRep.Elimina(eroeDaCancellare);
        }
    }
}
