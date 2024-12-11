using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ReceptyForAllView
    {
        public int ReceptaId { get; set; }
        public DateTime? DataWydania { get; set; }

        // Lekarz
        public String LekarzImieNazwisko { get; set; }  

        // Pacjent
        public String PacjentImieNazwisko { get; set; }
        public String PacjentPesel { get; set; }
    }
}
