using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMetodi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MaxOpzione = 4, MaxNumeri = 3;
            int opzione, cont = 0;
            string[] nomi = new string[MaxNumeri];
            string nuovoNumero;
            string[] numeriTelefonici = new string[MaxNumeri];
            long[] modifica = new long[MaxNumeri];
            bool numPresente = false;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("====Registro Telefonico====");
                    Console.WriteLine("[1] Inserimento: nome, cognome, numero telefonico");
                    Console.WriteLine("[2] Visualizza contatti telefonici");
                    Console.WriteLine("[3] Modifica numero di telefono");
                    Console.WriteLine("[4] Esci");
                    opzione = Convert.ToInt32(Console.ReadLine());
                } while (opzione < 1 || opzione > MaxOpzione);
                switch (opzione)
                {
                    case 1:
                        Inserimento_Informazioni(cont, nomi, numeriTelefonici,  numPresente);
                        break;
                    case 2:
                        for (int i = 0; i < MaxNumeri; i++)
                        {
                            Console.WriteLine($"il {i + 1}° contatto è: {nomi[i]} con numero {numeriTelefonici[i]}");

                        }
                        Console.WriteLine("premi tasto");
                        Console.ReadLine();
                        break;
                    case 3:
                        if (numPresente == true)
                        {
                            Console.WriteLine("inserire contatto da modificare");
                            nuovoNumero = Console.ReadLine();
                            for (int i = 0; i < MaxNumeri; i++)
                            {
                                if (nuovoNumero == nomi[i])
                                {
                                    Console.WriteLine("inserisci nuovo nome per il contatto");
                                    nomi[i] = Console.ReadLine();
                                    Console.WriteLine("inserire nuovo numero per il contatto");
                                    numeriTelefonici[i] = Console.ReadLine();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("nessuna modifica da eseguire");
                        }
                        Console.WriteLine("premi tasto");
                        Console.ReadLine();
                        break;
                }
            } while (opzione != MaxOpzione);
        }
        static void Inserimento_Informazioni(int cont, string [] nomi, string [] numeriTelefonici, bool numPresente)
        {
            string[] rubrica = new string[50];
            if (cont != 3)
            {
                Console.WriteLine("Inserire nome e cognome");
                nomi[cont] = Console.ReadLine();
                Console.WriteLine("Inserisci numero del contatto {0}", nomi[cont]);
                numeriTelefonici[cont] = Console.ReadLine();
                while (numeriTelefonici[cont].Length != 10)
                {
                    Console.WriteLine("Il numero deve essere lungo 10 cifre");
                    numeriTelefonici[cont] = Console.ReadLine();
                }
                cont++;
            }
            if (cont == 3)
            {
                Console.WriteLine("Rubrica piena");
                Console.ReadLine();
            }
            for (int i = 0; i < cont; i++)
            {
                rubrica[i] = nomi[cont] + " " + numeriTelefonici[i];
            }
        }
    }
}
