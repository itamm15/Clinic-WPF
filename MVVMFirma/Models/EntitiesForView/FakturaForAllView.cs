using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class FakturaForAllView
    {
        public int FakturaId { get; set; }
        public String Nazwa { get; set; }

        public String Opis { get; set; }

        public DateTime? DataWystawienia { get; set; }

        // Zamiana klucza obcego na referencje
        // TowarId -> Towar(Kod, Nazwa)

        public String TowarKod { get; set; }
        public String TowarNazwa { get; set; }
    }
}
