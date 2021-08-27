using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day5
{
    class Impegno
    {
        //Dati della classe

        public string Titolo;
        public string Descrizione;
        public DateTime DataDiScadenza;
        public Livello Importanza;
        public bool Eseguito;
        public int? Id;

        //Costruttori della classe
        public Impegno() { }
        public Impegno(string titolo, string descrizione, DateTime dataScadenza, Livello importanza, bool eseguito, int? id)
        {
            Titolo = titolo;
            Descrizione = descrizione;
            DataDiScadenza = dataScadenza;
            Importanza = importanza;
            Eseguito = eseguito;
            Id = id;
        }

        //Metodo della classe

        public void PrintInfo()
        {
            Console.WriteLine($"Titolo: {Titolo} \t Descrizione: {Descrizione} \t Data di scadenza: {DataDiScadenza} \t Importanza: {Importanza} \t Portato a termine: {Eseguito}");
        }

       
    }
    enum Livello
    {
        Alta,
        Media,
        Bassa
    }
}
