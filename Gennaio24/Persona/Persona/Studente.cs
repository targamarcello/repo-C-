using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    internal class Studente : Persona
    {
        static int n = 1;
        int matricola;
        double media;
        public Studente(int matricola, string nome, string cognome, int età) : base( nome, cognome,età)
        {
            matricola = n;
            n++;
        }
        public Studente()
        {
            matricola = n;
            n++;
        }
        new public string Info()
        {
            return string.Format(base.Info()+ " - Matricola: {0} - Media: {1}",Matricola,Media);
        }
        public int Matricola
        {
            get { return matricola; }
        }
        public double Media
        {
            get { return media; }
            set { media = value; }
        }
    }
}
