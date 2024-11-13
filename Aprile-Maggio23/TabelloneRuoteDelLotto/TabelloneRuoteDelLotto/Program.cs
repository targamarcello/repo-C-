using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelloneRuoteDelLotto
{
    internal class Program
    {
        enum ruote
        {
            Bari, Cagliari, Firenze, Genova, Milano, Napoli, Palermo, Roma, Torino, Venezia, Nazionale
        }
        static void Main(string[] args)
        {
            int num, cont = 0, opzione;
            const int max = 5, opzioneMax = 10;
            bool presente = false;
            int[] ruota = new int[max];
            Random randomico = new Random();

            do
            {
                Console.WriteLine("Selezionare ruota del lotto:\n" +
                    "[0] Bari;\n" +
                    "[1] Cagliari;\n" +
                    "[2] Firenze;\n" +
                    "[3] Genova;\n" +
                    "[4] Milano;\n" +
                    "[5] Napoli;\n" +
                    "[6] Palermo;\n" +
                    "[7] Roma;\n" +
                    "[8] Torino;\n" +
                    "[9] Venezia;\n" +
                    "[10] Nazionale;");
                opzione = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (opzione > opzioneMax);
            Console.WriteLine($"Ruota {(ruote)opzione}");
            do
            {
                num = randomico.Next(1, 91);
                for (int i = 0; i < cont && !presente; i++)
                {
                    presente = num == ruota[i];

                }
                if (!presente)
                {
                    ruota[cont] = num;
                    cont++;
                }
                presente = false;
            } while (cont < max);
            foreach (int stampa in ruota)
            {
                Console.WriteLine(stampa);
            }
            Console.ReadLine();
        }
    }
}
