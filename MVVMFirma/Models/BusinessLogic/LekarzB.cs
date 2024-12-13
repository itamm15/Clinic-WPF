using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class LekarzB : DataBaseClass
    {
        public LekarzB(PrzychodniaEntities db) : base(db) { }

        public IQueryable<KeyAndValue> GetLekarzKeyAndValueItems()
        {
            return (
                from lekarz in db.Lekarze
                select new KeyAndValue
                {
                    Key = lekarz.LekarzId,
                    Value = lekarz.ImieNazwisko + ", " + lekarz.Specjalizacja
                }
                ).ToList().AsQueryable();
        }
    }
}
