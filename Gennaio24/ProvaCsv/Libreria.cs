using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCsv
{
    internal class Libreria
    {
        string nome;
        List<Libro> listaLibri;

        public Libreria(string nome)
        {
            Nome = nome;
            listaLibri = new List<Libro>();
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public void AddLibro(Libro libro)
        {
            listaLibri.Add(libro);
        }
        public List<Libro> ListaMieiLibri()
        {
            return listaLibri.ToList();
        }

        public void EsportaCsv()
        {
            StreamWriter sw = new StreamWriter("dati.csv");
            sw.WriteLine("Titolo,Autore,Prezzo");
            foreach(Libro l in listaLibri)
            {
                sw.WriteLine($"{l.Titolo},{l.Autore},{l.Prezzo}");
            }
            sw.Close();
        }

        public List<Libro> ImportaCsv()
        {
            StreamReader sr = new StreamReader("dati.csv");
            List<Libro> listaTemp = new List<Libro>();
            string linea;
            string[] campi;
            linea = sr.ReadLine();
            linea = sr.ReadLine();
            while (linea != null)
            {
                campi = linea.Split(',');
                listaTemp.Add(new Libro(campi[0], campi[1], Convert.ToDouble(campi[2])));
                linea = sr.ReadLine();
            }
            sr.Close();           
            return listaTemp;
        }
    }
}
