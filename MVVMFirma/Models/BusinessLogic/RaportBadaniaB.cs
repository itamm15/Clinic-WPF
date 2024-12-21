using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class RaportBadaniaB : DataBaseClass
    {
        public RaportBadaniaB(PrzychodniaEntities db) : base(db) { }

        public int GetLiczbaBadan(int PacjentId, DateTime DataOd, DateTime DataDo)
        {
            if(PacjentId == -1)
            {
                return (
                    from badania in db.Badania
                    where badania.DataBadania >= DataOd && badania.DataBadania <= DataDo
                    select badania
                    ).Count();
            } else
            {
                return (
                    from badania in db.Badania
                    where badania.PacjentId == PacjentId &&
                        badania.DataBadania >= DataOd && badania.DataBadania <= DataDo
                    select badania
                    ).Count();
            }
        }

        public List<BadaniaForAllView> GetBadania(int PacjentId, DateTime DataOd, DateTime DataDo)
        {
            if(PacjentId == -1)
            {
                return (
                    from badania in db.Badania
                    where badania.DataBadania >= DataOd && badania.DataBadania <= DataDo
                    select new BadaniaForAllView
                    {
                        BadanieId = badania.BadanieId,
                        TypBadania = badania.TypBadania,
                        DataBadania = badania.DataBadania,
                        PacjentImieNazwisko = badania.Pacjenci.ImieNazwisko,
                        PacjentMiasto = badania.Pacjenci.Miasto,
                        PacjentDataUrodzenia = badania.Pacjenci.DataUrodzenia,
                        LekarzImieNazwisko = badania.Lekarze.ImieNazwisko,
                        LekarzSpecjalizacja = badania.Lekarze.Specjalizacja,
                        LekarzNumerTelefonu = badania.Lekarze.NumerTelefonu
                    }
                    ).ToList();
            } else
            {
                return (
                    from badania in db.Badania
                    where badania.PacjentId == PacjentId &&
                        badania.DataBadania >= DataOd && badania.DataBadania <= DataDo
                    select new BadaniaForAllView
                    {
                        BadanieId = badania.BadanieId,
                        TypBadania = badania.TypBadania,
                        DataBadania = badania.DataBadania,
                        PacjentImieNazwisko = badania.Pacjenci.ImieNazwisko,
                        PacjentMiasto = badania.Pacjenci.Miasto,
                        PacjentDataUrodzenia = badania.Pacjenci.DataUrodzenia,
                        LekarzImieNazwisko = badania.Lekarze.ImieNazwisko,
                        LekarzSpecjalizacja = badania.Lekarze.Specjalizacja,
                        LekarzNumerTelefonu = badania.Lekarze.NumerTelefonu
                    }
                 ).ToList();
            }
        } 
    }
}
