using System;
using System.Collections.Generic;
using System.Text;

namespace DadiConsole
{
    internal class Partita
    {
        int _nRound, _reset;
        Giocatore g1;
        Giocatore g2;
        public Partita(int n, string nome1, string nome2, int facce)
        {
            g1 = new Giocatore(nome1, facce);
            g2 = new Giocatore(nome2, facce);
            _nRound = n;
            _reset = _nRound;
        }
        public bool FinePartita
        {
            get
            {
                if (_nRound == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public string Winner()
        {
            g1._dado.LancioDado();
            g2._dado.LancioDado();
            if (g1._dado > g2._dado)
            {
                g1.Vincite++;
                _nRound--;
                return "Il vincitore di questo round è:" + g1.Nome;
            }
            else if (g1._dado < g2._dado)
            {
                g2.Vincite++;
                _nRound--;
                return "Il vincitore di questo round è:" + g2.Nome;
            }
            else
            {
                g1.Vincite++;
                g2.Vincite++;
                _nRound--;
                return "Pareggio";
            }
        }
        public string GameWin() //Determina il vincitore quando la partita finisce
        {
            if (g1 > g2)
            {
                return "Il vincitore è " + g1.Nome;
            }
            else if (g1 < g2)
            {
                return "Il vincitore è " + g2.Nome;
            }
            else
            {
                return "La partita è risultata in parità";
            }
        }
        public void ResetGame()
        {
            _nRound = _reset;
            g1.Vincite = 0;
            g2.Vincite = 0;
        }
    }
}
