using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class BadaniaForAllView
    {
        public int BadanieId {  get; set; } 
        public String TypBadania { get; set; }
        public DateTime? DataBadania { get; set; }

        // Pacjent 
        public String PacjentImieNazwisko { get; set; }
        public DateTime? PacjentDataUrodzenia { get; set; }
        public String PacjentMiasto { get; set; }

        // Lekarz
        public String LekarzImieNazwisko { get; set; }
        public String LekarzSpecjalizacja { get; set; }
        public String LekarzNumerTelefonu { get; set; }
    }
}
