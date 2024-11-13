using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintTestuale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey tasto;
            int riga = 0, colonna = 0;
            char matita = '*';
            int[,]posizione= new int[Console.WindowHeight, Console.WindowWidth];
            do
            {

                tasto = Console.ReadKey(true).Key;
                switch(tasto)
                {
                    case ConsoleKey.LeftArrow:
                        //movimento a sinistra
                        if (riga > 0)
                        {
                            riga--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        //movimento a destra
                        if (riga < Console.WindowWidth) ;
                        {
                            riga++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        //movimento verso l'alto
                        if (colonna >0)
                        {
                            colonna--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        //movimento verso il basso
                        if(colonna > Console.WindowHeight-1)
                        {
                            colonna++;
                        }
                        break;
                }
                if(tasto==ConsoleKey.Enter)
                {
                    riga++;
                }
                if(tasto== ConsoleKey.Tab)
                {
                    colonna++;
                }
                Console.SetCursorPosition(riga,colonna);
                Console.Write(matita);
            } while (tasto != ConsoleKey.Escape);
            Console.ReadLine();
        }
    }
}
