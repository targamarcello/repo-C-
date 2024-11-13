using System;

namespace RipassoRecupero
{
    internal class Program
    {
        enum Macchina
        {
            toyota,
            panda,
            monopattino
        }
        struct Polesella
        {
            public int peso;
            public string nome;
            public Macchina locomozione;
            public override string ToString()
            {
                return string.Format($"Peso terrone: {peso,-10} Nome terrone: {nome,-15} Locomozione terrone: {locomozione,-10}");
            }
        }
        static void Main(string[] args)
        {
            string[] opz = { "Inserimento", "Visualizza", "Esci" };
            Polesella[] terroni = new Polesella[3];
            int scelta, indice = 0;
            do
            {
                Console.Clear();
                StampaOpzioni(opz);
                Console.Write("Scegli opzione:");
                scelta=Convert.ToInt32(Console.ReadLine());
                switch (scelta)
                {
                    case 0:
                        Inserimento(terroni, indice);
                        break;
                    case 1:
                        Visualizza(terroni, ref indice);
                        Console.ReadLine();
                        break;
                }
                if (indice >= 3)
                {
                    Console.WriteLine("NON PUOI AGGIUNGERE PIù CRUDI");
                }
            } while (scelta != 2);
        }
        static void StampaOpzioni(string[] opzioni)
        {
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine($"[{i}] {opzioni[i]}");
            }
        }
        static void Inserimento(Polesella[] terrone, int indice)
        {
            int sceltaLocomozione;
            Console.WriteLine("Inserisci nome terrone:");
            terrone[indice].nome = Console.ReadLine();
            Console.WriteLine("Fai pesare il terrone:");
            terrone[indice].peso = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dimmi il mezzo di locomozione\n[1]{0}\n[2]{1}\n[3]{2}:", Macchina.toyota, Macchina.panda, Macchina.monopattino);
            switch (sceltaLocomozione = Convert.ToInt16(Console.ReadLine()))
            {
                case 1:
                    terrone[indice].locomozione = Macchina.toyota;
                    break;
                case 2:
                    terrone[indice].locomozione = Macchina.panda;
                    break;
                case 3:
                    terrone[indice].locomozione = Macchina.monopattino;
                    break;
            }
            indice++;
        }
        static void Visualizza(Polesella[] terrons, ref int indice)
        {
            for (int i = 0; i <terrons.Length; i++)
            {
                Console.WriteLine(terrons[i].ToString());
            }
        }
    }
}
