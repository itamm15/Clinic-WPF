using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class WizytyForAllView
    {
        public int WizytaId { get; set; }
        public DateTime? DataWizyty { get; set; }
        
        // Lekarz
        public String LekarzImieNazwisko { get; set; }

        // Pacjent
        public String PacjentImieNazwisko { get; set; }
        public String PacjentPesel { get; set; }
    }
}
