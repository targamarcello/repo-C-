using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TulipanoBecchiati
{
    internal class Studente
    {
        string nome, cognome;
        double media;
        int matricola;
        static int Nstudente;
        public Studente()
        {
            matricola = ++Nstudente;
        }
        static public int Nstud
        {
            get { return Nstudente; }
            set { Nstudente = value; }
        }
        public int Matricola
        {
            get { return matricola; }
            set { matricola = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Cognome
        {
            get { return cognome; }
            set { cognome = value; }
        }
        public double Media
        { 
            get { return media; } 
            set { media = value; } 
        }
        public override string ToString()
        {
            return string.Format($"Nome crudo:{nome, -15} Cognome crudo:{cognome,-15} Media crudo:{media,-10} Crudo Crudo:{matricola, -5}");
        }
    }
}
