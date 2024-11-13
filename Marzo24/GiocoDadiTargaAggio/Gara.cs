using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDadiTargaAggio
{
    internal class Gara
    {
        Dado dado;
        Giocatore g1, g2;
        bool stato;
        string vincitore;
        int nRound = 0;

        public Gara(int nRound, string n1, string n2)
        {
            g1 = new Giocatore();
            g2 = new Giocatore();
            this.nRound = nRound;
            this.g1.Nome= n1;
            this.g2.Nome= n2;
        }
        public bool FineGara //proprietà utilizzata per determinare il fine della gara
        {
            set { stato = value; }
            get { return stato; }
        }
        public string Winner// ritorna il nome del vincitore, lo stato di parità o lo stato               
                            // della partita se in corso
        {
            get { return vincitore; }
        }
        public void Round()//esegue un round della partita
        {
            int v1, v2;
            dado = new Dado();
            v1 = dado.GeneraNumero();
            v2 = dado.GeneraNumero();
            if (v1 > v2)
            {
                vincitore = g1.Nome;
                g1.Vincite++;
            }
            else if (v1 < v2)
            {
                vincitore = g2.Nome;
                g2.Vincite++;
            }
            else
            {
                vincitore = "Pareggio";
            }
        }
        //private void GameWin()// se la partita è finita determina il vincitore o la
        //                      // condizione di parità
        //{
        //}
        public void ResetGame()// resetta la partita
        {
            g1 = null;
            g2 = null;
            nRound = 0;
            vincitore = "";
        }
    }
}
