using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class LekiB : DataBaseClass
    {
        public LekiB(PrzychodniaEntities db) : base(db) { }

        public IQueryable<KeyAndValue> GetLekKeyAndValueItems()
        {
            return (
                from lek in db.Leki
                select new KeyAndValue
                {
                    Key = lek.LekId,
                    Value = lek.NazwaLeku + ", " + lek.TypLeku
                }
                ).ToList().AsQueryable();
        }
    }
}
