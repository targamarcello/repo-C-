using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacciaAlPolesellano
{
    internal class Immagini
    {
        string path;
        public Immagini(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Ritorna il percorso specificato nell'oggetto
        /// </summary>
        public string Percorso
        {
            get { return path; }
        }

        /// <summary>
        /// Ritorna l'immagine con percorso specificato nell'oggetto
        /// </summary>
        /// <returns></returns>
        public Image RitornoImmagine()
        {
            return Image.FromFile(path);
        }

        /// <summary>
        /// Dato un percorso, ritorna l'immagine
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Image RitornoImmagine(string _path)
        {
            return Image.FromFile(_path);
        }
    }
}
