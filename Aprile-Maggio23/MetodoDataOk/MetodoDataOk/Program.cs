using System;

namespace MetodoDataOk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int  GG = 0, MM = 0, AAAA = 0;
            long data;
            char risp;
            do
            {
                Console.Clear();
                Console.WriteLine("inserire data del giorno, mese e anno");
                data = Convert.ToInt32(Console.ReadLine());
                if (ScomponiLong(data, ref GG, ref MM, ref AAAA))
                {
                    Console.WriteLine("===========Stampa Data============");
                    Console.WriteLine($"il giorno è :{GG}\nil mese è: {MM}\nl'anno è:{AAAA}");
                }
                Console.WriteLine("==================================");
                Console.WriteLine("Vuoi inserire un'altra data?");
                risp = Convert.ToChar(Console.ReadLine().ToLower());
            } while (risp == 's');
        }
        static bool ScomponiLong(long data, ref int giorno, ref int mese, ref int anno)
        {
            anno = (int)data % 10000;
            data = data / 10000;
            mese = (int)data % 100;
            if(mese<0 || mese >12)
            {
                Console.WriteLine("Data Non Valida!!");
                return false;
            }
            data = data / 100;
            giorno = (int)data;
            if(mese== 02)
            {
                if(giorno >29)
                {
                    Console.WriteLine("Data Non Valida!!");
                    return false;
                }
            }
            if(giorno<0 || giorno >31)
            {
                Console.WriteLine("Data Non Valida!!");
                return false;
            }
            return true;
        }
    }
}
