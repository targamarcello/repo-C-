using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoItinere
{
    internal class Flotta
    {
        string nome, autorizzazione;
        List<Veicolo> parcoVeicoli;
        public Flotta (string nome)
        {
            parcoVeicoli = new List<Veicolo>();
            nome = Nome;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Autorizzazione
        {
            get { return autorizzazione; }
            set { autorizzazione = value; }
        }
        public void Aggiungi(Veicolo v)
        {
            parcoVeicoli.Add(v);
        }
        public void Stampa()
        {
            parcoVeicoli.ForEach(v => Console.WriteLine(v));
        }
        public int RicercaPosti(numeroPosti posti)
        {
            return parcoVeicoli.Count(v => v.Posti == posti);
        }

        public int Disponibili(string marca)
        {
            return parcoVeicoli.Count(v => v.Marca == marca);
        }

        public Veicolo Ricerca(int code, string targa)
        {
            return parcoVeicoli.Find(v => v.Codice == code || v.Targa == targa);
        }
        public int Elimina(int code, string targa)
        {
            //RemoveAll per rimuovere gli elementi che soddisfano la condizione
            return parcoVeicoli.RemoveAll(v => v.Codice == code || v.Targa == targa);
        }
    }
}
