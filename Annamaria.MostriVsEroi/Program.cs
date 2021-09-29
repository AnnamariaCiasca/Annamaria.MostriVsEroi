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

                foreach (var item in giocatori)
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
            else if (giocatore == null)
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
                        Gioca(giocatore);
                        break;
                    case 2:
                        CreaEroe(giocatore);
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
                        Gioca(giocatore);
                        break;
                    case 2:
                        CreaEroe(giocatore);
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

        private static void CreaEroe(Giocatore giocatore)
        {
            Eroe eroe = new Eroe();
            bool continua = true;
            string nome;
            do
            {
                Console.WriteLine("Inserisci un nome per il tuo eroe");
                nome = Console.ReadLine();
                eroe.Nome = nome;

                List<Eroe> eroi = bl.FetchEroi();

                bool trovato = false;

                foreach (var item in eroi)
                {
                    if (item.Nome == nome)
                    {
                        trovato = true;

                        break;
                    }
                }
                if (trovato)
                {
                    Console.WriteLine("Nome già in uso per un altro eroe");
                }
                else
                {
                    Console.WriteLine("\nScegli la categoria per il tuo eroe:");

                    List<Categoria> categorie = bl.FetchCategorieEroi();


                    foreach (var item in categorie)
                    {
                        Console.WriteLine($"\nDigita {item.Id} per scegliere la Categoria {item.Nome}");
                    }

                    int categoriaScelta;

                    while (!int.TryParse(Console.ReadLine(), out categoriaScelta))
                    {
                        Console.WriteLine("Inserire valore corretto!");
                    }

                    Categoria categoriaEroe = bl.GetCategoriaById(categoriaScelta);


                    Console.WriteLine("\nScegli l'arma per il tuo eroe:");
                    List<Arma> armi = bl.FetchArmiPerCategoria(categoriaScelta);

                    foreach (var item in armi)
                    {
                        Console.WriteLine($"\nDigita {item.Id} per scegliere l'arma {item.Nome} che ha punti danno pari a {item.PuntiDanno}");
                    }

                    int armaScelta;

                    while (!int.TryParse(Console.ReadLine(), out armaScelta))
                    {
                        Console.WriteLine("Inserire valore corretto!");
                    }

                    Arma armaEroe = bl.GetArmaById(armaScelta);

                    eroe._Categoria = categoriaEroe;
                    eroe._Arma = armaEroe;
                    eroe.Livello = 1;
                    eroe.PuntiAccumulati = 0;
                    eroe.PuntiVita = 20;
                    eroe.IdGiocatore = giocatore.Id;

                    eroe = bl.InserisciEroe(eroe);
                    Console.WriteLine("Eroe creato correttamente.");

                }
                if (giocatore.IsAdmin == false)
                {
                    MenuNotAdmin(giocatore);
                }
                else
                {
                    MenuAdmin(giocatore);
                }
            } while (continua);


        }


        private static void Gioca(Giocatore giocatore)
        {
            Console.Clear();
            int scelta;
            Console.WriteLine("Ecco la lista degli eroi con cui puoi giocare:\n");
            List<Eroe> eroi = bl.FetchEroiByGiocatore(giocatore.Id);
            foreach (var item in eroi)
            {
                Console.WriteLine(item.Print());
            }
            Console.WriteLine("\nOra è il momento di fare la tua scelta\n");
            foreach (var item in eroi)
            {
                Console.WriteLine($"\nDigita {item.Id} per scegliere l'eroe {item.Nome}");
            }

            while (!int.TryParse(Console.ReadLine(), out scelta))
            {
                Console.WriteLine("Inserire valore corretto!");
            }

            Eroe eroeScelto = bl.GetEroeById(scelta);

            GenerazioneMostro(eroeScelto, giocatore);
        }

        private static void GenerazioneMostro(Eroe eroeScelto, Giocatore giocatore)
        {
            CalcoloLivello(eroeScelto, giocatore);
            Mostro mostroScelto = bl.GeneraMostro(eroeScelto.Livello);
            if (mostroScelto.Livello == 1)
            {
                mostroScelto.PuntiVita = 20;
            }
            else if (mostroScelto.Livello == 2)
            {
                mostroScelto.PuntiVita = 40;
            }
            else if (mostroScelto.Livello == 3)
            {
                mostroScelto.PuntiVita = 60;
            }
            else if (mostroScelto.Livello == 4)
            {
                mostroScelto.PuntiVita = 80;
            }
            else if (mostroScelto.Livello == 5)
            {
                mostroScelto.PuntiVita = 100;
            }

            Console.WriteLine($"\nIl tuo eroe {eroeScelto.Nome} dovrà sfidare il mostro:\n");
            Console.WriteLine(mostroScelto.Print());

            Partita(eroeScelto, mostroScelto, giocatore);
        }

        private static void CalcoloLivello(Eroe eroeScelto, Giocatore giocatore)
        {
            if (eroeScelto.PuntiAccumulati <= 29)
            {
                eroeScelto.Livello = 1;
                eroeScelto.PuntiVita = 20;
                giocatore.IsAdmin = false;
            }
            else if (eroeScelto.PuntiAccumulati >= 30 && eroeScelto.PuntiAccumulati <= 59)
            {
                if (eroeScelto.Livello == 1)
                {
                    eroeScelto.PuntiAccumulati = 0;  //se sono entrata in questo ciclo adesso l'eroe ha livello 1, perciò vuol dire che sta cambiando livello, quindi azzero punti
                    eroeScelto.Livello = 2;
                }
                else
                {
                    eroeScelto.Livello = 2;
                    eroeScelto.PuntiVita = 40;
                }
              
                giocatore.IsAdmin = false;
            }
            else if (eroeScelto.PuntiAccumulati >= 60 && eroeScelto.PuntiAccumulati <= 89)
            {
                if (eroeScelto.Livello == 2)
                {
                    eroeScelto.PuntiAccumulati = 0;
                    eroeScelto.Livello = 3;
                }
                else
                {
                    eroeScelto.Livello = 3;
                    eroeScelto.PuntiVita = 60;
                }
                giocatore.IsAdmin = true;
            }
            else if (eroeScelto.PuntiAccumulati >= 90 && eroeScelto.PuntiAccumulati <= 199)
            {
                if (eroeScelto.Livello == 3)
                {
                    eroeScelto.PuntiAccumulati = 0;
                    eroeScelto.Livello = 4;
                }
                else
                {
                    eroeScelto.Livello = 4;
                    eroeScelto.PuntiVita = 80;
                }
                giocatore.IsAdmin = true;
            }
            else if (eroeScelto.PuntiAccumulati >= 120)
            {
                if (eroeScelto.Livello == 4)
                {
                    eroeScelto.PuntiAccumulati = 0;
                    eroeScelto.Livello = 5;
                }
                else
                {
                    eroeScelto.Livello = 5;
                    eroeScelto.PuntiVita = 100;
                }
                giocatore.IsAdmin = true;
            }

        }

        private static void Partita(Eroe eroeScelto, Mostro mostroScelto, Giocatore giocatore)
        {

            Console.WriteLine($"\nBene {giocatore.Nome}, giochiamo!");
            bool continua = true;


            int sceltaAzione;
            do
            {
                Console.WriteLine("\nDigita 1 per Attaccare il mostro");
                Console.WriteLine("Digita 2 per Fuggire");
                Console.WriteLine("Digita 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out sceltaAzione) || sceltaAzione < 0 || sceltaAzione > 2)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }

                switch (sceltaAzione)
                {
                    case 1:
                        AttaccaEroe(eroeScelto, mostroScelto, continua, giocatore);

                        break;
                    case 2:
                        Fuggi(eroeScelto, mostroScelto, continua, giocatore);
                        break;
                    case 3:

                        break;
                    case 0:
                        if (giocatore.IsAdmin == false)
                        {
                            MenuNotAdmin(giocatore);
                        }
                        else
                        {
                            MenuAdmin(giocatore);
                        }
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata!");
                        break;
                }
            } while (continua);
        }

        private static void Fuggi(Eroe eroeScelto, Mostro mostroScelto, bool continua, Giocatore giocatore)
        {
            Random r = new Random();
            int uscita = r.Next(0, 2);
            bool fugaRiuscita = Convert.ToBoolean(uscita);
            if (!fugaRiuscita)
            {
                Console.WriteLine("Non sei riuscito a fuggire");
                AttaccaMostro(eroeScelto, mostroScelto, continua, giocatore);
            }
            else
            {
                Console.WriteLine("Fuga riuscita");
                eroeScelto.PuntiAccumulati = eroeScelto.PuntiAccumulati - (mostroScelto.Livello * 5);
                Console.WriteLine($"Ora il tuo eroe possiede {eroeScelto.PuntiAccumulati} punti");
                continua = true;
            }

        }

        private static void AttaccaEroe(Eroe eroeScelto, Mostro mostroScelto, bool continua, Giocatore giocatore)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nL'eroe {eroeScelto.Nome} attacca il mostro {mostroScelto.Nome}");
            Console.ForegroundColor = ConsoleColor.White;
            int vitaRimastaMostro = mostroScelto.PuntiVita - eroeScelto._Arma.PuntiDanno;
            Console.WriteLine($"\nI punti vita del mostro ora sono: {vitaRimastaMostro}");
            if (vitaRimastaMostro <= 0)
            {
                Console.WriteLine($"\nComplimenti, il tuo eroe ha vinto!");
                eroeScelto.PuntiAccumulati = eroeScelto.PuntiAccumulati + (mostroScelto.Livello * 10);
                Console.WriteLine($"Ora il tuo eroe possiede {eroeScelto.PuntiAccumulati} punti");
                CalcoloLivello(eroeScelto, giocatore);
                Console.WriteLine("\nVuoi continuare a giocare? Scrivi Si o No");
                string risposta = Console.ReadLine().ToUpper();
                if (risposta == "SI")
                {
                    Console.WriteLine("\nDigita 1 per giocare ancora con questo eroe");
                    Console.WriteLine("Digita 2 per sceglierne uno nuovo");
                    int nuovo;

                    while (!int.TryParse(Console.ReadLine(), out nuovo) || nuovo < 1 || nuovo > 2)
                    {
                        Console.WriteLine("Inserire valore corretto!");
                    }
                    switch (nuovo)
                    {
                        case 1:
                            GenerazioneMostro(eroeScelto, giocatore);
                            break;
                        case 2:
                            Gioca(giocatore);
                            break;
                    }

                }
                else
                {

                    if (giocatore.IsAdmin == false)
                    {
                        MenuNotAdmin(giocatore);
                    }
                    else
                    {
                        MenuAdmin(giocatore);
                    }
                }
            }
            else
            {
                mostroScelto.PuntiVita = vitaRimastaMostro;
                AttaccaMostro(eroeScelto, mostroScelto, continua, giocatore);

            }
        }

        private static void AttaccaMostro(Eroe eroeScelto, Mostro mostroScelto, bool continua, Giocatore giocatore)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nIl mostro {mostroScelto.Nome} attacca l'eroe {eroeScelto.Nome}");
            Console.ForegroundColor = ConsoleColor.White;
            int vitaRimastaEroe = eroeScelto.PuntiVita - mostroScelto._Arma.PuntiDanno;
            Console.WriteLine($"\nI punti vita del tuo eroe ora sono: {vitaRimastaEroe}");


            if (vitaRimastaEroe <= 0)
            {
                Console.WriteLine($"\nPeccato, il tuo eroe ha perso!");
                Console.WriteLine($"Ora il tuo eroe possiede {eroeScelto.PuntiAccumulati} punti");
                CalcoloLivello(eroeScelto, giocatore);
                Console.WriteLine("\nVuoi continuare a giocare? Scrivi Si o No");
                string risposta = Console.ReadLine().ToUpper();
                if (risposta == "SI")
                {
                    Console.WriteLine("\nDigita 1 per giocare ancora con questo eroe");
                    Console.WriteLine("Digita 2 per sceglierne uno nuovo");
                    int nuovo;

                    while (!int.TryParse(Console.ReadLine(), out nuovo) || nuovo < 1 || nuovo > 2)
                    {
                        Console.WriteLine("Inserire valore corretto!");
                    }
                    switch (nuovo)
                    {
                        case 1:
                            GenerazioneMostro(eroeScelto, giocatore);
                            break;
                        case 2:
                            Gioca(giocatore);
                            break;
                    }

                }
                else
                {
                    if (giocatore.IsAdmin == false)
                    {
                        MenuNotAdmin(giocatore);
                    }
                    else
                    {
                        MenuAdmin(giocatore);
                    }
                }
            }
            else
            {

                eroeScelto.PuntiVita = vitaRimastaEroe;
                continua = true;
            }

        }

    }
}

