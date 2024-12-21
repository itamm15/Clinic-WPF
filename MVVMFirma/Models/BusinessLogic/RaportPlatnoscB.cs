using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

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

        public List<PlatnosciForAllView> GetPlatnosci(int pacjentId, DateTime dataOd, DateTime dataDo)
        {
            if(pacjentId == -1)
            {
                return (
                    from platnosci in db.Platnosci
                    where platnosci.DataPlatnosci >= dataOd &&
                          platnosci.DataPlatnosci <= dataDo
                    select new PlatnosciForAllView
                    {
                        PlatnoscId = platnosci.PlatnoscId,
                        Kwota = platnosci.Kwota,
                        DataPlatnosci = platnosci.DataPlatnosci,
                        PacjentImieNazwisko = platnosci.Pacjenci.ImieNazwisko,
                        PacjentDataUrodzenia = platnosci.Pacjenci.DataUrodzenia,
                        PacjentMiasto = platnosci.Pacjenci.Miasto
                    }
                 ).ToList();
            } else
            {
                return (
                    from platnosci in db.Platnosci
                    where platnosci.PacjentId == pacjentId && platnosci.DataPlatnosci >= dataOd &&
                          platnosci.DataPlatnosci <= dataDo
                    select new PlatnosciForAllView
                    {
                        PlatnoscId = platnosci.PlatnoscId,
                        Kwota = platnosci.Kwota,
                        DataPlatnosci = platnosci.DataPlatnosci,
                        PacjentImieNazwisko = platnosci.Pacjenci.ImieNazwisko,
                        PacjentDataUrodzenia = platnosci.Pacjenci.DataUrodzenia,
                        PacjentMiasto = platnosci.Pacjenci.Miasto
                    }
                ).ToList();
            }
        }
    }
}
