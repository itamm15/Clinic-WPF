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
    public class NoweSkierowanieViewModel : JedenViewModel<Skierowanie>
    {
        public NoweSkierowanieViewModel() : base("Nowe skierowanie")
        {
            item = new Skierowanie();
        }

        // fields
        public String NumerSkierowania
        {
            get
            {
                return item.NumerSkierowania;
            }
            set 
            {
                item.NumerSkierowania = value;
                OnPropertyChanged(() => NumerSkierowania);
            }
        }

        public DateTime? DataWydania
        {
            get
            {
                return item.DataWydania;
            }
            set
            {
                item.DataWydania = value;
                OnPropertyChanged(() => DataWydania);
            }
        }

        public int? BadanieId
        {
            get
            {
                return item.BadanieId;
            }
            set
            {
                item.BadanieId = value;
                OnPropertyChanged(() => BadanieId);
            }
        }

        // Combobox

        public IQueryable<KeyAndValue> BadanieItems
        {
            get
            {
                return new BadanieB(przychodniaEntities).GetBadanieKeyAndValueItems();
            }
        }

        public override void Save()
        {
            przychodniaEntities.Skierowanie.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
