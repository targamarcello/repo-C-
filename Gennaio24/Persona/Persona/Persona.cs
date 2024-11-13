using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    internal class Persona
    {
        string nome;
        string cognome;
        int età;
        public Persona(string nome, string cognome,int età)
        {
            nome = Nome;
            cognome = Cognome;
            età = Età;
        }
        public Persona()
        {

        }
        public  string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Cognome
        {
            get { return cognome; }
            set { cognome = value;}
        }
        public int Età
        {
            get { return età; }
            set { età = value; }
        }
        public string Info()
        {
            return string.Format($"Nome: {Nome} - Cognome: {Cognome} - Età: {Età}");
        }
        static public bool operator ==(Persona p1, Studente std1)
        {
            return String.Equals(p1.nome, std1.nome);
        }
        static public bool operator !=(Persona p1, Studente std1)
        {
            return !String.Equals(p1.nome, std1.nome);
        }
    }
}
