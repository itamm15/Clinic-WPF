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
    public class NowyPersonelOddzialViewModel : JedenViewModel<PersonelOddzial>
    {
        public NowyPersonelOddzialViewModel() : base("Nowy personel oddzial")
        {
            item = new PersonelOddzial();
        }

        // Fields
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

        public int? PersonelId
        {
            get
            {
                return item.PersonelId;
            }
            set
            {
                item.PersonelId = value;
                OnPropertyChanged(() => PersonelId);
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
        public IQueryable<KeyAndValue> PersonelItems
        {
            get
            {
                return new PersonelB(przychodniaEntities).GetPersonelKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> OddzialItems
        {
            get
            {
                return new OddzialB(przychodniaEntities).GetOddzialyKeyAndValueItems();
            }
        }

        // save
        public override void Save()
        {
            przychodniaEntities.PersonelOddzial.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
