using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PersonelOddzialForAllView
    {
        public int PersonelOddzialId { get; set; }
        public DateTime? DataDolaczenia { get; set; }   

        // Oddzial
        public String OddzialNazwaOddzialu { get; set; }
        public String OddzialLokalizacja { get; set; }
        public DateTime? OddzialDataOtwarcia { get; set; }

        // Personel
        public String PersonelImieNazwisko { get; set; }
        public String PersonelStanowisko { get; set; }
    }
}
