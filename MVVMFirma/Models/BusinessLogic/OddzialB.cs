using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class OddzialB : DataBaseClass
    {
        public OddzialB(PrzychodniaEntities db) : base(db) { }

        public IQueryable<KeyAndValue> GetOddzialyKeyAndValueItems()
        {
            return (
                from oddzialy in db.Oddzialy
                select new KeyAndValue
                {
                    Key = oddzialy.OddzialId,
                    Value = oddzialy.NazwaOddzialu + ", " + oddzialy.Lokalizacja
                }
                ).ToList().AsQueryable();
        }
    }
}
