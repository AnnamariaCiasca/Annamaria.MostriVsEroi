using Annamaria.MostriVsEroi.AdoRepository;
using Annamaria.MostriVsEroi.Core.BusinessLayer;
using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Mock;
using System;
using System.Collections.Generic;

namespace Annamaria.MostriVsEroi
{

    // Arianna -> non devi fare il dbManager, usi sempre il bl... riscrivi solo le classi repository
    class Program
    {
        //private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryArmi(), new RepositoryCategorie(), new RepositoryEroi(), new RepositoryGiocatori(), new RepositoryMostri());
        private static readonly IBusinessLayer bl = new BusinessLayer(new AdoRepositoryArma(), new AdoRepositoryCategoria(), new AdoRepositoryEroe(), new AdoRepositoryGiocatore(), new AdoRepositoryMostro());

        //private static readonly DBManager dbm = new DBManager();
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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nMenu principale\n");

                Console.WriteLine("Digita 1 per accedere");
                Console.WriteLine("Digita 2 per registrati");
                Console.WriteLine("Digita 0 per uscire");
                Console.ForegroundColor = ConsoleColor.White;

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
                //List<Giocatore> giocatori = dbm.FetchGiocatori();

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
                      //giocatore = dbm.InserisciGiocatore(giocatore);

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
            //giocatore = dbm.VerificaAccesso(giocatore);
         
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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nCiao {giocatore.Nome}!\n");

                Console.WriteLine("Digita 1 per giocare");
                Console.WriteLine("Digita 2 per creare un nuovo eroe");
                Console.WriteLine("Digita 3 per eliminare un eroe");
                Console.WriteLine("Digita 0 per uscire");
                Console.ForegroundColor = ConsoleColor.White;

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
                        EliminaEroe(giocatore);
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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nCiao {giocatore.Nome}, sei un Admin!\n");

                Console.WriteLine("Digita 1 per giocare");
                Console.WriteLine("Digita 2 per creare un nuovo eroe");
                Console.WriteLine("Digita 3 per eliminare un eroe");
                Console.WriteLine("Digita 4 per creare un nuovo mostro");
                Console.WriteLine("Digita 5 per mostrare la classifica globale");
                Console.WriteLine("Digita 0 per uscire");
                Console.ForegroundColor = ConsoleColor.White;


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
                        EliminaEroe(giocatore);
                        break;
                    case 4:
                        CreaMostro(giocatore);
                        break;
                    case 5:
                        MostraClassifica();
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

        private static void MostraClassifica()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------Classifica---------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            List<Eroe> eroiClassifica = bl.FetchEroiPerPunti();
            //List<Eroe> eroiClassifica = dbm.FetchEroiPerPunti();
            string username;
            int i = 1;
            foreach (var item in eroiClassifica)
            {
                username = bl.UserGiocatoreById(item.IdGiocatore);
                //username = dbm.UserGiocatoreById(item.IdGiocatore);
                Console.WriteLine($"{i}) Eroe: {item.Nome} - Livello: {item.Livello} - Punti: {item.PuntiAccumulati} - Giocatore: {username}");
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void EliminaEroe(Giocatore giocatore)
        {
            Console.Clear();
            int scelta;
            Console.WriteLine("Ecco la lista degli eroi:\n");
            // Arianna -> TODO

            List<Eroe> eroi = bl.FetchEroiByGiocatore(giocatore.Id);  //non funziona perché mi passa sempre IdGiocatore = 0, sbaglio qualcosa nel metodo  GetGiocatoreByNomePassword in AdoRepositoryEroe
                                                                    // Arianna -> prova a mandarmi l'estazione del db che verifico
            foreach (var item in eroi)
            {
                Console.WriteLine(item.Print());
            }
            Console.WriteLine("\n");
            foreach (var item in eroi)
            {
                Console.WriteLine($"Digita {item.Id} per eliminare l'eroe {item.Nome}");
            }

            while (!int.TryParse(Console.ReadLine(), out scelta))
            {
                Console.WriteLine("Inserire valore corretto!");
            }

            Eroe eroeDaCancellare = bl.GetEroeById(scelta);
            bl.EliminaEroe(eroeDaCancellare);

            Console.WriteLine("L'eroe selezionato è stato eliminato correttamente");

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

                    eroe = bl.InserisciEroe(eroe, categoriaScelta, armaScelta, giocatore);
                    //eroe = dbm.InserisciEroe(eroe, categoriaScelta, armaScelta, giocatore);
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


        private static void CreaMostro(Giocatore giocatore)
        {
            Mostro mostro = new Mostro();
            bool continua = true;
            string nome;
            do
            {
                Console.WriteLine("Inserisci un nome per il tuo mostro");
                nome = Console.ReadLine();
                mostro.Nome = nome;

                List<Mostro> mostri = bl.FetchMostri();

                bool trovato = false;

                foreach (var item in mostri)
                {
                    if (item.Nome == nome)
                    {
                        trovato = true;

                        break;
                    }
                }
                if (trovato)
                {
                    Console.WriteLine("Nome già in uso per un altro mostro");
                }
                else
                {
                    Console.WriteLine("\nScegli la categoria per il tuo mostro:");

                    List<Categoria> categorie = bl.FetchCategorieMostri();


                    foreach (var item in categorie)
                    {
                        Console.WriteLine($"\nDigita {item.Id} per scegliere la Categoria {item.Nome}");
                    }

                    int categoriaScelta;

                    while (!int.TryParse(Console.ReadLine(), out categoriaScelta))
                    {
                        Console.WriteLine("Inserire valore corretto!");
                    }

                    Categoria categoriaMostro = bl.GetCategoriaById(categoriaScelta);


                    Console.WriteLine("\nScegli l'arma per il tuo mostro:");
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

                    Arma armaMostro = bl.GetArmaById(armaScelta);

                    Console.WriteLine("\nScegli il Livello per il tuo mostro, da 1 a 5:");
                    int livelloScelto;
                    while (!int.TryParse(Console.ReadLine(), out livelloScelto) || livelloScelto < 1 || livelloScelto > 5);
                    {
                        Console.WriteLine("Inserire valore corretto!");
                    }

                    switch (livelloScelto)
                    {
                        case 1:
                            mostro.PuntiVita = 20;
                            break;
                        case 2:
                            mostro.PuntiVita = 40;
                            break;
                        case 3:
                            mostro.PuntiVita = 60;
                            break;
                        case 4:
                            mostro.PuntiVita = 80;
                            break;
                        case 5:
                            mostro.PuntiVita = 100;
                            break;
                    }

                    mostro._Categoria = categoriaMostro;
                    mostro._Arma = armaMostro;
                    mostro.Livello = livelloScelto;
                    mostro = bl.InserisciMostro(mostro);
                    Console.WriteLine("\nMostro creato correttamente.");

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item.Print());
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("\nOra è il momento di fare la tua scelta\n");
            foreach (var item in eroi)
            {
                Console.WriteLine($"Digita {item.Id} per scegliere l'eroe {item.Nome}");
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
            // Arianna -> Perchè? I tuoi mostri hanno già i punti vita come proprietà 
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

            Console.WriteLine($"\nIl tuo eroe {eroeScelto.Nome} dovrà sfidare il mostro:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mostroScelto.Print());
            Console.ForegroundColor = ConsoleColor.White;

            Partita(eroeScelto, mostroScelto, giocatore);
        }

        private static void CalcoloLivello(Eroe eroeScelto, Giocatore giocatore)
        {
            int lvl = eroeScelto.Livello;

            switch (lvl)
            {
                case 1:
                    if (eroeScelto.PuntiAccumulati <= 29)
                    {
                        eroeScelto.Livello = 1;
                        eroeScelto.PuntiVita = 20;
                    }
                    else if (eroeScelto.PuntiAccumulati >= 30 && eroeScelto.PuntiAccumulati <= 59)
                    {
                        eroeScelto.PuntiAccumulati = 0;  //se sono entrata in questo ciclo adesso l'eroe ha livello 1, perciò vuol dire che sta cambiando livello, quindi azzero punti
                        eroeScelto.Livello = 2;
                        eroeScelto.PuntiVita = 40;
                        Console.WriteLine($"Complimenti, grazie ai punti che hai accumulato, il tuo eroe {eroeScelto.Nome} è passato al Livello successivo.\nOra il tuo eroe è di Livello {eroeScelto.Livello}!");
                    }
                    break;
                case 2:
                    if (eroeScelto.PuntiAccumulati <= 59)
                    {
                        eroeScelto.Livello = 2;
                        eroeScelto.PuntiVita = 40;

                    }

                    else if (eroeScelto.PuntiAccumulati >= 60 && eroeScelto.PuntiAccumulati <= 89)
                    {
                        eroeScelto.PuntiAccumulati = 0;
                        eroeScelto.Livello = 3;
                        eroeScelto.PuntiVita = 60;
                        Console.WriteLine($"Complimenti, grazie ai punti che hai accumulato, il tuo eroe {eroeScelto.Nome} è passato al Livello successivo.\nOra il tuo eroe è di Livello {eroeScelto.Livello}!");
                        giocatore.IsAdmin = true;
                    }
                    break;
                case 3:
                    if (eroeScelto.PuntiAccumulati <= 89)
                    {
                        eroeScelto.Livello = 3;
                        eroeScelto.PuntiVita = 60;
                        giocatore.IsAdmin = true;
                    }
                    else if (eroeScelto.PuntiAccumulati >= 90 && eroeScelto.PuntiAccumulati <= 199)
                    {
                        eroeScelto.PuntiAccumulati = 0;
                        eroeScelto.Livello = 4;
                        eroeScelto.PuntiVita = 80;
                        Console.WriteLine($"Complimenti, grazie ai punti che hai accumulato, il tuo eroe {eroeScelto.Nome} è passato al Livello successivo.\nOra il tuo eroe è di Livello {eroeScelto.Livello}!");
                        giocatore.IsAdmin = true;
                    }
                    break;
                case 4:
                    if (eroeScelto.PuntiAccumulati <= 199)
                    {
                        eroeScelto.Livello = 4;
                        eroeScelto.PuntiVita = 80;
                        giocatore.IsAdmin = true;
                    }
                    else if (eroeScelto.PuntiAccumulati >= 120)
                    {
                        eroeScelto.PuntiAccumulati = 0;
                        eroeScelto.Livello = 5;
                        eroeScelto.PuntiVita = 100;
                        Console.WriteLine($"Complimenti, grazie ai punti che hai accumulato, il tuo eroe {eroeScelto.Nome} è passato al Livello successivo.\nOra il tuo eroe è di Livello {eroeScelto.Livello}!");
                        giocatore.IsAdmin = true;
                    }
                    break;
                case 5:
                    if (eroeScelto.PuntiAccumulati >= 120)
                    {

                        eroeScelto.Livello = 5;
                        eroeScelto.PuntiVita = 100;
                        giocatore.IsAdmin = true;
                    }
                    break;

            }
        }

        private static void Partita(Eroe eroeScelto, Mostro mostroScelto, Giocatore giocatore)
        {

            Console.WriteLine($"\nBene {giocatore.Nome}, giochiamo!");
            bool continua = true;


            int sceltaAzione;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nDigita 1 per Attaccare il mostro");
                Console.WriteLine("Digita 2 per Fuggire");
                Console.WriteLine("Digita 0 per uscire");
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Non sei riuscito a fuggire");
                Console.ForegroundColor = ConsoleColor.White;
                AttaccaMostro(eroeScelto, mostroScelto, continua, giocatore);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fuga riuscita");
                Console.ForegroundColor = ConsoleColor.White;
                eroeScelto.PuntiAccumulati = eroeScelto.PuntiAccumulati - (mostroScelto.Livello * 5);
                Console.WriteLine($"Ora il tuo eroe possiede {eroeScelto.PuntiAccumulati} punti");

                ContinuareGioco(eroeScelto, mostroScelto, giocatore);
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nComplimenti, il tuo eroe ha vinto!");
                eroeScelto.PuntiAccumulati = eroeScelto.PuntiAccumulati + (mostroScelto.Livello * 10);
                Console.WriteLine($"Ora il tuo eroe possiede {eroeScelto.PuntiAccumulati} punti");
                Console.ForegroundColor = ConsoleColor.White;


                ContinuareGioco(eroeScelto, mostroScelto, giocatore);
            }
            else
            {
                mostroScelto.PuntiVita = vitaRimastaMostro;
                AttaccaMostro(eroeScelto, mostroScelto, continua, giocatore);

            }
        }

        private static void AttaccaMostro(Eroe eroeScelto, Mostro mostroScelto, bool continua, Giocatore giocatore)
        {
            Console.WriteLine("\n------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nIl mostro {mostroScelto.Nome} attacca l'eroe {eroeScelto.Nome}");
            Console.ForegroundColor = ConsoleColor.White;
            int vitaRimastaEroe = eroeScelto.PuntiVita - mostroScelto._Arma.PuntiDanno;
            Console.WriteLine($"\nI punti vita del tuo eroe ora sono: {vitaRimastaEroe}");


            if (vitaRimastaEroe <= 0)
            {
                Console.WriteLine($"\nPeccato, il tuo eroe ha perso!");
                Console.WriteLine($"Ora il tuo eroe possiede {eroeScelto.PuntiAccumulati} punti");

                ContinuareGioco(eroeScelto, mostroScelto, giocatore);
            }
            else
            {

                eroeScelto.PuntiVita = vitaRimastaEroe;
                continua = true;
            }

        }

        private static void ContinuareGioco(Eroe eroeScelto, Mostro mostroScelto, Giocatore giocatore)
        {
            CalcoloLivello(eroeScelto, giocatore);
            Console.WriteLine("\n\nVuoi continuare a giocare? Scrivi Si o No");
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
                        Console.WriteLine("\nOk, giocherai ancora con l'eroe");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{eroeScelto.Print()}\n");
                        Console.ForegroundColor = ConsoleColor.White;
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
    }

}


