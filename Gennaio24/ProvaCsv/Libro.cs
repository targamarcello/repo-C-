using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCsv
{
    internal class Libro
    {

        string titolo;
        string autore;
        double prezzo;

        public Libro(string titolo, string autore, double prezzo)
        {
            Titolo = titolo;
            Autore = autore;
            Prezzo = prezzo;
        }

        public string Titolo
        {
            get { return titolo; }
            set { titolo = value; }
        }

        public string Autore
        {
            get { return autore; }
            set { autore = value; }
        }

        public double Prezzo
        {
            get { return prezzo; }
            set { prezzo = value; }
        }

        public override string ToString()
        {
            return string.Format($"Titolo : {Titolo} - Autore: {Autore} - Prezzo: {Prezzo}");
        }
    }
}
