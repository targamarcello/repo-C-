using System;
using System.Collections.Generic;
using System.Text;

namespace EsercizioConcessionaria
{
    internal class Moto : Veicolo
    {
        int _nTempi;
        bool _portacasco;
        double _kilometriPercorsi;
        public Moto(int nTempi, double kilometriPercorsi,string marca, string modello) : base(marca, modello)
        {
            _nTempi = nTempi;
            _kilometriPercorsi = kilometriPercorsi;
        }
        public int Tempi
        {
            get { return _nTempi; }
            set { _nTempi = value; }
        }
        public double KMPercorsi
        {
            get { return _kilometriPercorsi; }
            set { _kilometriPercorsi = value; }
        }
        public override string Stampa()
        {
            return String.Format($"Modello: {Modello} - Marca: {Marca} - Numero Tempi: {Tempi} - Kilometri percorsi: {KMPercorsi}");
        }
        public static bool operator ==(Moto a1, Moto b1)
        {
            return a1.Modello== b1.Modello && a1.Marca== b1.Marca;
        }
        public static bool operator !=(Moto a1, Moto b1)
        {
            return !(a1 == b1);
        }
    }
}
