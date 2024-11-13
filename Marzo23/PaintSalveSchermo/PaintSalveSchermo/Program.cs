using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSalveSchermo
{
    internal class Program
    {
        struct schermo
        {
            public char carattere;
        }
        static void Main(string[] args)
        {
            schermo[,]save = new schermo[Console.WindowWidth, Console.WindowHeight];
            schermo[,] presave = new schermo[Console.WindowWidth, Console.WindowHeight];
            ConsoleKey tasto;
            bool Ins = false, canc = false, esc=false;
            int riga = 0, colonna = 0;
            char matita = '*';
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
                do
                {
                    Console.SetCursorPosition(riga, colonna);

                    tasto = Console.ReadKey(true).Key;
                    switch (tasto)
                    {
                        case ConsoleKey.LeftArrow:
                            if (riga > 0)
                            {
                                riga--;
                                Console.SetCursorPosition(riga, colonna);
                                if (!Ins)
                                {
                                    Console.Write(matita);
                                }
                                if (canc)
                                {
                                    Console.Write(" ");
                                }
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (riga < Console.WindowWidth - 1)
                            {
                                riga++;
                                Console.SetCursorPosition(riga, colonna);
                                if (!Ins)
                                {
                                    Console.Write(matita);
                                }
                                if (canc)
                                {
                                    Console.Write(" ");
                                }
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (colonna > 0)
                            {
                                colonna--;
                                Console.SetCursorPosition(riga, colonna);
                                if (!Ins)
                                {
                                    Console.Write(matita);
                                }
                                if (canc)
                                {
                                    Console.Write(" ");
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (colonna < Console.WindowHeight - 1)
                            {
                                colonna++;
                                Console.SetCursorPosition(riga, colonna);
                                if (!Ins)
                                {
                                    Console.Write(matita);
                                }
                                if (canc)
                                {
                                    Console.Write(" ");
                                }
                            }
                            break;
                        case ConsoleKey.Delete:
                            if (!canc)
                            {
                                canc = true;
                                Ins = true;
                            }
                            else
                            {
                                canc = false;
                                Ins = false;
                            }
                            break;
                        case ConsoleKey.Insert:
                            if (!Ins)
                            {
                                Ins = true;
                            }
                            else
                            {
                                Ins = false;
                            }
                            break;
                        case ConsoleKey.F3:
                            matita = Convert.ToChar(Console.ReadLine());
                            Console.SetCursorPosition(riga, colonna);
                            Console.Write(" ");
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            break;
                        case ConsoleKey.F1:
                            for (int k = 0; k < Console.WindowHeight ; k++)
                            {
                                for (int m = 0; m < Console.WindowWidth; m++)
                                {
                                    save[m, k].carattere = presave[m, k].carattere;
                                }
                            }
                            break;
                        case ConsoleKey.F2:
                            for (int k = 0; k < Console.WindowHeight ; k++)
                            {
                                for (int m = 0; m < Console.WindowWidth; m++)
                                {
                                    Console.WriteLine(save[m, k].carattere);
                                }
                            }
                            break;
                        case ConsoleKey.Escape:
                            esc= true;
                            break;
                    }
                } while (!esc);
        }
    }
}
