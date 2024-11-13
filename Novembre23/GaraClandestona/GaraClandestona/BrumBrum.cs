using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraClandestona
{
    internal class BrumBrum
    {
        string scuderia;
        BrumBrum pilota;
        public BrumBrum() 
        {

        }
        public BrumBrum(string scuderia, BrumBrum pilota)
        {
            this.scuderia = scuderia;
            this.pilota = pilota;
        }
        public void SetScuderia(string scuderia)
        {
            this.scuderia = scuderia;
        }
        public string GetScuderia()
        {
            return this.scuderia;
        }
        public string GetAuto()
        {
            return string.Format($"scuderia: {this.scuderia} pilota: {this.pilota.StampaPilota()}");
        }
    }
}
