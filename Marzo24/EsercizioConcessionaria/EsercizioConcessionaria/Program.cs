using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EsercizioConcessionaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scelta = 0;
            List<Veicolo> veicoli = new List<Veicolo>();
            string[] scelte = new string[] { "Inserimento", "Visualizza Auto","Visualizza Moto" ,"Elimina", "Esci" };
            do
            {
                Menù(scelte);
                Console.WriteLine("SEGLI LA SCELTA:");
                int.TryParse(Console.ReadLine(), out scelta);
                switch (scelta)
                {
                    case 1:
                        Inserimento(veicoli);
                        break;
                    case 2:
                        Console.Clear();
                        veicoli.ForEach(i => { if (i is Auto) { Auto m = (Auto)i; Console.WriteLine(m.ToString()); } });
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        veicoli.ForEach(i => { if (i is Moto) { Moto m = (Moto)i; Console.WriteLine(m.ToString()); } });
                        Console.ReadLine();
                        break;
                    case 4:
                        Rimuovi(veicoli);
                        break;
                }
            } while (scelta != scelte.Length);
        }
        public static void Menù(string[] s)
        {
            for(int i=0; i<s.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {s[i]}");
            }
        }
        static void Inserimento(List<Veicolo> lista)
        {
            Console.Clear();
            int scelta;
            bool ok;

            Console.WriteLine("------ INSERIMENTO ------");
            Console.WriteLine("1) Auto");
            Console.WriteLine("2) Moto");
            do
            {
                Console.WriteLine("Inserire la scelta: ");
                ok = int.TryParse(Console.ReadLine(), out scelta);
            } while (!ok);

            switch (scelta)
            {
                case 1: lista.Add(InserisciAuto()); break;
                case 2: lista.Add(InserisciMoto()); break;
            }
        }
         static Auto InserisciAuto()
        {
            string marca, modello;
            int kmPercorsi, cilindrata, numeroVolumi;
            Auto brumbrum;
            Console.WriteLine("Inserisci marca brumbrum:");
            marca=Console.ReadLine();
            Console.WriteLine("Inserisci modello brumbrum");
            modello=Console.ReadLine();
            Console.WriteLine("Inserisci km percorsi");
            kmPercorsi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci numero volumi");
            numeroVolumi= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci cilindrata");
            cilindrata=Convert.ToInt32(Console.ReadLine());
            return brumbrum = new Auto(cilindrata, numeroVolumi, kmPercorsi, marca, modello);
        }
        static Moto InserisciMoto()
        {
            string marca, modello;
            int kmPercorsi, numeroTempi;
            Moto brumto;

            Console.WriteLine("Inserire la marca: ");
            marca = Console.ReadLine();

            Console.WriteLine("Inserire il modello: ");
            modello = Console.ReadLine();

            Console.WriteLine("Inserire i km percorsi: ");
            kmPercorsi = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserire il numero tempi: ");
            numeroTempi = int.Parse(Console.ReadLine());

            return brumto = new Moto(numeroTempi,kmPercorsi,marca,modello);
        }
        static void Visualizza(List<Veicolo> veicoli)
        {
            veicoli.ForEach(v => { Console.WriteLine(v.ToString()); });
            Console.ReadLine();
        }
        static void Rimuovi(List<Veicolo>v)
        {
            int selezione;
            Visualizza(v);
            Console.WriteLine("Scegli veicolo da cavare:");
            selezione=int.Parse(Console.ReadLine());
            v.RemoveAt(selezione - 1);
        }
    }
}
