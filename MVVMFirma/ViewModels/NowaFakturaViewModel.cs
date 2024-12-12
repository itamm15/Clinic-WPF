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
    public class NowaFakturaViewModel:JedenViewModel<Faktury>
    {
        public NowaFakturaViewModel() : base("Faktura") {
            item = new Faktury();
        }

        // Fields
        public String Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(()  => Nazwa);
            }
        }

        public String Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                item.Opis = value;
                OnPropertyChanged(() => Opis);
            }
        }

        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                item.DataWystawienia = value;
                OnPropertyChanged(() => DataWystawienia);
            }
        }

        public int TowarId
        {
            get
            {
                return item.TowarId;
            }
            set
            {
                item.TowarId = value;
                OnPropertyChanged(() => TowarId);
            }
        }

        // Combobox

        public IQueryable<KeyAndValue> TowaryItems
        {
            get
            {
                return new TowarB(przychodniaEntities).GetTowaryKeyAndValueItems();
            }
        }

        public override void Save()
        {
            przychodniaEntities.Faktury.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
