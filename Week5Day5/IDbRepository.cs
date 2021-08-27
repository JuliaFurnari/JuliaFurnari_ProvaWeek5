using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day5
{
    interface IDbRepository
    {
        public List<Impegno> Fetch();
        public void Insert(Impegno impegno);
        public void Delete(Impegno impegno);
        public void Update(Impegno impegno);
    }
}
