using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonicaCompleta
{
    internal class Program
    {
        const int maxContatti = 3;
        struct Agenda
        {
            public string nome;
            public string cognome;
            public string telefono;
        }
        static void Main(string[] args)
        {
            Agenda[] rubrica = new Agenda[maxContatti];
            int opzione, i = 0;
            const int max = 6;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Agenda Telefonica");
                    Console.WriteLine("[1] Scrittura contatto");
                    Console.WriteLine("[2] Stampa agenda");
                    Console.WriteLine("[3] Ricerca Contatto");
                    Console.WriteLine("[4] Elimina contatto");
                    Console.WriteLine("[5] Modifica contatto");
                    Console.WriteLine("[6] Uscita");
                    opzione = Int32.Parse(Console.ReadLine());
                } while (opzione < 1 || opzione > max);
                switch (opzione)
                {
                    case 1:
                        Inserimento(rubrica, ref i);
                        break;
                    case 2:
                        Visualizza(rubrica, ref i);
                        break;
                    case 3:
                        Ricerca(rubrica, ref i);
                        break;
                    case 4:
                        Cancellazione(rubrica, ref i);
                        break;
                    case 5:
                        Modifica(rubrica, ref i);
                        break;
                }
            } while (opzione != max);
        }
        static void Inserimento(Agenda[] rubrica, ref int i)
        {
            if (i != rubrica.Length)
            {
                Console.WriteLine("Inserisci nome contatto");
                rubrica[i].nome = Console.ReadLine();
                Console.WriteLine("Inserisci cognome contatto");
                rubrica[i].cognome = Console.ReadLine();
                do
                {
                    Console.WriteLine("Inserisci numero contatto");
                    rubrica[i].telefono = Console.ReadLine();
                } while (rubrica[i].telefono.Length < 10 || rubrica[i].telefono.Length > 10);
                i++;
            }
            else
            {
                Console.WriteLine("Hai inserito il numero massimo di contatti");
            }
            Console.ReadLine();
        }
        static void Visualizza(Agenda[] rubrica, ref int i)
        {
            if (i != 0)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine("Nome contatto");
                    Console.WriteLine(rubrica[j].nome);
                    Console.WriteLine("Cognome contatto");
                    Console.WriteLine(rubrica[j].cognome);
                    Console.WriteLine("Telefono");
                    Console.WriteLine(rubrica[j].telefono);
                }
            }
            else
            {
                Console.WriteLine("Non hai inserito nessun contatto");
            }
            Console.ReadLine();
        }
        static void Ricerca(Agenda[] rubrica, ref int i)
        {
            string cerca;
            bool trovato = false;
            if (i != 0)
            {
                do
                {
                    Console.WriteLine("Inserisci nome e cognome del contatto da cercare");
                    cerca = Console.ReadLine();
                } while (cerca =="");
                for (int j = 0; j < i && !trovato; j++)
                {
                    if (rubrica[j].nome + ' ' + rubrica[j].cognome == cerca)
                    {
                        Console.WriteLine("Contatto presente nella rubrica, il suo numero di telefono è {0}", rubrica[j].telefono);
                        Console.ReadLine();
                        trovato = true;

                    }
                }
                if (!trovato)
                {
                    Console.WriteLine("Contatto non presente nella rubrica");
                }
            }
            else
            {
                Console.WriteLine("Non hai inserito nessun contatto");
            }
            Console.ReadLine();
        }
        static void Cancellazione(Agenda[] rubrica, ref int i)
        {
            if (i != 0)
            {
                
            }
            else
            {
                Console.WriteLine("Non hai inserito nessun contatto");
            }
            Console.ReadLine();
        }
        static void Modifica(Agenda[] rubrica, ref int i)
        {
            string modifica;
            bool trovato = false;
            if (i != 0)
            {
                do
                {
                    Console.WriteLine("Inserisci il nome e cognome del contatto");
                    modifica = Console.ReadLine().ToLower();
                } while (modifica =="");
                for (int j = 0; j < i && !trovato; j++)
                {
                    if (modifica == rubrica[j].nome + ' ' + rubrica[j].cognome)
                    {
                        do
                        {
                            Console.WriteLine("Cosa vuoi modificare? (nome/cognome/telefono)");
                            modifica = Console.ReadLine().ToLower();
                        } while (modifica=="");
                        switch (modifica)
                        {
                            case "nome":
                                    Console.WriteLine("Inserisci nome contatto");
                                    rubrica[j].nome = Console.ReadLine();
                                break;
                            case "cognome":
                                    Console.WriteLine("Inserisci cognome contatto");
                                    rubrica[j].cognome = Console.ReadLine();
                                break;
                            case "telefono":
                                do
                                {
                                    Console.WriteLine("Inserisci numero contatto");
                                    rubrica[j].telefono = Console.ReadLine();
                                } while (rubrica[j].telefono.Length < 10 || rubrica[j].telefono.Length > 10);
                                break;
                            default:
                                Console.WriteLine("Modifca non eseguibile");
                                break;
                        }
                        trovato = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Non hai inserito nessun contatto");
            }
            Console.ReadLine();
        }
    }
}
