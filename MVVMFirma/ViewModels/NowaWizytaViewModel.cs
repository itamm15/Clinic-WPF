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
    public class NowaWizytaViewModel : JedenViewModel<Wizyty>
    {
        public NowaWizytaViewModel() : base("Nowa wizyta")
        {
            item = new Wizyty();
        }

        // fields 
        public DateTime? DataWizyty
        {
            get
            {
                return item.DataWizyty;
            }
            set
            {
                item.DataWizyty = value;
                OnPropertyChanged(() => DataWizyty);
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

        public int? PacjentId
        {
            get
            {
                return item.PacjentId;
            }
            set
            {
                item.PacjentId = value;
                OnPropertyChanged(() => PacjentId);
            }
        }

        // Combobox
        public IQueryable<KeyAndValue> LekarzItems
        {
            get
            {
                return new LekarzB(przychodniaEntities).GetLekarzKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> PacjentItems
        {
            get
            {
                return new PacjentB(przychodniaEntities).GetPacjentKeyAndTowarItems();
            }
        }

        public override void Save()
        {
            przychodniaEntities.Wizyty.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
