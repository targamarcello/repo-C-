using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooCasaMia
{
    internal class AnimaleDomestico
    {
        string specie;
        string razza;
        string cibo;
        int quantità;
        string verso;
        Mangiato mangiat;
        public override string ToString()
        {
            return String.Format($"Specie:{specie} Razza:{razza} Cibo:{cibo} Quantità:{quantità} Verso:{verso} Stato:{mangiat}");
        }
        public AnimaleDomestico()
        {

        }
        public void SetSpecie(string specie)
        {
            this.specie = specie;
        }
        public void SetRazza(string razza)
        {
            this.razza = razza;
        }
        public void SetCibo(string cibo)
        {
            this.cibo = cibo;
        }
        public void SetQuantità(int quantit)
        {
            this.quantità= quantit;
        }
        public void SetVerso(string verso)
        {
            this.verso = verso;
        }
        public Mangiato SetStato(Mangiato mangiato)
        {
            return this.mangiat = mangiato;
        }
        public string GetSpecie()
        {
            return this.specie;
        }
        public string GetRazza()
        {
            return this.razza;
        }
        public string GetCibo()
        {
            return this.cibo;
        }
        public int GetQuantit()
        {
            return this.quantità;
        }
        public string GetVerso()
        {
            return this.verso;
        }
    }
}
