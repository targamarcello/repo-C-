using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagraficaElimina
{
    class Program
    {
        enum Sesso
        {
            maschio,
            femmina,
        }
        enum StatoCivile
        {
            Celibe,//uomo non sposato
            Nubile,
            Coniugato,
            Divorziato,
            Separato
        }
        struct persona
        {
            public string nome;
            public string cognome;
            public DateTime dataNascita;
            public StatoCivile statocivile;
            public Sesso sesso;
            public string cittadinanza;
            public int idFiscale;
            public int età;
            public string codiceFiscale;
            public override string ToString()
            {
                return string.Format($"{nome,-15} {cognome,-15} {dataNascita.ToShortDateString(),-10} {statocivile,-10} {sesso,-10} {cittadinanza,-10}");
            }
        }
        static void Main(string[] args)
        {
            persona[] Cittadino = new persona[3];
            string[] stato = new string[3] {"Libero", "Libero","Libero"};
            int i = 0;
            string titolo = "===============ANAGRAFE===============";
            string[] opzioni = new string[] { "Inseriemnto", "Visualizza", "Modifica Stato Civile","Calcolo Età","Elimina", "Esci" };
            Menu(opzioni, titolo, 10, 0, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Magenta, Cittadino, i, stato);
        }
        static void Inserimento(persona[] Cittadino, ref int i, ref string cod, string[]stato)
        {
            Sesso tipo;
            StatoCivile statoCiv = StatoCivile.Separato;
            Console.WriteLine("Inserisci il tuo nome");
            Cittadino[i].nome = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo cognome");
            Cittadino[i].cognome = Console.ReadLine();
            Console.WriteLine("Inserisci la tua data di nascità");
            Cittadino[i].dataNascita = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Inserire codice fiscale");
            cod = Console.ReadLine();
            while (!CodiceFisc(cod, Cittadino, i))
            {
                Console.WriteLine("Codice fiscale non valido, inserire nuovo codice fiscale:");
                cod = Console.ReadLine();
            }
            Cittadino[i].codiceFiscale = cod;
            Console.WriteLine("Inserisci la tua cittadinanza");
            Cittadino[i].cittadinanza = Console.ReadLine();
            Cittadino[i].statocivile = Stato(statoCiv);
            Console.WriteLine("che sesso sei? Maschio [1] o femmina [2]");
            int scelta = Convert.ToInt32(Console.ReadLine());
            Cittadino[i].sesso = genere(scelta, out tipo);
            stato[i] = "Occupato";
            i++;
        }
        static void Visualizza(persona[] Cittadino, string[]stato)
        {
            
            for (int i = 0; i < Cittadino.Length; i++)
            {
                Console.WriteLine("nome:{0}", Cittadino[i].nome);
                Console.WriteLine("cognome:{0}", Cittadino[i].cognome);
                Console.WriteLine("nascità:{0}", Cittadino[i].dataNascita.ToShortDateString().ToString());
                Console.WriteLine("stato civile:{0}", Cittadino[i].statocivile.ToString());
                Console.WriteLine("sesso:{0}", Cittadino[i].sesso.ToString());
                Console.WriteLine("cittadinanza:{0}", Cittadino[i].cittadinanza);
                Console.WriteLine("Stato collezione:{0}", stato[i]);
                Console.WriteLine("=============================================================================");
            }
            Console.ReadLine();
        }
        static void Menu(string[] opzioni, string titolo, int x, int y, ConsoleColor coloreTitolo, ConsoleColor coloreTesto, ConsoleColor coloreSfondo, persona[] Cittadino, int i, string[]stato)
        {
            int temp = y; // per salvare valore (mandatory)
            int scelta;
            int prova;
            Sesso tipo;
            do
            {
                y = temp;
                Console.ForegroundColor = coloreTitolo;
                Console.BackgroundColor = coloreSfondo;
                Console.Clear();
                GiustificaOpzione(opzioni, ref x, ref y, titolo);
                do
                {
                    prova = Convert.ToInt32(Console.ReadLine());
                } while (prova < 1 || prova > opzioni.Length);
                if (prova != opzioni.Length)
                {
                    scelta = prova;
                    Opzione(scelta, Cittadino, ref i, stato);
                }
            } while (prova != opzioni.Length);
        }
        static void GiustificaOpzione(string[] frase, ref int x, ref int y, string TITOLO)//passo un titolo una frase e la giustifica
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(TITOLO);
            y++;
            for (int i = 0; i < frase.Length; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine($"[{i + 1}] {frase[i]} ");
                y++;
            }
        }

        static void Opzione(int scelta, persona[] Cittadino, ref int i, string[]stato)
        {
            int indice;
            string cod="";
            switch (scelta)
            {
                case 1:
                    if (i == Cittadino.Length)
                    {
                        Console.WriteLine("Hai inserito il numero massimo di persone");
                        Console.ReadLine();
                    }
                    else
                    {
                        Inserimento(Cittadino, ref i, ref cod, stato);
                    }
                    break;
                case 2:
                    Visualizza(Cittadino, stato);
                    break;
                case 3:
                    ModificaStato(Cittadino);
                    break;
                case 4:
                    CalcoloEtà(Cittadino);
                    break;
                case 5:
                    if (i != -1)
                    {
                        Console.WriteLine("Inserisci codice fiscale da eliminare");
                        indice = Ricerca(cod, Cittadino);
                        Elimina(Cittadino, ref i, indice, stato);
                        Console.WriteLine("Elimina eseguita");
                    }
                    break;
            }
        }
        static StatoCivile Stato(StatoCivile stato)
        {
            int opzione = 0;
            Console.WriteLine("Sei Nubile(1) Coniugato/a(2) Divorziata/o(3) Separato/a(4) Celibe(5) ");
            opzione = Convert.ToInt32(Console.ReadLine());
            switch (opzione)
            {
                case 1:
                    stato = StatoCivile.Nubile;
                    break;
                case 2:
                    stato = StatoCivile.Coniugato;
                    break;
                case 3:
                    stato = StatoCivile.Divorziato;
                    break;
                case 4:
                    stato = StatoCivile.Separato;
                    break;
                case 5:
                    stato = StatoCivile.Celibe;
                    break;
            }
            return stato;
        }
        static Sesso genere(int scelta, out Sesso tipo)
        {
            tipo = Sesso.maschio;
            switch (scelta)
            {
                case 2:
                    tipo = Sesso.femmina;
                    break;
            }
            return tipo;
        }
        static void ModificaStato(persona[] cittadino)
        {
            string modifica;
            int opzione, ModCittadino;
            do
            {
                Console.WriteLine("Desideri modificare lo stato civile? S/N");
                modifica = Console.ReadLine().ToUpper();
            } while (modifica != "S" && modifica != "N");
            if (modifica == "S")
            {
                if (cittadino[0].nome == " ")
                {
                    Console.WriteLine("L'anagrafica è vuota");
                }
                else
                {
                    Console.WriteLine($"Di chi vuoi cambiare lo stato civile: [0]-{cittadino[0].nome}\n[1]-{cittadino[1].nome}[2]-{cittadino[2].nome}");
                    ModCittadino = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Scegli la tua modifica:");
                    Console.WriteLine("Sei Nubile(1) Coniugato/a(2) Divorziata/o(3) Separato/a(4) Celibe(5) ");
                    opzione = Convert.ToInt32(Console.ReadLine());
                    switch (opzione)
                    {
                        case 1:
                            cittadino[ModCittadino].statocivile = StatoCivile.Nubile;

                            break;
                        case 2:
                            cittadino[ModCittadino].statocivile = StatoCivile.Coniugato;
                            break;
                        case 3:
                            cittadino[ModCittadino].statocivile = StatoCivile.Divorziato;
                            break;
                        case 4:
                            cittadino[ModCittadino].statocivile = StatoCivile.Separato;
                            break;
                        case 5:
                            cittadino[ModCittadino].statocivile = StatoCivile.Celibe;
                            break;
                    }
                }
            }
        }
        static int CalcoloEtà(persona [] cittadino)
        {
            int data= DateTime.Today.Year;
            int età = 0, dataNascit, sceltaCalcolo;
            string calcolo;
            Console.WriteLine("Vuoi calcolare l'età di qualcuno dentro all'anagrafica? S/N");
            calcolo = Console.ReadLine().ToUpper();
            if (calcolo== "S")
            {
                Console.WriteLine($"Di chi vuoi calcolare la data: [0]-{cittadino[0].nome}\n[1]{cittadino[1].nome}\n[2]{cittadino[2].nome}");
                sceltaCalcolo = Convert.ToInt32(Console.ReadLine());
                switch (sceltaCalcolo)
                {
                    case 0:
                        dataNascit = cittadino[0].dataNascita.Year;
                        if (data <= dataNascit)
                        {
                            età = data - dataNascit;
                        }
                        else
                        {
                            Console.WriteLine("Data non valida!!");
                        }
                        Console.WriteLine($"Il cittadino {cittadino[0].nome} ha {età} anni");
                        Console.ReadLine();
                        break;
                    case 1:
                        dataNascit = cittadino[1].dataNascita.Year;
                        if (data <= dataNascit)
                        {
                            età = data - dataNascit;
                        }
                        else
                        {
                            Console.WriteLine("Data non valida!!");
                        }
                        Console.WriteLine($"Il cittadino {cittadino[1].nome} ha {età} anni");
                        Console.ReadLine();
                        break;
                    case 2:
                        dataNascit = cittadino[2].dataNascita.Year;
                        if (data <= dataNascit)
                        {
                            età = data - dataNascit;
                        }
                        else
                        {
                            Console.WriteLine("Data non valida!!");
                        }
                        Console.WriteLine($"Il cittadino {cittadino[2].nome} ha {età} anni");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nessun calcolo eseguito");
            }
            return età;
        }
        static bool CodiceFisc(string cod, persona[] cittadino, int indice)
        {
            for(int i=0; i<indice; i++)
            {
                if (cod == cittadino[i].codiceFiscale)
                {
                    return false;
                }
            }
            return true;
        }
        static void Elimina(persona[]cittadino, ref int i, int indice, string[]stato)
        {
            /*for(int j=indice; j<cittadino.Length-1; j++)
            {
                cittadino[j] = cittadino[j + 1];
            }
            i--;*/
            stato[i--] = "Eliminato";

        }
        static int Ricerca(string cod, persona[] cittadino)
        {
            for(int i=0; i<cittadino.Length; i++)
            {
                if (cittadino[i].codiceFiscale== cod)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
