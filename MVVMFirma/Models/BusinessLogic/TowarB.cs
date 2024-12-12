using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class TowarB : DataBaseClass
    {
        public TowarB(PrzychodniaEntities db) : base(db) { }

        // Business functions
        public IQueryable<KeyAndValue> GetTowaryKeyAndValueItems()
        {
            return (
                from towar in db.Towar
                select new KeyAndValue
                {
                    Key = towar.IdTowaru,
                    Value = towar.Nazwa + " " + towar.Kod
                }
                ).ToList().AsQueryable();
        }
    }
}
