using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimuoviDoppioni
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeriInteri;
            int dimensione = 10;

            CreaVettore(out numeriInteri, dimensione);
            Console.WriteLine(numeriInteri.Length);
            Visualizza(numeriInteri);
            //EstendiVettore(ref numeriInteri, 10);
            Console.ReadLine();
            RimozioneSpazi(ref numeriInteri);
            //Console.WriteLine("************");
            //Console.WriteLine(numeriInteri[0]);
            foreach(int franco in numeriInteri)
            {
                Console.WriteLine(franco);
            }
            Console.ReadLine();
        }
        static void CreaVettore(out int[] numeriInteri, int dimensione)
        {
            numeriInteri = new int[dimensione];
            Random casuale = new Random();
            for (int i = 0; i < dimensione; i++)
            {
                numeriInteri[i] = casuale.Next(1, 31);
            }
        }
        static void Visualizza(int[] numeriInteri)
        {
            //numeriInteri[0] = 99;
            for (int i = 0; i < numeriInteri.Length; i++)
            {
                Console.Write(numeriInteri[i] + " ");
            }
        }
        /*static void EstendiVettore(ref int[] numeriInteri, int estensione)
        {
            int[] numeri = new int[numeriInteri.Length + estensione];
            Random casuale = new Random();
            for (int i = 0; i < numeri.Length; i++)
            {
                if (i < numeri.Length - estensione)
                {
                    numeri[i] = numeriInteri[i];
                }
                else
                {
                    numeri[i] = casuale.Next(1, 101);
                }

            }
            numeriInteri = numeri;
        }*/
        static void RimozioneSpazi(ref int[] numeriInteri)
        {
            for(int i=0; i != numeriInteri.Length; i++)
            {
                for(int k=1; k < numeriInteri.Length; k++)
                {
                    if (numeriInteri[i] == numeriInteri[k])
                    {
                        numeriInteri[k] = 0;
                        do
                        {
                            if (numeriInteri[k]< numeriInteri.Length)
                            {
                                numeriInteri[k] = numeriInteri[k];
                            }else
                            {
                                numeriInteri[k] = numeriInteri[k++];
                            }
                        } while (numeriInteri[9] != 0);
                    }
                }
            }
        }
    }
}