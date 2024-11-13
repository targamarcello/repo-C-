using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDadiTargaAggio
{
    internal class Giocatore
    {
        string nome;
        int vincite = 0;
        public Giocatore()
        {

        }
        public int Vincite
        {
            get { return vincite; }
            set { vincite = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }



    }
}