using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModificaMorraCinese
{
    internal class Program
    {
        enum Mossa
        {
            Nullo,
            Sasso,
            Carta,
            Forbice
        }
        enum Vincitore
        {
            Pareggio,
            Uno,
            Due
        }
        struct Game
        {
            public Mossa mossa1, mossa2;
            public Vincitore vincitore;
        }
        struct Giocatore
        {
            public string nome;
            public int punti;
        }
        static void Main(string[] args)
        { 
            const int Npartite = 10;
            int i, giocate = 0;
            Game[] partite = new Game[Npartite];
            Giocatore giocatore1, giocatore2;
            ConsoleKey key;
            giocatore1.punti = giocatore2.punti = 0;
            Console.Write("Nome giocatore uno:");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("Nome giocatore due:");
            giocatore1.nome = Console.ReadLine();
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.CursorTop--;
            giocatore2.nome = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Legenda mosse:");
            Console.Write("A = carta");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("J = carta");
            Console.Write("S = sasso");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("K = sasso");
            Console.Write("D = forbici");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("L = forbici");
            Console.Write("Punteggio:");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("Punteggio:");
            Console.WriteLine();
            do
            {
                Console.SetCursorPosition(11, 7);
                Console.Write(giocatore1.punti);
                Console.SetCursorPosition(Console.WindowWidth / 2 + 11, 7);
                Console.Write(giocatore2.punti);
                Console.SetCursorPosition(0, 9);
                for (i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r");
                Console.Write("{0} inserisci la mossa: ", giocatore1.nome);
                do
                {
                    key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.A:
                            partite[giocate].mossa1 = Mossa.Carta;
                            break;
                        case ConsoleKey.S:
                            partite[giocate].mossa1 = Mossa.Sasso;
                            break;
                        case ConsoleKey.D:
                            partite[giocate].mossa1 = Mossa.Forbice;
                            break;
                    }
                } while (partite[giocate].mossa1 == Mossa.Nullo && key != ConsoleKey.X);
                if (key == ConsoleKey.X)
                {
                    break;
                }
                Console.Write("\r");
                for (i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r");
                Console.Write("{0} inserisci la mossa: ", giocatore2.nome);
                do
                {
                    key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.J:
                            partite[giocate].mossa2 = Mossa.Carta;
                            break;
                        case ConsoleKey.K:
                            partite[giocate].mossa2 = Mossa.Sasso;
                            break;
                        case ConsoleKey.L:
                            partite[giocate].mossa2 = Mossa.Forbice;
                            break;
                    }
                } while (partite[giocate].mossa2 == Mossa.Nullo);
                Console.Write("\r");
                for (i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r");
                if (
                    (partite[giocate].mossa1 == Mossa.Carta && partite[giocate].mossa2 == Mossa.Sasso) ||
                    (partite[giocate].mossa1 == Mossa.Sasso && partite[giocate].mossa2 == Mossa.Forbice) ||
                    (partite[giocate].mossa1 == Mossa.Forbice && partite[giocate].mossa2 == Mossa.Carta)
                )
                {
                    Console.Write("{0} ha vinto ", giocatore1.nome);
                    giocatore1.punti++;
                    partite[giocate].vincitore = Vincitore.Uno;
                }
                else if (
                    (partite[giocate].mossa2 == Mossa.Carta && partite[giocate].mossa1 == Mossa.Sasso) ||
                    (partite[giocate].mossa2 == Mossa.Sasso && partite[giocate].mossa1 == Mossa.Forbice) ||
                    (partite[giocate].mossa2 == Mossa.Forbice && partite[giocate].mossa1 == Mossa.Carta)
                )
                {
                    Console.Write("{0} ha vinto ", giocatore2.nome);
                    giocatore2.punti++;
                    partite[giocate].vincitore = Vincitore.Due;
                }
                else
                {
                    Console.Write("Avete pareggiato. ");
                }
                giocate++;
                Console.Write("Premi un tasto per continuare . . .");
                Console.ReadKey();
            } while (giocate != Npartite);
            Console.Write("\r");
            Console.WriteLine("Ecco le partite: ");
            for (i = 0; i < giocate; i++)
            {
                Console.Write("Nella {0} paritta {1} ha giocato {2} e {3} ha giocato {4}. ", i + 1, giocatore1.nome, partite[i].mossa1, giocatore2.nome, partite[i].mossa2);
                switch (partite[i].vincitore)
                {
                    case Vincitore.Uno:
                        Console.WriteLine("Ha vinto {0}", giocatore1.nome);
                        break;
                    case Vincitore.Due:
                        Console.WriteLine("Ha vinto {0}", giocatore2.nome);
                        break;
                    default:
                        Console.WriteLine("Pareggio");
                        break;
                }
            }
            Console.WriteLine();
            if (giocatore1.punti > giocatore2.punti)
            {
                Console.WriteLine("{0} ha vinto", giocatore1.nome);
            }
            else if (giocatore2.punti > giocatore1.punti)
            {
                Console.WriteLine("{0} ha vinto", giocatore2.nome);
            }
            else
            {
                Console.WriteLine("Il gioco è finito in parità");
            }
            Console.Write("Fine gioco");
            Console.ReadLine();
        }
    }
}
