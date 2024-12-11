using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class SkierowaniaForAllView
    {
        public int SkierowanieId { get; set; }
        public String NumerSkierowania { get; set; }
        public DateTime? DataWydania { get; set; }

        // Badanie
        public int? BadanieId { get; set; }
        public String TypBadania { get; set; }
        public DateTime? DataBadania { get; set; }

        // Lekarz
        public String LekarzImieNazwisko { get; set; }

        // Pacjent 
        public String PacjentImieNazwisko { get; set; }
        public String PacjentPesel { get; set; }
    }
}
