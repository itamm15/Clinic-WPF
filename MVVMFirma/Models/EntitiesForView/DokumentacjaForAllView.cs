using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class DokumentacjaForAllView
    {
        public int DokumentacjaId { get; set; }
        public String TypDokumentu { get; set; }
        public DateTime? DataDokumentu { get; set; }

        // Pacjent

        public String PacjentImieNazwisko { get; set; }
        public DateTime? PacjentDataUrodzenia { get; set; }
        public String PacjentMiasto { get; set; }
    }
}
