using System;
using System.Collections.Generic;
using System.Text;

namespace EsercizioConcessionaria
{
    internal class Auto : Veicolo
    {
        int _cilindrata;
        int _numeroVolumi;
        double _kilometriPercorsi;
        public Auto(int cilindrata, int numeroVolumi, double kilometriPercorsi, string marca, string modello): base(marca, modello)
        {
            _cilindrata = cilindrata;
            _numeroVolumi = numeroVolumi;
            _kilometriPercorsi = kilometriPercorsi;
        }
        public int Cilindrata
        {
            get { return _cilindrata; }
            set{_cilindrata = value;}
        }
        public int NumeroVolumi
        {
            get { return _numeroVolumi; }
            set { _numeroVolumi = value; }
        }
        public double KilometriPercorsi
        {
            get { return _kilometriPercorsi; }
            set { _kilometriPercorsi = value; }
        }
        public override string Stampa()
        {
            return String.Format($"Modello: {Modello} - Marca: {Marca} - Cilindrata: {Cilindrata} - Numero Volumi: {NumeroVolumi} - Kilometri percorsi: {KilometriPercorsi}");
        }
        public static bool operator == (Auto a1, Auto b1)
        {
            return a1.Modello== b1.Modello&& a1.Marca== b1.Marca;
        }
        public static bool operator !=(Auto a1, Auto b1)
        {
            return !(a1 == b1);
        }


    }
}
