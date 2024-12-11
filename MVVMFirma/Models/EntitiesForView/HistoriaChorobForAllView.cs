using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class HistoriaChorobForAllView
    {
        public int HistoriaChorobyId { get; set; }
        public String OpisChoroby { get; set; }
        public DateTime? DataRopoznania { get; set; }

        // Pacjent

        public String PacjentImieNazwisko { get; set; }
        public DateTime? PacjentDataUrodzenia { get; set; }
        public String PacjentMiasto { get; set; }
    }
}
