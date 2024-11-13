using System;
using System.Collections.Generic;
using System.Text;

namespace DadiConsole
{
    internal class Dado
    {
        static Random rand = new Random();
        int _facce, _facciaUscita;
        public Dado(int facce)
        {
            _facce = facce;
        }
        public void LancioDado()
        {
            _facciaUscita = rand.Next(1, _facce + 1);
        }
        public static bool operator >(Dado d1, Dado d2)
        {
            return (d1._facciaUscita > d2._facciaUscita);
        }
        public static bool operator <(Dado d1, Dado d2)
        {
            return (d1._facciaUscita < d2._facciaUscita);
        }
        public int Faccia
        {
            get { return _facciaUscita; }
        }
    }
}
