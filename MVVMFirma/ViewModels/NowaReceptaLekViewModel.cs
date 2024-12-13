using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class NowaReceptaLekViewModel : JedenViewModel<ReceptaLeki>
    {
        public NowaReceptaLekViewModel() : base("Nowa recepta lek")
        {
            item = new ReceptaLeki();
        }

        // fields
        public String Dawkowanie
        {
            get
            {
                return item.Dawkowanie;
            }
            set
            {
                item.Dawkowanie = value;
                OnPropertyChanged(() => Dawkowanie);
            }
        }

        public int? ReceptaId
        {
            get
            {
                return item.ReceptaId;
            }
            set
            {
                item.ReceptaId = value;
                OnPropertyChanged(() => ReceptaId);
            }
        }

        public int? LekId
        {
            get
            {
                return item.LekId;
            }
            set
            {
                item.LekId = value;
                OnPropertyChanged(() => LekId);
            }
        }

        // combobox
        public IQueryable<KeyAndValue> LekItems
        {
            get
            {
                return new LekiB(przychodniaEntities).GetLekKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> ReceptaItems
        {
            get
            {
                return new ReceptaB(przychodniaEntities).GetReceptaKeyAndValueItems();
            }
        }

        public override void Save()
        {
            przychodniaEntities.ReceptaLeki.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
