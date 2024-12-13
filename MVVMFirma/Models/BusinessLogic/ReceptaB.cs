using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ReceptaB : DataBaseClass
    {
        public ReceptaB(PrzychodniaEntities db) : base(db) { }

        public IQueryable<KeyAndValue> GetReceptaKeyAndValueItems()
        {
            return (
                from recepta in db.Recepty
                select new KeyAndValue
                {
                    Key = recepta.ReceptaId,
                    Value = recepta.Pacjenci.ImieNazwisko + ", " + recepta.DataWydania + ", id:" + recepta.ReceptaId
                }
                ).ToList().AsQueryable();
        }
    }
}
