using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraClandestona
{
    internal class Garello
    {
        List<BrumBrum> grigliaPartenza;
        int risultato;
        string nome;
        int posti = 5;
        public Garello()
        {
            grigliaPartenza = new List<BrumBrum>();
            this.risultato = 0;
            this.nome = null;
            this.posti = 5;
        }
        public Garello(string nome, List<BrumBrum> grigliaPartenza, int posti)
        {
            this.nome = nome;
            this.grigliaPartenza = grigliaPartenza;
            this.posti = posti;
        }
        public void SetGrigliaPartenza(List<BrumBrum> grigliaPartenza)
        {
            this.grigliaPartenza = grigliaPartenza;
        }
        public void SetNome(string nome)
        {
            this.nome = nome;
        }
        public int SetRisultato()
        {
            if (grigliaPartenza.Count > 1)
            {
                Random random = new Random();
                return this.risultato = random.Next(1, grigliaPartenza.Count + 1);
            }
            throw new Exception("macchine insufficienti per effettuare una corsa");
        }
        public void AggiungiAuto(BrumBrum auto)
        {
            if (grigliaPartenza.Count == posti)
            {
                throw new Exception("Griglia piena");
            }
            grigliaPartenza.Add(auto);
        }
        public List<BrumBrum> GetLista()
        {
            return grigliaPartenza.ToList();
        }
    }
}
