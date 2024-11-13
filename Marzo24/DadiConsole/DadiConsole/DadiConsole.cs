using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace DadiConsole
{
    internal class DadiConsole
    {
        static void Main(string[] args)
        {
            string[] opz = new string[] { "START", "ESCI" };
            Menù(opz);
        }
        static void Menù(string[] opzioni)
        {
            int scelta;
            do
            {
                Console.Clear();
                Console.WriteLine("=====Gioco dei dadi in console=======");
                for (int i = 0; i < opzioni.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] {opzioni[i]}");
                }
                scelta = Convert.ToInt32(Console.ReadLine());
                switch (scelta)
                {
                    case 1:
                        InizioPartita();
                        break;
                }


            } while (scelta != opzioni.Length);
        }
        static void InizioPartita()
        {
            string nome1, nome2, risp;
            Console.WriteLine("Inserire numero round");
            int nRound = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserire nome giocatore1");
            nome1 = Console.ReadLine();
            Console.WriteLine("Inserire nome giocatore2");
            nome2 = Console.ReadLine();
            Partita partita = new Partita(nRound, nome1, nome2, 6);
            do
            {
                while (partita.FinePartita != true)
                {
                    Console.WriteLine(partita.Winner());
                    Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine(partita.GameWin());
                Console.WriteLine("Vuoi giocare ancora? (S/N)");
                do
                {
                    risp = Console.ReadLine().ToUpper();
                } while (String.IsNullOrEmpty(risp));
                if (risp == "S")
                {
                    partita.ResetGame();
                }
            } while (risp != "N");
        }
    }
}
