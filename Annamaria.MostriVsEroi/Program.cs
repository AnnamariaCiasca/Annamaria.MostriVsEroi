using Annamaria.MostriVsEroi.AdoRepository;
using Annamaria.MostriVsEroi.Core.BusinessLayer;
using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Mock;
using System;
using System.Collections.Generic;
using System.Threading;


namespace Annamaria.MostriVsEroi
{

  
    class Program
    {
        //private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryArmi(), new RepositoryCategorie(), new RepositoryEroi(), new RepositoryGiocatori(), new RepositoryMostri());
        private static readonly IBusinessLayer bl = new BusinessLayer(new AdoRepositoryArma(), new AdoRepositoryCategoria(), new AdoRepositoryEroe(), new AdoRepositoryGiocatore(), new AdoRepositoryMostro());


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

        private static void Registrati() //OK
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

        private static void Accedi() //OK
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
            else
            {
                Console.WriteLine("Username e/o Password errati");
            }

        }

        private static void MenuNotAdmin(Giocatore giocatore) //OK
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

        private static void MenuAdmin(Giocatore giocatore) //OK
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

        private static void MostraClassifica()  //OK
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------Classifica---------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            List<Eroe> eroiClassifica = bl.FetchEroiPerPunti();
         
            string username;
            int i = 1;
            foreach (var item in eroiClassifica)
            {
                username = bl.UserGiocatoreById(item.IdGiocatore);
      
                Console.WriteLine($"{i}) Eroe: {item.Nome} - Livello: {item.Livello} - Punti: {item.PuntiAccumulati} - Giocatore: {username}");
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void EliminaEroe(Giocatore giocatore) //OK
        {
            Console.Clear();
            int scelta;
            Console.WriteLine("Ecco la lista degli eroi:\n");
          

            List<Eroe> eroi = bl.FetchEroiByGiocatore(giocatore.Id);  
                                                                   
            foreach (var item in eroi)
            {
                Console.WriteLine($"Nome: {item.Nome}  - Livello: {item.Livello} - Punti Vita: {item.PuntiVita}");
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
            Eroe eroeDaCancellare = new Eroe();
            eroeDaCancellare = bl.GetEroeById(scelta);
            bl.EliminaEroe(eroeDaCancellare);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("L'eroe selezionato è stato eliminato correttamente");
            Console.ForegroundColor = ConsoleColor.White;


        }


        private static void CreaEroe(Giocatore giocatore)  //OK
        {
            Eroe eroe = new Eroe();
            bool continua = true;
          
            string nome;
            bool trovato = false;
            do
            {
                bool riprova;
             
                do
                {
                    riprova = false;
                    Console.WriteLine("Inserisci un nome per il tuo eroe");
                    nome = Console.ReadLine();
                    eroe.Nome = nome;

                    List<Eroe> eroi = bl.FetchEroi();

                    foreach (var item in eroi)
                    {
                        if (item.Nome == nome)
                        {
                            trovato = true;
                            riprova = true;
                            break;
                        }
                    }
                    if (trovato)
                    {
                        Console.WriteLine("\nNome già in uso per un altro eroe\nRiprova:\n");
                        trovato = false;
                    }
                } while(riprova == true);
                
                if (trovato == false) 
                {
                    Console.WriteLine("\nScegli la categoria per il tuo eroe:");

                    List<Categoria> categorie = bl.FetchCategorieEroi();


                    foreach (var item in categorie)
                    {
                        Console.WriteLine($"Digita {item.Id} per scegliere la Categoria {item.Nome}");
                    }

                    int categoriaScelta;

                    while (!int.TryParse(Console.ReadLine(), out categoriaScelta) || categoriaScelta > categorie.Count)
                    {
                        Console.WriteLine("Inserire valore corretto!");
                    }

                    Categoria categoriaEroe = bl.GetCategoriaById(categoriaScelta);


                    Console.WriteLine("\n\nScegli l'arma per il tuo eroe:");
                    List<Arma> armi = bl.FetchArmiPerCategoria(categoriaScelta);

                    foreach (var item in armi)
                    {
                        Console.WriteLine($"Digita {item.Id} per scegliere l'arma {item.Nome} che ha punti danno pari a {item.PuntiDanno}");
                    }

                    int armaScelta;

                    while (!int.TryParse(Console.ReadLine(), out armaScelta) || armaScelta > armi.Count)
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

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Eroe creato correttamente.");
                    Console.ForegroundColor = ConsoleColor.White;

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


        private static void CreaMostro(Giocatore giocatore)  //OK
        {
            Mostro mostro = new Mostro();
            bool continua = true;
            bool trovato = false;
            string nome;
            do
            {
                bool riprova;
                do
                {
                    riprova = false;
                    Console.WriteLine("Inserisci un nome per il tuo mostro");
                    nome = Console.ReadLine();
                    mostro.Nome = nome;

                    List<Mostro> mostri = bl.FetchMostri();



                    foreach (var item in mostri)
                    {
                        if (item.Nome == nome)
                        {
                            trovato = true;
                            riprova = true;

                            break;
                        }
                    }
                    if (trovato)
                    {
                        Console.WriteLine("\nNome già in uso per un altro mostro\nRiprova:\n");
                        trovato = false;
                    }
                } while (riprova == true);
                if(trovato == false)
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
                    mostro = bl.InserisciMostro(mostro, categoriaScelta, armaScelta);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMostro creato correttamente.");
                    Console.ForegroundColor = ConsoleColor.White;

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


        private static void Gioca(Giocatore giocatore) //OK
        {
            Console.Clear();
            int scelta;
            Console.WriteLine("Ecco la lista degli eroi con cui puoi giocare:\n");
            Categoria categoria = new Categoria();
            Arma arma = new Arma();
            List<Eroe> eroi = bl.FetchEroiByGiocatore(giocatore.Id);
            foreach (var item in eroi)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(item.Print());

                categoria = bl.GetCategoriaByEroe(item);
                arma = bl.GetArmaByEroe(item);

                Console.WriteLine($"Nome: {item.Nome} - Categoria: {categoria.Nome} - Arma: {arma.Nome} con PuntiDanno: {arma.PuntiDanno} - Livello: {item.Livello} - Punti Vita: {item.PuntiVita} - Punti Accumulati: {item.PuntiAccumulati}");
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

        private static void GenerazioneMostro(Eroe eroeScelto, Giocatore giocatore) //OK
        {
            CalcoloLivello(eroeScelto, giocatore);
            Mostro mostroScelto = bl.GeneraMostro(eroeScelto.Livello);
            Categoria categoria = new Categoria();
            Arma arma = new Arma();

            categoria = bl.GetCategoriaByMostro(mostroScelto);
            arma = bl.GetArmaByMostro(mostroScelto);


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
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Nome: {mostroScelto.Nome} - Categoria: {categoria.Nome} - Arma: {arma.Nome} con PuntiDanno: {arma.PuntiDanno} - Livello: {mostroScelto.Livello} - Punti Vita: {mostroScelto.PuntiVita} ");
            Console.ForegroundColor = ConsoleColor.White;

            Partita(eroeScelto, mostroScelto, giocatore);
        }

        private static void CalcoloLivello(Eroe eroeScelto, Giocatore giocatore) //OK
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

        private static void Partita(Eroe eroeScelto, Mostro mostroScelto, Giocatore giocatore) //OK
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

        private static void Fuggi(Eroe eroeScelto, Mostro mostroScelto, bool continua, Giocatore giocatore) //OK
        {
            Console.Clear();
            Console.WriteLine("\n--------------------------------------TURNO DELL'EROE---------------------------------------");
            Random r = new Random();
            int uscita = r.Next(0, 2);
            bool fugaRiuscita = Convert.ToBoolean(uscita);
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
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
                if(eroeScelto.PuntiAccumulati <= 0)  //non faccio andare punti accumulati in negativo
                {
                    eroeScelto.PuntiAccumulati = 0;
                }
                Console.WriteLine($"Ora il tuo eroe possiede {eroeScelto.PuntiAccumulati} punti");

                ContinuareGioco(eroeScelto, mostroScelto, giocatore);
            }

        }

        private static void AttaccaEroe(Eroe eroeScelto, Mostro mostroScelto, bool continua, Giocatore giocatore) //OK
        {
            
            Categoria categoriaEroe = new Categoria();
            Arma armaEroe = new Arma();

            categoriaEroe = bl.GetCategoriaByEroe(eroeScelto);
            armaEroe = bl.GetArmaByEroe(eroeScelto);

            Console.Clear();
            Console.WriteLine("\n--------------------------------------TURNO DELL'EROE---------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nL'eroe {eroeScelto.Nome} attacca il mostro {mostroScelto.Nome} con l'arma {armaEroe.Nome} infliggendogli {armaEroe.PuntiDanno} punti danno");
            Console.ForegroundColor = ConsoleColor.White;

            //int vitaRimastaMostro = mostroScelto.PuntiVita - eroeScelto._Arma.PuntiDanno;
            int vitaRimastaMostro = mostroScelto.PuntiVita - armaEroe.PuntiDanno;

           
            if (vitaRimastaMostro <= 0)
            {
                vitaRimastaMostro = 0; //per non fargli assumere valori negativi
                Console.WriteLine($"\nI punti vita del mostro ora sono: 0 ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nComplimenti, il tuo eroe ha vinto!");
                eroeScelto.PuntiAccumulati = eroeScelto.PuntiAccumulati + (mostroScelto.Livello * 10);
                Console.WriteLine($"Ora il tuo eroe possiede {eroeScelto.PuntiAccumulati} punti");
                Console.ForegroundColor = ConsoleColor.White;


                ContinuareGioco(eroeScelto, mostroScelto, giocatore);
            }
            else
            {
                Console.WriteLine($"\nI punti vita del mostro ora sono: {vitaRimastaMostro}");
                mostroScelto.PuntiVita = vitaRimastaMostro;
                AttaccaMostro(eroeScelto, mostroScelto, continua, giocatore);

            }
        }

        private static void AttaccaMostro(Eroe eroeScelto, Mostro mostroScelto, bool continua, Giocatore giocatore) //OK
        {
            Console.WriteLine("\n--------------------------------------TURNO DEL MOSTRO--------------------------------------");
            Categoria categoriaMostro = new Categoria();
            Arma armaMostro = new Arma();

            categoriaMostro = bl.GetCategoriaByMostro(mostroScelto);
            armaMostro = bl.GetArmaByMostro(mostroScelto);

         
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nIl mostro {mostroScelto.Nome} attacca l'eroe {eroeScelto.Nome} con l'arma {armaMostro.Nome} infliggendogli {armaMostro.PuntiDanno} punti danno");
            Console.ForegroundColor = ConsoleColor.White;
            int vitaRimastaEroe = eroeScelto.PuntiVita - armaMostro.PuntiDanno;
            Console.WriteLine($"\nI punti vita del tuo eroe ora sono: {vitaRimastaEroe}");


            if (vitaRimastaEroe <= 0)
            {
                vitaRimastaEroe = 0; //lo faccio per non fargli assumere valori negativi
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

        private static void ContinuareGioco(Eroe eroeScelto, Mostro mostroScelto, Giocatore giocatore) //OK
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
                        Console.WriteLine($"{eroeScelto.Nome}\n");
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


