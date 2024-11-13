using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDadiTargaAggio
{
    internal class Dado
    {
        int numero;
        public Dado()
        {
        }
        public int GeneraNumero()
        {
            Random rand = new Random();
            numero = rand.Next(0, 7);
            return numero;
        }
        public int Numero
        {
            get { return GeneraNumero(); }
        }
    }
}