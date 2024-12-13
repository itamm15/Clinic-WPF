using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class BadanieB : DataBaseClass
    {
        public BadanieB(PrzychodniaEntities db) : base(db) { }

        public IQueryable<KeyAndValue> GetBadanieKeyAndValueItems()
        {
            return (
                from badanie in db.Badania
                select new KeyAndValue
                {
                    Key = badanie.BadanieId,
                    Value = badanie.TypBadania + ", " + badanie.Pacjenci.ImieNazwisko + ", " + badanie.DataBadania
                }
                ).ToList().AsQueryable();
        }
    }
}
