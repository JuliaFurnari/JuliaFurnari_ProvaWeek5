using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day5
{
    class ImpegniListRepository:IImpegnoRepository
    {
        //Lista statica. 

        public static List<Impegno> agenda = new List<Impegno>
        {
            new Impegno("Impegno1", "Descrizione1", new DateTime(2022, 9, 4 ), Livello.Bassa, false, null),
            new Impegno("Impegno2", "Descrizione2", new DateTime(2021, 9, 4 ), Livello.Media, true, null),
            new Impegno("Impegno3", "Descrizione3", new DateTime(2021, 10, 1 ), Livello.Alta, false, null),
        };

        //Elimina un record dalla lista.
        public void Delete(Impegno impegno)
        {
            agenda.Remove(impegno);
        }

        //Ritorna la lista statica.
        public List<Impegno> Fetch()
        {
            return agenda;
        }

        //Inserisce un record nella lista
        public void Insert(Impegno impegno)
        {
            agenda.Add(impegno);
        }

        //Modifica di un record della lista
        public void Update(Impegno impegno)
        {
            Insert(impegno);
        }

        //Ritorna la lista degli impegni successivi ad una data in ingresso
        public List<Impegno> GetImpegniPerData(DateTime data)
        {
            return agenda.Where(u => u.DataDiScadenza >= data).ToList();
        }

        //Ritorna la lista degli impegni che hanno una data importanza
        public List<Impegno> GetImpegniImportanza(Livello importanza)
        {
            return agenda.Where(u => u.Importanza == importanza).ToList();
        }

        public List<Impegno> GetEseguiti()
        {
            return agenda.Where(u => u.Eseguito == true).ToList();
        }
    }
}
