using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TulipanoBecchiati
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClasseStudenti classe = new ClasseStudenti("CLASSE GANG");
            int scelta = 0;
            string[] opzioni = { "Inserimento", "Visualizza", "Elimina","Esci" };
            do
            {
                Console.Clear();
                Menù(opzioni);
                Console.WriteLine("INSERISCI OPZIONE");
                int.TryParse(Console.ReadLine(), out scelta);
                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=======INSERIMENTO======");
                        Inserimento(classe);
                        break;
                   case 2:
                        Console.Clear();
                        Console.WriteLine("=======VISUALIZZA=======");
                        classe.StampaCrudo();
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("=========ELIMINA========");
                        classe.Elimina()
                        break;
                }
            } while (scelta != opzioni.Length);
        }
        static void Menù(string[]opz)
        {
            for(int i=0; i<opz.Length; i++)
            {
                Console.WriteLine($"[{i+1}] {opz[i]}");
            }
        }
        static void Inserimento(ClasseStudenti C)
        {
            Studente crudo= new Studente();
            Console.WriteLine("Inserisci nome del crudo");
            crudo.Nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome del crudo");
            crudo.Cognome= Console.ReadLine();
            Console.WriteLine("Inserisci media del crudo");
            crudo.Media= Convert.ToInt32(Console.ReadLine());
            crudo.Matricola = Studente.Nstud;
            C.NuovoCrudo(crudo);
        }
    }
}
