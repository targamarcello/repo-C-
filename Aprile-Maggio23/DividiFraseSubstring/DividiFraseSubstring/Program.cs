using System;

namespace DividiFraseSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string frase;
            do
            {
                Console.WriteLine("inserire frase");
                frase = Console.ReadLine();
            } while (frase == "");
            do
            {
                if (frase.Length >= 34)
                {
                    Console.WriteLine(frase.Substring(0, 34));
                    frase = frase.Remove(0, 34);
                }else
                {
                    Console.WriteLine(frase);
                    frase = frase.Remove(0, frase.Length);
                }

            } while (frase.Length > 34 || frase.Length!=0);
            Console.ReadLine();
        }
    }
}
