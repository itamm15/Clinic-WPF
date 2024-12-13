using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class PersonelB : DataBaseClass
    {
        public PersonelB(PrzychodniaEntities db) : base(db) { }

        public IQueryable<KeyAndValue> GetPersonelKeyAndValueItems()
        {
            return (
                from personel in db.Personel
                select new KeyAndValue
                {
                    Key = personel.PersonelId,
                    Value = personel.ImieNazwisko,
                }
               ).ToList().AsQueryable();
        }
    }
}
