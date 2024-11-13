using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagraficaRovigo
{
    enum Sesso
    {
        Maschio,
        Femmina

    }
    enum statoCivile
    {
        Celibe, Nubile, Coniugato, Divorziato, Separato
    }
    struct Persona
    {
        public string nome;
        public string cognome;
        public DateTime dataNascita;
        public statoCivile statoCivile;
        public Sesso sesso;
        public string cittadinanza;
        public string codiceFiscale;//ZNNBYN06R25H620T
        public override string ToString()
        {
            return string.Format($"{nome,-15}{cognome,-15} {dataNascita.ToShortDateString(),-15}{statoCivile.ToString(),-15}{sesso.ToString(),-10}{cittadinanza,-10}");
        }

    }
    class Program
    {
        /*inserire all'interno dell'anagrafe del comune di Rovigo delle persone,
         verificando che l'archivio non sia pieno e che la persona non sia già presente, scrivendo anche il codice fiscale
         utilizzare il menù per la selezione del sesso e dello stato civile*/
        static void Main(string[] args)
        {
            string stato="";
            int indice = 0;
            const int nPersone = 3;
            Persona[] anagrafeRovigo = new Persona[nPersone];
            //Persona p2 = new Persona();
            //Visualizza2(p2);
            Persona cittadino;
            Inserimento(anagrafeRovigo, cittadino, stato, ref indice);
            Visualizza(cittadino);
            Visualizza2(cittadino);
            Console.ReadLine();

        }
        static void Visualizza(Persona cittadino)
        {
            Console.WriteLine(cittadino.nome);
            Console.WriteLine(cittadino.cognome);
            Console.WriteLine(cittadino.dataNascita.ToString());
            Console.WriteLine(cittadino.statoCivile.ToString());
            Console.WriteLine(cittadino.sesso.ToString());
            Console.WriteLine(cittadino.cittadinanza);

        }
        static void Visualizza2(Persona cittadino)
        {
            Console.WriteLine(cittadino.ToString());
        }
        static void Inserimento(Persona[] anagrafeRovigo , Persona cittadino, string stato, ref int indice )
        {
            string sesso;
            Console.WriteLine("Inserire nome");
            anagrafeRovigo[indice].nome = Console.ReadLine();
            Console.WriteLine("Inserire cognome");
            anagrafeRovigo[indice].cognome = Console.ReadLine();
            Console.WriteLine("Inserire data di nascita");
            anagrafeRovigo[indice].dataNascita = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Stato Civile: Celibe, Nobile, Coniugato, Divorziato, Separato");
            stato = Console.ReadLine();
            do
            {
                Console.WriteLine("Sei maschio o femmina? (S/M)");
                sesso = Console.ReadLine().ToLower();
                switch (sesso)
                {
                    case "maschio":
                        cittadino.sesso = Sesso.Maschio;
                        break;
                    case "femmina":
                        cittadino.sesso = Sesso.Femmina;
                        break;
                    default:
                        Console.WriteLine("Sesso non valido");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            } while ();
            indice++;
        }
    }
}
