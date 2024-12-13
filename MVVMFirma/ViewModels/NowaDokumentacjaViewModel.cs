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
    public class NowaDokumentacjaViewModel : JedenViewModel<Dokumentacja>
    {
        public NowaDokumentacjaViewModel() : base("Nowa dokumentacja")
        {
            item = new Dokumentacja();
        }

        // fields
        public String TypDokumentu
        {
            get
            {
                return item.TypDokumentu;
            }
            set
            {
                item.TypDokumentu = value;
                OnPropertyChanged(() =>  TypDokumentu);
            }
        }

        public DateTime? DataDokumentu
        {
            get
            {
                return item.DataDokumentu;
            }
            set
            {
                item.DataDokumentu = value;
                OnPropertyChanged(() => DataDokumentu);
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
            przychodniaEntities.Dokumentacja.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
