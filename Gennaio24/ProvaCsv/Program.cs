using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCsv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libreria libreria = new Libreria("Feltrinelli");
            Libro l1 = new Libro("libro1", "autore1", 5);
            Libro l2 = new Libro("libro2", "autore2", 10);
            Libro l3 = new Libro("libro3", "autore3", 15);
            Libro l4 = new Libro("libro4", "autore4", 20);
            libreria.AddLibro(l1);
            libreria.AddLibro(l2);
            libreria.AddLibro(l3);
            libreria.AddLibro(l4);


            List<Libro> libroTemp = new List<Libro>();
            libroTemp = libreria.ListaMieiLibri();//porto la copia
            libroTemp = libreria.ImportaCsv();
            libroTemp.ForEach(x => Console.WriteLine(x.ToString()));

            libreria.EsportaCsv();

            Console.ReadLine();
        }
    }
}
