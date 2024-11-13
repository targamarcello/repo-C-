using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    internal class Program
    {
        struct Macchina
        {
            public string targa;
            public string marca;
            public string modello;
            public float prezzo;
        }
        static void Main(string[] args)
        {
            string risposta;
            int macchineIns = 0;
            const int maxMacchina = 3;
            bool ricerca = false, trovato = false;
            Macchina[] auto = new Macchina[maxMacchina];
            Macchina auto1 = new Macchina();
            do
            {
                Console.WriteLine("Vuoi inserire un'auto?");
                risposta = Console.ReadLine().ToUpper();
                if (risposta == "SI" && macchineIns < maxMacchina)
                {
                    InsAuto(ricerca, ref auto[macchineIns]);
                    macchineIns++;
                }
                if (macchineIns == 0)
                {
                    Console.WriteLine("Devi inserire almeno una auto");
                    Console.ReadLine();
                }
                Console.Clear();
            } while (risposta == "SI" || macchineIns == 0);
            do
            {
                Console.WriteLine("Vuoi cercare un'auto?");
                risposta = Console.ReadLine().ToUpper();
                if (risposta == "SI" && macchineIns < maxMacchina)
                {
                    Console.Clear();
                    ricerca = true;
                    InsAuto(ricerca, ref auto1);
                    for (int i = 0; i < auto.Length; i++)
                    {
                        if (auto[i].marca == auto1.marca)
                        {
                            if (auto[i].modello == auto1.modello)
                            {
                                Console.WriteLine($"La macchina è stata trovata in posizione: {i + 1}");
                                trovato = true;
                            }
                        }
                    }
                    if (!trovato)
                    {
                        Console.WriteLine("La macchina non è stata trovata");
                    }
                }
            } while (risposta == "SI");
        }
        static void InsAuto(bool ricerca, ref Macchina auto1)
        {
            bool accettaTarga = false;

            Console.WriteLine("Inserisci la marca dell'auto");
            auto1.marca = Console.ReadLine().ToUpper();
            Console.WriteLine("Inserisci il modello dell'auto");
            auto1.modello = Console.ReadLine().ToUpper();
            if (!ricerca)
            {
                Console.WriteLine("Vuoi inserire una targa random?");
                if (Console.ReadLine().ToUpper() == "SI" || ricerca == true)
                {
                    accettaTarga = true;
                }
                else
                {
                    Console.WriteLine("Inserisci la targa dell'auto");
                    auto1.targa = Console.ReadLine();
                }
                if (accettaTarga)
                {
                    GeneraTarga();
                }
                Console.WriteLine("Inserisci il prezzo dell'auto");
                auto1.prezzo = Convert.ToInt32(Console.ReadLine());
            }
        }
        static void GeneraTarga()
        {
            const int lunghezza = 7;
            int numero, cont = 0;
            string targaFinale = "";
            char lettera;
            Random targa = new Random();
            for (int i = 0; i <= lunghezza; i++)
            {
                if (i > 1 && i < 6)
                {
                    cont++;
                    numero = targa.Next(1, 10);
                    if (cont == 3)
                    {
                        targaFinale = targaFinale + " ";
                    }
                    else
                    {
                        targaFinale = targaFinale + numero;
                    }
                }
                else
                {
                    cont++;
                    numero = targa.Next(65, 91);
                    lettera = Convert.ToChar(numero);
                    targaFinale = targaFinale + lettera;

                }
            }
            Console.WriteLine($"La targa generata è: {targaFinale}");
        }
    }
}
