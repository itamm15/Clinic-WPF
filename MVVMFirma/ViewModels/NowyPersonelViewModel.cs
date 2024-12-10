using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyPersonelViewModel : JedenViewModel<Personel>
    {
        public NowyPersonelViewModel() : base("Nowy personel")
        {
            item = new Personel();
        }

        #region Properties
        public String ImieNazwisko
        {
            get
            {
                return item.ImieNazwisko;
            }
            set
            {
                item.ImieNazwisko = value;
                OnPropertyChanged(() => ImieNazwisko);
            }
        }

        public String Stanowisko
        {
            get
            {
                return item.Stanowisko; 
            }
            set
            {
                item.Stanowisko = value;    
                OnPropertyChanged(() => Stanowisko);
            }
        }

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
        #endregion

        public override void Save()
        {
            przychodniaEntities.Personel.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
