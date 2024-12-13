using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class PacjentB: DataBaseClass
    {
        public PacjentB(PrzychodniaEntities db) : base(db) { }

        public IQueryable<KeyAndValue> GetPacjentKeyAndTowarItems()
        {
            return (
                from pacjent in db.Pacjenci
                select new KeyAndValue
                {
                    Key = pacjent.PacjentId,
                    Value = pacjent.ImieNazwisko + ", " + pacjent.Pesel
                }
                ).ToList().AsQueryable();
        }
    }
}
