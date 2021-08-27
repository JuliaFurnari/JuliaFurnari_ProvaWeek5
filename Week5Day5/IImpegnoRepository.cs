using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day5
{
    interface IImpegnoRepository:IDbRepository
    {
        public List<Impegno> GetImpegniPerData(DateTime data);
        public List<Impegno> GetImpegniImportanza(Livello imp);
        public List<Impegno> GetEseguiti();

    }
}
