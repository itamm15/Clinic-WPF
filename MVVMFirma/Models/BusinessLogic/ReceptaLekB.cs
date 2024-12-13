using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ReceptaLekB : DataBaseClass
    {
        public ReceptaLekB(PrzychodniaEntities db) : base(db) { }

        public IQueryable<KeyAndValue> GetReceptaLekKeyAndValueItems ()
        {
            return (
                from receptaLek in db.ReceptaLeki
                select new KeyAndValue
                {
                    Key = receptaLek.ReceptaLekiId,
                    Value = receptaLek.Leki.NazwaLeku + ", " + receptaLek.Leki.TypLeku + ", " + receptaLek.Dawkowanie
                }
                ).ToList().AsQueryable();
        }
    }
}
