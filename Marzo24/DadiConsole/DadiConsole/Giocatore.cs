using System;
using System.Collections.Generic;
using System.Text;

namespace DadiConsole
{
    internal class Giocatore
    {
        string _nome;
        int _vincite, _faccia;
        public Dado _dado;
        public Giocatore(string nome, int facce)
        {
            _nome = nome;
            _dado = new Dado(facce);
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public int Vincite
        {
            get { return _vincite; }
            set { _vincite = value; }
        }
        static public bool operator >(Giocatore g1, Giocatore g2)
        {
            return (g1.Vincite > g2._vincite);
        }
        static public bool operator <(Giocatore g1, Giocatore g2)
        {
            return !(g1.Vincite > g2._vincite);
        }
        public int Faccia
        {
            get { return _faccia; }
        }
    }
}
