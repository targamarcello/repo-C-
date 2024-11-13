using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagraficaFIne
{


    internal class Program
    {
        enum Sesso
        {
            Maschio, Femmina,
        }
        enum Elemento
        {
            Libero, Occupato, Cancellato
        }

        enum StatoCivile
        {
            Celibe, Nubile, Coniugato, Divorziato, Separato
        }

        struct Anagrafica
        {
            public string nome;
            public string cognome;
            public DateTime dataNascita;
            public Sesso sesso;
            public StatoCivile statocivile;
            public string cittadinanza;
            public string idFiscale;//QIUXNG05T26Z210S
            public Elemento stato;

        }
        static Anagrafica nomeDaRicercare = new Anagrafica();


        //modificare l'esercizio svolto in precedenza considerando che l'inserimento, la cancellazione e la modifica dovranno
        //avvenire considerando lo stato degli elementi presenti nella collezione (libero, occupato, cancellato)
        static void Main(string[] args)
        {
            string csv = "";
            List<Anagrafica> persone = new List<Anagrafica>();
            string path = Path.Combine(Environment.CurrentDirectory, "log.TXT");
            string titolo = "=====ANAGRAFICA=====";
            string[] opzioni = new string[] { "Inserimento", "Visualizza", "Lettura Log", "Cancella Log", "Scegli log", "Salva CSv", "Importa CSV", "Esci" };
            Menu(csv, opzioni, path, titolo, 10, 0, ConsoleColor.White, ConsoleColor.Green, ConsoleColor.Blue, persone);

        }
        static void Menu(string csv, string[] opzioni, string path, string titolo, int x, int y, ConsoleColor coloreTitolo, ConsoleColor coloreTesto, ConsoleColor coloreSfondo, List<Anagrafica> anagrafe)
        {
            int temp = y;
            int scelta;
            int prova;
            do
            {
                y = temp;
                Console.ForegroundColor = coloreTitolo;
                Console.BackgroundColor = coloreSfondo;
                Console.Clear();
                GiustificaOpzione(opzioni, ref x, ref y, titolo);
                do
                {
                    prova = Convert.ToInt32(Console.ReadLine());
                } while (prova < 1 || prova > opzioni.Length);
                if (prova != opzioni.Length)
                {
                    scelta = prova;
                    Opzione(scelta, anagrafe, path, csv);
                }
            } while (prova != opzioni.Length);
        }
        static void GiustificaOpzione(string[] frase, ref int x, ref int y, string TITOLO)//passo un titolo una frase e la giustifica
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(TITOLO);
            y++;
            for (int i = 0; i < frase.Length; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine($"[{i + 1}] {frase[i]} ");
                y++;
            }
        }

        static void Visualizza(List<Anagrafica> anagrafica)
        {
            foreach (Anagrafica a in anagrafica)
            {
                Console.WriteLine(a.nome);
                Console.WriteLine(a.cognome);
                Console.WriteLine(a.cittadinanza);
                Console.WriteLine(a.dataNascita);
                Console.WriteLine(a.sesso);
                Console.WriteLine(a.statocivile);
            }
            Console.ReadLine();
        }
        static void Opzione(int scelta, List<Anagrafica> anagrafe, string path, string csv)
        {
            int id, pos, i = 0;
            StatoCivile stato = StatoCivile.Coniugato;
            List<Anagrafica> persona = new List<Anagrafica>();
            switch (scelta)
            {
                case 1:

                    if (i == 0)
                    {
                        anagrafe.Add(Inserimento(path));
                        i++;
                    }
                    else
                    {
                        persona.Add(Inserimento(path));
                        anagrafe = persona.FindAll(a => a.nome != nomeDaRicercare.nome);
                    }
                    break;
                case 2:
                    Visualizza(anagrafe);
                    break;
                case 3:
                    if (File.Exists(path))
                    {
                        LeggiLog(path);
                    }
                    else
                    {
                        Console.WriteLine("Il file non esite");
                    }
                    break;
                case 4:
                    File.Delete(path);
                    break;
                case 5:
                    GetFiles();
                    break;
                case 6:
                    StreamWriter setcsv = new StreamWriter(Environment.CurrentDirectory + "\\log.csv");
                    foreach (Anagrafica a in anagrafe)
                    {
                        csv = string.Format($"{a.nome.ToString()},{a.cognome.ToString()},{a.dataNascita.ToString()},{a.cittadinanza.ToString()},{a.sesso.ToString()},{a.statocivile.ToString()},{a.stato.ToString()},{a.idFiscale.ToString()}");
                        setcsv.WriteLine(csv);
                    }
                    setcsv.Close();

                    break;
                case 7:
                    StreamReader srRead = new StreamReader(Environment.CurrentDirectory + "\\log.csv");
                    csv = srRead.ReadLine();
                    string[] supporto = new string[8];
                    do
                    {
                        supporto = csv.Split(',');
                    } while (csv == null);
                    Anagrafica tizio = new Anagrafica();
                    tizio.nome = supporto[0];
                    tizio.cognome = supporto[1];
                    tizio.dataNascita = Convert.ToDateTime(supporto[2]);
                    tizio.cittadinanza = supporto[3];
                    if (supporto[4] == "Maschio")
                    {
                        tizio.sesso = Sesso.Maschio;
                    }
                    else
                    {
                        tizio.sesso = Sesso.Femmina;
                    }
                    switch (supporto[5])
                    {
                        case "Celibe":
                            tizio.statocivile = StatoCivile.Celibe;
                            break;
                        case "Nubile":
                            tizio.statocivile = StatoCivile.Nubile;
                            break;
                        case "Divorziato":
                            tizio.statocivile = StatoCivile.Divorziato;
                            break;
                        case "Coniugato":
                            tizio.statocivile = StatoCivile.Coniugato;
                            break;
                        case "Separato":
                            tizio.statocivile = StatoCivile.Separato;
                            break;
                    }
                    switch (supporto[6])
                    {
                        case "Libero":
                            tizio.stato = Elemento.Libero;
                            break;
                        case "Occupato":
                            tizio.stato = Elemento.Occupato;
                            break;
                        case "Cancellato":
                            tizio.stato = Elemento.Cancellato;
                            break;
                    }
                    tizio.idFiscale = supporto[7];
                    Console.WriteLine("operazione a buon fine");
                    Console.ReadLine();
                    anagrafe.Add(tizio);
                    break;
            }
        }
        static string CostruisciLog(DateTime dataAttuale)
        {
            string data = dataAttuale.ToShortDateString();
            data = data.Replace("/", ".");
            return data;
        }
        static Anagrafica Inserimento(string path)
        {
            bool ok = true;
            string data;
            int anno, mese, giorno, id, pos;
            Sesso tipo;
            StatoCivile stato = StatoCivile.Separato;
            Anagrafica cittadino = new Anagrafica();
            Console.WriteLine("Inserisci il tuo nome");
            cittadino.nome = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo cognome");
            cittadino.cognome = Console.ReadLine();
            do
            {
                Console.WriteLine("Inserisci la tua data di nascità");
                data = Console.ReadLine();
                EstraiData2(data, out anno, out mese, out giorno);
                ok = VerfificaData(anno, mese, giorno);
            } while (ok);
            cittadino.dataNascita = Convert.ToDateTime(data);
            Console.WriteLine(cittadino.dataNascita);
            Console.WriteLine("Inserisci la tua cittadinanza");
            cittadino.cittadinanza = Console.ReadLine();
            cittadino.stato = Elemento.Occupato;
            Console.WriteLine("che sesso sei? Maschio [1] o femmina [2]");
            int scelta = Convert.ToInt32(Console.ReadLine());
            cittadino.sesso = gender(scelta, out tipo);
            do
            {
                Console.WriteLine("inserisci il tuo Id fiscale");
                id = Convert.ToInt32(Console.ReadLine());
            } while (id <= 0);
            cittadino.idFiscale = Convert.ToString(id);
            cittadino.statocivile = Stato();
            ScriviLog(path, cittadino.ToString());
            nomeDaRicercare.nome = cittadino.nome;
            return cittadino;
        }
        static void GetFiles()
        {
            string[] files;
            files = Directory.GetFiles(Environment.CurrentDirectory + "\\" + "\\logDir");
            foreach (string a in files)
            {
                Console.WriteLine(a);
            }
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"[{i + 1}]log:{files[i]}");
            }
            int scelta = Convert.ToInt32(Console.ReadLine()) - 1;
            LeggiLog(files[scelta]);
            Console.ReadLine();
        }
        static StatoCivile Stato()
        {
            int opzione = 0;
            StatoCivile stato = new StatoCivile();
            Console.WriteLine("Sei Nubile(1) Coniugato/a(2) Divorziata/o(3) Separato/a(4) Celibe(5) ");
            opzione = Convert.ToInt32(Console.ReadLine());
            switch (opzione)
            {
                case 1:
                    stato = StatoCivile.Nubile;
                    break;
                case 2:
                    stato = StatoCivile.Coniugato;
                    break;
                case 3:
                    stato = StatoCivile.Divorziato;
                    break;
                case 4:
                    stato = StatoCivile.Separato;
                    break;
                case 5:
                    stato = StatoCivile.Celibe;
                    break;
            }
            return stato;
        }
        static void EstraiData2(string data2, out int anno2, out int mese2, out int giorno2)
        {
            string[] array = data2.Split('/');
            giorno2 = Convert.ToInt32(array[0]);
            mese2 = Convert.ToInt32(array[1]);
            anno2 = Convert.ToInt32(array[2]);
        }
        static Sesso gender(int scelta, out Sesso tipo)
        {
            tipo = Sesso.Maschio;
            switch (scelta)
            {
                case 2:
                    tipo = Sesso.Femmina;
                    break;
            }
            return tipo;
        }
        static bool VerfificaData(int anno, int mese, int giorno)
        {
            bool dataInvalida = false;
            if (anno < 0)
            {
                dataInvalida = true;
            }
            else if (mese < 0 || mese > 12)
            {
                dataInvalida = true;
            }
            if ((mese == 1 || mese == 3 || mese == 5 || mese == 7 || mese == 8 || mese == 10 || mese == 12) && giorno > 31)
            {
                dataInvalida = true;
            }
            else if ((mese == 4 || mese == 6 || mese == 9 || mese == 11) && giorno > 30)
            {
                dataInvalida = true;
            }
            else if ((mese == 2) && giorno > 29)
            {
                dataInvalida = true;
            }
            return dataInvalida;
        }
        static void ScriviLog(string path, string log)
        {
            StreamWriter sw;
            if (File.Exists(path))
            {
                sw = new StreamWriter(path, true);
            }
            else
            {
                sw = new StreamWriter(path);
            }
            sw.WriteLine(DateTime.Now + " " + log);
            sw.Close();
        }
        static void LeggiLog(string path)
        {
            StreamReader sr = File.OpenText(path);
            string lineaTesto;
            lineaTesto = sr.ReadLine();
            while (lineaTesto != null)
            {
                Console.WriteLine(lineaTesto);
                lineaTesto = sr.ReadLine();
            }
            Console.ReadLine();
            sr.Close();
            sr.Close();
        }
    }
}