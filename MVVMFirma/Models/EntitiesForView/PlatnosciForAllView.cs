using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PlatnosciForAllView
    {
        public int PlatnoscId { get; set; }
        public int? Kwota { get; set; }
        public DateTime? DataPlatnosci { get; set; }

        // Pacjent
        public String PacjentImieNazwisko { get; set; }
        public DateTime? PacjentDataUrodzenia { get; set; }
        public String PacjentMiasto { get; set; }
    }
}
