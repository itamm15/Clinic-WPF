using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyLekViewModel : JedenViewModel<Leki>
    {
        public NowyLekViewModel() : base("Nowy lek")
        {
            item = new Leki();
        }

        #region Properties
        public String NazwaLeku
        {
            get
            {
                return item.NazwaLeku;
            }
            set
            {
                item.NazwaLeku = value;
                OnPropertyChanged(() => NazwaLeku);
            }
        }

        public String TypLeku
        {
            get
            {
                return item.TypLeku;
            }
            set
            {
                item.TypLeku = value;
                OnPropertyChanged(() => TypLeku);
            }
        }

        public String FirmaTworzaca
        {
            get
            {
                return item.FirmaTworzaca;
            }
            set
            {
                item.FirmaTworzaca = value;
                OnPropertyChanged(() => FirmaTworzaca);
            }
        }
        #endregion

        public override void Save()
        {
            przychodniaEntities.Leki.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
