using Annamaria.MostriVsEroi.Core.BusinessLayer;
using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Mock;
using System;
using System.Collections.Generic;

namespace Annamaria.MostriVsEroi
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryArmi(), new RepositoryCategorie(), new RepositoryEroi(), new RepositoryGiocatori(), new RepositoryMostri());
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto!");
            MenuPrincipale();
        }


        public static void MenuPrincipale()
        {
            bool continua = true;
            int scelta;

            do
            {
                Console.WriteLine("\nMenu principale\n");

                Console.WriteLine("Digita 1 per accedere");
                Console.WriteLine("Digita 2 per registrati");
                Console.WriteLine("Digita 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 2)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }

                switch (scelta)
                {
                    case 1:
                        Accedi();
                        break;
                    case 2:
                        Registrati();
                        break;
                    case 0:
                        Console.WriteLine("Alla prossima!");
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata.");
                        break;
                }
            } while (continua);
        }

        private static void Registrati()
        {
            Giocatore giocatore = new Giocatore();
            bool continua = true;
            string nome;
            do
            {
                Console.WriteLine("Inserisci il tuo nome utente");
                nome = Console.ReadLine();
                giocatore.Nome = nome;
             
                List<Giocatore> giocatori = bl.FetchGiocatori();
               
                bool trovato = false;
              
                foreach(var item in giocatori) 
                { 
                    if (item.Nome == nome)
                    {
                        trovato = true;
                    
                        break;
                    }
                  }
                if (trovato)
                {
                    Console.WriteLine("Username già in uso");
                }
                else 
                {
                    string password;
                    Console.WriteLine("Inserisci una password");
                    password = Console.ReadLine();
                    giocatore.Password = password;
                    giocatore = bl.InserisciGiocatore(giocatore);
                    Console.Write("Registrazione avvenuta con successo");
                    continua = false;
                }


            } while (continua);
            MenuNotAdmin(giocatore);
        }

        private static void Accedi()
        {
            
                Console.WriteLine("\nInserisci il tuo nome");
                string nome = Console.ReadLine();

                Console.WriteLine("Inserisci la tua password");
                string password = Console.ReadLine();

                Giocatore giocatore = new Giocatore(nome, password);

                giocatore = bl.VerificaAccesso(giocatore);
                if (giocatore != null && giocatore.IsAuthenticated && giocatore.IsAdmin)
                {
                    Console.WriteLine("\nAccesso eseguito");
                    MenuAdmin(giocatore);
                }
                else if (giocatore != null && giocatore.IsAuthenticated && !giocatore.IsAdmin)
                {
                    Console.WriteLine("\nAccesso eseguito");
                    MenuNotAdmin(giocatore);
                }
                else if(giocatore == null)
                {
                    Console.WriteLine("Username e/o Password errati");
                }
          
        }

        private static void MenuNotAdmin(Giocatore giocatore)
        {
            bool continua = true;
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine($"Ciao {giocatore.Nome}");

                Console.WriteLine("Digita 1 per giocare");
                Console.WriteLine("Digita 2 per creare un nuovo eroe");
                Console.WriteLine("Digita 3 per eliminare un eroe");
                Console.WriteLine("Digita 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 4)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }

                switch (scelta)
                {
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 0:
                        MenuPrincipale();
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata!");
                        break;
                }
            } while (continua);

        }

        private static void MenuAdmin(Giocatore giocatore)
        {
            bool continua = true;
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine($"Ciao {giocatore.Nome}, sei un Admin!");

                Console.WriteLine("Digita 1 per giocare");
                Console.WriteLine("Digita 2 per creare un nuovo eroe");
                Console.WriteLine("Digita 3 per eliminare un eroe");
                Console.WriteLine("Digita 4 per creare un nuovo mostro");
                Console.WriteLine("Digita 5 per mostrare la classifica globale");
                Console.WriteLine("Digita 0 per uscire");


                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 5)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }

                switch (scelta)
                {
                    case 1:
                       
                        break;
                    case 2:
                       
                        break;
                    case 3:
                        
                        break;
                    case 4:
                       
                        break;
                    case 5:
                        
                        break;
                    case 0:
                        MenuPrincipale();
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata!");
                        break;
                }
            } while (continua);
        }
    }
}

