using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Models.BusinessLogic
{
    public class RaportPlatnoscB : DataBaseClass
    {
        public RaportPlatnoscB(PrzychodniaEntities db) : base(db) {}

        public decimal? PlatnoscOkresPacjent(int pacjentId, DateTime dataOd, DateTime dataDo)
        {
            if(pacjentId == -1)
            {
            return (
                from platnosc in db.Platnosci
                where platnosc.DataPlatnosci >= dataOd &&
                      platnosc.DataPlatnosci <= dataDo
                select platnosc.Kwota
                ).Sum();
            } else
            {
            return (
                from platnosc in db.Platnosci
                where platnosc.PacjentId == pacjentId &&
                        platnosc.DataPlatnosci >= dataOd &&
                        platnosc.DataPlatnosci <= dataDo
                select platnosc.Kwota
                ).Sum();
            }
        }
    }
}
