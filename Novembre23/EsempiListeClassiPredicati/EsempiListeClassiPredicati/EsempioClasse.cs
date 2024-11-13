using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsempiListeClassiPredicati
{
    internal class EsempioClasse
    {
        //Proprietà classe
        string nome;
        string cognome;
        BellezzaClasse fashion;
        //Costruttore 
        public EsempioClasse()
        {

        }

        // Metodi setters
        public void SetNome(string nome)
        {
            this.nome = nome;
        }
        public void SetCognome(string cognome)
        {
            this.cognome = cognome;
        }
        public void DefBellezza(BellezzaClasse bellezzaClasse)
        {
            this.fashion= bellezzaClasse;
        }

        //Metodi getters
        public string GetNome()
        {
            return nome;
        }
        public string GetCognome()
        {
            return cognome;
        }
        public BellezzaClasse GetBellezza()
        {
            return fashion;
        }
    }
}
