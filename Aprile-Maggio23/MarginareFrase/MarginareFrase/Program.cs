using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarginareFrase
{
    internal class Program
    {
        const int lunghFrase = 80;
        const int divisioniFrase = 20;
        static void Main(string[] args)
        {
            string parola;
            do
            {
                Console.Write("Scrivi frase:");
                parola = Console.ReadLine();
            } while (parola == "" || parola.Length > 80);
            parola = parola + " ";
            MarginaFrase(parola);
            Console.ReadLine();
        }
        static string MarginaFrase(string frase)
        {
            int i = lunghFrase;
            bool uscita = true;
            Console.WriteLine("La frase è");
            do
            {
                if (frase.Length > lunghFrase)
                {
                    do
                    {

                        if (frase[i] != ' ')
                        {
                            if (uscita)
                            {
                                i--;
                                if (i == -1)
                                {
                                    uscita = false;
                                    i = lunghFrase;
                                }
                            }
                            else
                            {
                                i++;
                            }
                        }
                    } while (frase[i] != ' ');
                    Console.WriteLine(frase.Substring(0, i));
                    frase = frase.Remove(0, i + 1);
                    i = lunghFrase;
                }
            } while (frase.Length > 34);
            Console.WriteLine(frase);
            return frase;
        }
    }
}
