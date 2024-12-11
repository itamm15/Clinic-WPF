using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class LekarzOddzialyForAllView
    {
        public int DoktorOddzialId { get; set; }
        public DateTime? DataDolaczenia { get; set; }

        // Lekarz
        public String LekarzImieNazwisko { get; set; }
        public String LekarzSpecjalizacja { get; set; }

        // Oddzial
        public String OddzialNazwa {  get; set; }   
        public String OddzialLokalizacja { get; set; }  
    }
}
