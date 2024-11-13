using System;
using System.Collections.Generic;

namespace VerificaLista
{
    internal class Program
    {
        struct Anagrafica
        {
            public string nome;
            public string cognome;
            public double voto;
            public DateTime dataNascita;
            public override string ToString()
            {
                return string.Format($"{nome,-10}  {cognome,-10}  {dataNascita.ToShortDateString(),-10}  {voto,-10}");
            }
        }
        static void Main(string[] args)
        {
            List<Anagrafica> persone = new List<Anagrafica>();
            string titolo = "=====CLASSE=====";
            string[] opzioni = new string[] { "Inserimento", "Visualizza", "Visualizza classe solo maggiorenni", "Esci" };
            Menu(opzioni, titolo, 10, 0, ConsoleColor.White, ConsoleColor.Green, ConsoleColor.Blue, persone);
        }
        static void Menu(string[] opzioni, string titolo, int x, int y, ConsoleColor coloreTitolo, ConsoleColor coloreTesto, ConsoleColor coloreSfondo, List<Anagrafica> persone)
        {
            int temp = y;
            int scelta;
            int prova;
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
                    Opzione(scelta, persone);
                }
            } while (prova != opzioni.Length);
        }
        static void GiustificaOpzione(string[] frase, ref int x, ref int y, string titolo)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(titolo);
            y++;
            for (int i = 0; i < frase.Length; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine($"[{i + 1}] {frase[i]} ");
                y++;
            }
        }
        static void Opzione(int scelta, List<Anagrafica> persone)
        {
            int id, pos, i = 0;
            char risposta;
            switch (scelta)
            {
                case 1:
                    if (i != 3)
                    {
                        Console.WriteLine("Vuoi inserire un nuovo studente? (S/N)");
                        risposta= Convert.ToChar(Console.ReadLine().ToUpper());
                        if(risposta=='S')
                        Inserimento(ref i, persone);
                    }
                    else
                    {
                        Console.WriteLine("Classe piena!!!");
                    }
                    break;
                case 2:
                    Visualizza(persone);
                    break;
                case 3:
                    List<Anagrafica> maggiorenni = persone.FindAll(RicercaMaggiorenni);
                    VisualizzaMaggiorenni(maggiorenni);
                    break;
            }
        }
        static void Inserimento(ref int i, List<Anagrafica> persone)
        {
            string data;
            int anno, mese, giorno, voto=0;
            bool verificato = false;
            Anagrafica studente = new Anagrafica();
            do
            {
                Console.WriteLine("Inserisci il nome");
                while (String.IsNullOrEmpty(studente.nome = Console.ReadLine()))
                {

                    Console.WriteLine("Inserire nuovo nome, quello precedente non era valido");
                }
                Console.WriteLine("Inserisci il cognome");
                while (String.IsNullOrEmpty(studente.cognome = Console.ReadLine()))
                {
                    Console.WriteLine("Inserire nuovo cognome, quello precedente non era valido");
                }
                do
                {
                    Console.WriteLine("Inserisci data nascita");
                    data = Console.ReadLine();
                    EstraiData(data, out anno, out mese, out giorno);
                    verificato = DataValida(anno, mese, giorno);
                } while (verificato);
                studente.dataNascita = Convert.ToDateTime(data);
                do
                {
                    try
                    {
                        Media(ref voto);
                    }catch( Exception v)
                    {
                        Console.WriteLine(v.Message);
                        verificato = true;
                    }

                }while(verificato);
                studente.voto = voto;
            } while (ControlloDoppione(studente, persone));
            Console.Clear();
            persone.Add(studente);
            i++;
        }
        static void EstraiData(string data, out int anno, out int mese, out int giorno)
        {
            string[] estrattore = data.Split('/');
            giorno = Convert.ToInt32(estrattore[0]);
            mese = Convert.ToInt32(estrattore[1]);
            anno = Convert.ToInt32(estrattore[2]);
        }
        static void Visualizza(List<Anagrafica> persone)
        {
            foreach (Anagrafica a in persone)
            {
                Console.WriteLine($"Nome = {a.nome}\nCognome = {a.cognome}\nData Nascita = {a.dataNascita.ToString()}\nVoto = {a.voto.ToString()}");
                Console.WriteLine("=============================");
            }
            Console.ReadLine();
        }
        static void VisualizzaMaggiorenni(List<Anagrafica> maggiorenni)
        {
            foreach (Anagrafica m in maggiorenni)
            {
                Console.WriteLine($"Nome = {m.nome}");
                Console.WriteLine($"Cognome = {m.cognome}");
                Console.WriteLine($"Data Nascita = {m.dataNascita.ToString()}");
                Console.WriteLine($"Voto = {m.voto.ToString()}");
            }
            Console.ReadLine();
        }
        static bool DataValida(int anno, int mese, int giorno)
        {
            bool dataInvalida = false;
            if (anno < 0)
            {
                dataInvalida = true;
            }
            else if (mese < 0 || mese > 12)
            {
                dataInvalida = true;
            }
            if ((mese == 1 || mese == 3 || mese == 5 || mese == 7 || mese == 8 || mese == 10 || mese == 12) && giorno > 31)
            {
                dataInvalida = true;
            }
            else if ((mese == 4 || mese == 6 || mese == 9 || mese == 11) && giorno > 30)
            {
                dataInvalida = true;
            }
            else if ((mese == 2) && giorno > 29)
            {
                dataInvalida = true;
            }
            return dataInvalida;
        }
        static bool RicercaMaggiorenni(Anagrafica p1)
        {
            return (DateTime.Now.Year - p1.dataNascita.Year) >= 18;
        }
        static bool ControlloDoppione(Anagrafica studente,List<Anagrafica> persone)
        {
            bool doppione= false;
            if(persone.Exists(e => e.nome == studente.nome) && persone.Exists(e => e.cognome == studente.cognome))
            {
                Console.WriteLine("Studente già presente, inserire nuovo studente");
                doppione = true;
            }
            return doppione;
        }
        static void Media(ref int voto)
        {
            Console.WriteLine("Inserisci voto");
            if(!int.TryParse(Console.ReadLine(), out voto))
            {
                if(voto<1 || voto > 10)
                {
                    throw new Exception("voto non valido");
                }
            }
        }
    }
}