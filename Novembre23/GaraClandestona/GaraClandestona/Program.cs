﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraClandestona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garello mondiale = new Garello();
            mondiale.SetNome("mondiale");
            //valori di default
            mondiale.AggiungiAuto(new BrumBrum("Ferrari", new BroBrum("armandos", "d'asburgo")));
            mondiale.AggiungiAuto(new BrumBrum("Mercedes", new BroBrum("fabio", "piediniAgili")));
            mondiale.AggiungiAuto(new BrumBrum("Alfa Romeo", new BroBrum("David", "Negrello")));
            mondiale.AggiungiAuto(new BrumBrum("Aston Martin", new BroBrum("Super", "Smelon")));
            int scelta;
            string[] opzioni = { "inserimento", "visualizzazione", "Gareggia", "Exit" };
            do
            {
                Console.Clear();
                scelta = Menu(opzioni, "GARA FORMULA 1");
                VerificaScelta(scelta, mondiale);
            } while (scelta != opzioni.Length - 1);
            Console.ReadLine();
        }
        static int Menu(string[] opzioni, string titolo)
        {
            int scelta;
            Console.WriteLine(titolo);
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {opzioni[i]}");
            }
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > opzioni.Length)
            {
                Console.WriteLine("Inserisci qualcosa di corretto");
            }
            scelta--;
            return scelta;
        }
        static void VerificaScelta(int scelta, Garello mondiale)
        {

            switch (scelta)
            {
                case 0:
                    //inserimento
                    try
                    {
                        mondiale.AggiungiAuto(
                            new BrumBrum(InserimentoStringa("scuderia"),
                            new BroBrum(InserimentoStringa("nome"), InserimentoStringa("cognome")))
                            );
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 1:
                    //visualizza macchine gara
                    mondiale.GetLista().ForEach(x => Console.WriteLine(x.GetAuto()));
                    break;
                case 2:
                    //gareggia                    
                    Console.WriteLine($"Ha vinto {mondiale.GetLista()[mondiale.SetRisultato()].GetAuto()}");
                    break;
            }
            Console.WriteLine("Premere invio per continuare");
            Console.ReadLine();
        }
        static string InserimentoStringa(string campo)
        {
            string stringa;
            Console.WriteLine($"Inserire {campo} del pilota");
            stringa = Console.ReadLine();
            while (String.IsNullOrEmpty(stringa.Trim()) || !StringaValida(stringa))
            {
                Console.WriteLine("Reinserire");
                stringa = Console.ReadLine();
            }
            return stringa;
        }
        static bool StringaValida(string stringa)
        {
            for (int i = 0; i < stringa.Length; i++)
            {
                if (char.IsDigit(stringa[i]))
                {
                    return false; 
                }
            }
            return true;
        }
    
    }
}
