using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ReceptaLekiForAllView
    {
        public int ReceptaLekiId { get; set; }
        public String Dawkowanie {  get; set; }

        // Lek

        public String LekNazwa { get; set; }
        public String LekTyp { get; set; }  

        // Recepta
        public int? ReceptaId { get; set; }

        // Pacjent
        public String PacjentImieNazwisko { get; set; }
    }
}
