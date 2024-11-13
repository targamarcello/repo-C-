using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoItinere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Autonoleggio";
            Flotta flotta = new Flotta("FLOTTA");
            flotta.Autorizzazione = Governo.GeneraAutorizzazione();
            int scelta = 0, temp = 0, disponibili = 0;
            string t = " ";
            string[] opzioni = { "Inserimento", "Visualizza", "Elimina", "Ricerca", "Veicoli disponibili", "Ricerca posti", "Esci" };
            do
            {
                Menu(opzioni);
                Console.WriteLine("Che scelta vuoi fare?");
                int.TryParse(Console.ReadLine(), out scelta);
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("===Inserimento===");
                        Inserimento(flotta);
                        break;
                    case 2:
                        Console.WriteLine("===Visualizza===");
                        Console.WriteLine("Autorizzazione Statale: [{0}]", flotta.Autorizzazione);
                        flotta.Stampa();
                        break;
                    case 3:

                        Console.WriteLine("===Elimina===");
                        if (Ricerca() == 1)
                        {
                            Console.Write("Inserisci la targa del veicolo da ricercare: ");
                            t = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Inserisci codice del veicolo da ricercare: ");
                            int.TryParse(Console.ReadLine(), out temp);
                        }
                        if (flotta.Elimina(temp, t) == 0)
                            Console.WriteLine("Nessun elemento presente con questa targa o codice");
                        break;
                    case 4:

                        Console.WriteLine("===Ricerca===");
                        if (Ricerca() == 1)
                        {
                            Console.Write("Inserisci la targa del veicolo da eliminare: ");
                            t = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Inserisci codice del veicolo da eliminare: ");
                            int.TryParse(Console.ReadLine(), out temp);
                        }
                        Veicolo veicoloRicercato = flotta.Ricerca(temp, t);
                        if (veicoloRicercato != null)
                        {
                            Console.WriteLine("Informazioni del veicolo trovato:");
                            Console.WriteLine(veicoloRicercato);
                        }
                        else
                        {
                            Console.WriteLine("Nessun veicolo trovato con questa targa o codice.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("===Veicoli disponibili===");
                        Console.Write("Inserisci marca veicoli da ricercare: ");
                        t = Console.ReadLine();
                        Console.WriteLine("MARCA: {0}, DISPONIBILITA': {1} elementi", t, flotta.Disponibili(t));
                        break;
                    case 6:
                        Console.WriteLine("===Numero veicoli per posti===");
                        Console.WriteLine("Inserisci il numero di posti:");

                        switch (SceltaPosti())
                        {
                            case 1:
                                disponibili = flotta.RicercaPosti(numeroPosti.due_posti);
                                break;
                            case 2:
                                disponibili = flotta.RicercaPosti(numeroPosti.quattro_posti);
                                break;
                            case 3:
                                disponibili = flotta.RicercaPosti(numeroPosti.cinque_posti);
                                break;
                            case 4:
                                disponibili = flotta.RicercaPosti(numeroPosti.otto_posti);
                                break;
                        }
                        Console.WriteLine("Veicoli disponibili {0}", disponibili);
                        break;
                    case 7:
                        Console.WriteLine("Fine");
                        break;
                }
                if (scelta != 7)
                {
                    Console.WriteLine("Premi invio per uscire");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (scelta != 7);
        }

        static int SceltaPosti()
        {
            int scelta = 0;
            string[] posti = Enum.GetNames(typeof(numeroPosti));
            for (int i = 0; i < posti.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {posti[i]}");
            }
            Console.WriteLine("Che scelta vuoi fare");
            int.TryParse(Console.ReadLine(), out scelta);
            while (scelta < 1 || scelta > posti.Length)
            {
                Console.WriteLine("Inserisci un opzione valida");
                int.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }

        static void Inserimento(Flotta f)
        {
            Veicolo brumbrum = new Veicolo();
            brumbrum.Targa = Governo.GeneraTarga();
            Console.Write("Inserisci marca: ");
            brumbrum.Marca = Console.ReadLine();
            Console.Write("Inserisci modello: ");
            brumbrum.Modello = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di posti:");
            switch (SceltaPosti())
            {
                case 1:
                    brumbrum.Posti = numeroPosti.due_posti;
                    break;
                case 2:
                    brumbrum.Posti = numeroPosti.quattro_posti;
                    break;
                case 3:
                    brumbrum.Posti = numeroPosti.cinque_posti;
                    break;
                case 4:
                    brumbrum.Posti = numeroPosti.otto_posti;
                    break;
            }
            brumbrum.Codice = Veicolo.Code;
            f.Aggiungi(brumbrum);
            ScriviFile(Path.Combine(Environment.CurrentDirectory, "logbin", "log.txt"), brumbrum.ToString());
        }

        static void Menu(string[] opt)
        {
            for (int i = 0; i < opt.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i + 1, opt[i]);
            }
        }

        static void ScriviFile(string path, string stringa)
        {
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(DateTime.Now.ToString() + " " + stringa);
            sw.Close();
        }

        static int Ricerca()
        {
            int scelta;
            Console.WriteLine("[1] Targa");
            Console.WriteLine("[2] Codice");
            Console.Write("Con cosa vuoi effetturare la ricerca? -> ");
            int.TryParse(Console.ReadLine(), out scelta);
            while (scelta < 1 || scelta > 2)
            {
                Console.WriteLine("Inserisci un opzione valida");
                int.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }
    }
}
