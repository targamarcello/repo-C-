using System;
using System.Collections.Generic;

namespace ZooCasaMia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<AnimaleDomestico> animali = new List<AnimaleDomestico>();
            string titolo = "===============ZOO DI CASA MIA===============";
            string[] opzioni = new string[] { "Inserimento", "Visualizza", "Esci" };
            Menù(titolo, opzioni, animali);
        }
        static void Menù(string titolo, string[] opzioni, List<AnimaleDomestico> animali)
        {
            int prova, scelta;

            do
            {
                Console.WriteLine(titolo);
                for (int i = 0; i < opzioni.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] {opzioni[i]}");
                }
                do
                {
                    prova = Convert.ToInt32(Console.ReadLine());
                } while (prova < 1 || prova > opzioni.Length);
                if (prova != opzioni.Length)
                {
                    scelta = prova;
                    Opzione(scelta, animali);
                }
                Console.Clear();
            } while (prova != opzioni.Length);
        }
        static void Opzione(int scelta, List<AnimaleDomestico> animali)
        {
            switch (scelta)
            {
                case 1:
                    animali.Add(Inserimento());
                    break;
                case 2:
                    if (animali.Count > 0)
                    {
                        //Visualizza(animali);
                        animali.ForEach(x => Console.WriteLine(x.ToString()));
                        Console.WriteLine("------------------------------------------------------------------------");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Fare inserimento");
                        Console.ReadLine();
                    }
                    break;
            }
        }
        static AnimaleDomestico Inserimento()
        {

            int stato;
            bool statoOk=false;
            AnimaleDomestico negrello = new AnimaleDomestico();
            negrello.SetStato(Mangiato.nonHaMangiato);
            Console.WriteLine("Inserire specie dell'animale");
            negrello.SetSpecie(Console.ReadLine());
            Console.WriteLine("Inserire razza");
            negrello.SetRazza(Console.ReadLine());
            Console.WriteLine("Inserire tipologia cibo");
            negrello.SetCibo(Console.ReadLine());
            Console.WriteLine("Inserire quantità");
            negrello.SetQuantità(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Che verso fa l'animale");
            negrello.SetVerso(Console.ReadLine());
            do
            {
                do
                {
                    statoOk = false;
                    Console.WriteLine("Inserire stato della bestia: \n[1]Deve mangiare\n[2]Già mangiato\n[3]Non può mangiare");
                    stato = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        ExceptionStato(stato);
                    }
                    catch (Exception s)
                    {
                        statoOk = true;
                        Console.WriteLine(s.Message);
                    }
                } while (statoOk);
                switch (stato)
                {
                    case 1:
                        negrello.SetStato(Mangiato.deveMangiare);
                        break;
                    case 2:
                        negrello.SetStato(Mangiato.giàMangiato);
                        break;
                    case 3:
                        negrello.SetStato(Mangiato.nonPuòMangiare);
                        break;
                }
            } while (stato != 1 && stato != 2 && stato != 3);
            return negrello;
        }
        static void ExceptionStato(int stato)
        {
            if (stato < 1 || stato > 3)
                throw new Exception("Inserimento stato bestia non valido");
        }
        /*static void Visualizza(List<AnimaleDomestico>animali)
        {
            foreach(AnimaleDomestico x in animali)
            {
                Console.WriteLine(x.GetSpecie());
                Console.WriteLine(x.GetRazza());
                Console.WriteLine(x.GetCibo());
                Console.WriteLine(x.GetQuantit());
                Console.WriteLine(x.GetVerso());
                Console.WriteLine(x.SetStato());
            }
        }*/
    }
}
