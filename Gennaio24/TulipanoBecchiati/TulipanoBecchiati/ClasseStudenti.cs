using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TulipanoBecchiati
{
    internal class ClasseStudenti
    {
        string NomClasse;
        List<Studente> gangPolesella;
        public ClasseStudenti(string NomClasse)
        {
            gangPolesella= new List<Studente>();
            NomClasse = Nome;
        }
        public string Nome
        {
            get { return NomClasse; }
            set { NomClasse = value; }
        }
        public void NuovoCrudo(Studente s)
        {
            gangPolesella.Add(s);
        }
        public void StampaCrudo()
        {
            gangPolesella.ForEach(s => Console.WriteLine(s));
        }
        public void Elimina(Studente s)
        {
            gangPolesella.Remove(s);
        }
        public Studente TrovaStud(int code)
        {
            if(!gangPolesella.Exists(c=> gan))
        }

    }
}
