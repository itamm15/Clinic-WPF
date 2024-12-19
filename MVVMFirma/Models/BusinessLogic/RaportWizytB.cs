using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Models.BusinessLogic
{
    public class RaportWizytB : DataBaseClass
    {
        public RaportWizytB(PrzychodniaEntities db) : base(db) { }

        public int WizytyOkresPacjent(int pacjentId, DateTime dataOd, DateTime dataDo)
        {
            if (pacjentId == -1)
            {
                return (
                    from wizyta in db.Wizyty
                    where wizyta.DataWizyty >= dataOd &&
                          wizyta.DataWizyty <= dataDo
                    select wizyta
                    ).Count();
            }
            else
            {
                return (
                    from wizyta in db.Wizyty
                    where wizyta.PacjentId == pacjentId &&
                            wizyta.DataWizyty >= dataOd &&
                            wizyta.DataWizyty <= dataDo
                    select wizyta
                    ).Count();
            }
        }
    }
}
