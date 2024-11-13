using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsempiListeClassiPredicati
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Uso costruttore
            EsempioClasse esempio = new EsempioClasse();
            Console.WriteLine("Inserire nome classe");
            esempio.SetNome(Console.ReadLine());
            Console.WriteLine("Inserire cognome classe");
            esempio.SetCognome(Console.ReadLine());
            Console.WriteLine("Selezione bellezza classe:\n[1]Bellissima\n[2]Terrificante\n[3]Drip");
            switch(Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    esempio.DefBellezza( BellezzaClasse.Bellissima);
                    break;
                case 2:
                    esempio.DefBellezza(BellezzaClasse.Terrificante);
                    break;
                case 3:
                    esempio.DefBellezza(BellezzaClasse.Drip);
                    break;
            }
            Console.WriteLine(esempio.GetNome());
            Console.WriteLine(esempio.GetCognome());
            Console.WriteLine(esempio.GetBellezza());
            Console.ReadLine();
        }
    }
}
