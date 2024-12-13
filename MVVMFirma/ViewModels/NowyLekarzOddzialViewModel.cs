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
    public class NowyLekarzOddzialViewModel : JedenViewModel<LekarzOddzial>
    {
        public NowyLekarzOddzialViewModel() : base("Nowy lekarz oddzial")
        {
            item = new LekarzOddzial();
        }

        // fields 
        public DateTime? DataDolaczenia
        {
            get
            {
                return item.DataDolaczenia;
            }
            set
            {
                item.DataDolaczenia = value;
                OnPropertyChanged(() => DataDolaczenia);
            }
        }

        public int? LekarzId
        {
            get
            {
                return item.LekarzId;
            }
            set
            {
                item.LekarzId = value;
                OnPropertyChanged(() => LekarzId);
            }
        }

        public int? OddzialId
        {
            get
            {
                return item.OddzialId;
            }
            set
            {
                item.OddzialId = value;
                OnPropertyChanged(() => OddzialId);
            }
        }

        // Combobox
        public IQueryable<KeyAndValue> OddzialItems
        {
            get
            {
                return new OddzialB(przychodniaEntities).GetOddzialyKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> LekarzItems
        {
            get
            {
                return new LekarzB(przychodniaEntities).GetLekarzKeyAndValueItems();
            }
        }

        // save
        public override void Save()
        {
            przychodniaEntities.LekarzOddzial.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
