using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace EsercizioConcessionaria
{
    internal abstract class Veicolo
    {
        string _marca, _modello;
        protected Veicolo(string marca,string modello)
        {
            _marca = marca;
            _modello = modello;
        }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modello { get => _modello; set=> _modello = value; }
        abstract public string Stampa();
    }
}
