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
    public class NowaHistoriaChorobViewModel : JedenViewModel<HistoriaChorob>
    {
        public NowaHistoriaChorobViewModel() : base("Nowa historia chorob")
        {
            item = new HistoriaChorob();
        }

        // fields
        public String OpisChoroby
        {
            get
            {
                return item.OpisChoroby;
            }
            set
            {
                item.OpisChoroby = value;
                OnPropertyChanged(() => OpisChoroby);
            }
        }

        public DateTime? DataRozpoznania
        {
            get
            {
                return item.DataRozpoznania;
            }
            set
            {
                item.DataRozpoznania = value;
                OnPropertyChanged(() => DataRozpoznania);
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

        public IQueryable<KeyAndValue> PacjentItems
        {
            get
            {
                return new PacjentB(przychodniaEntities).GetPacjentKeyAndTowarItems();
            }
        }

        public override void Save()
        {
            przychodniaEntities.HistoriaChorob.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
