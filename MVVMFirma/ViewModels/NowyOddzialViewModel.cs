using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyOddzialViewModel : JedenViewModel<Oddzialy>
    {
        public NowyOddzialViewModel() : base("Nowy oddzial")
        {
            item = new Oddzialy();
        }

        #region Properties
        public String NazwaOddzialu
        {
            get
            {
                return item.NazwaOddzialu;
            }
            set
            {
                item.NazwaOddzialu = value;
                OnPropertyChanged(() => NazwaOddzialu);
            }
        }

        public String Lokalizacja
        {
            get
            {
                return item.Lokalizacja;
            }
            set
            {
                item.Lokalizacja = value;
                OnPropertyChanged(() => Lokalizacja);
            }
        }

        public DateTime? DataOtwarcia
        {
            get
            {
                return item.DataOtwarcia;
            }
            set
            {
                item.DataOtwarcia = value;
                OnPropertyChanged(() => DataOtwarcia);
            }
        }
        #endregion

        public override void Save()
        {
            przychodniaEntities.Oddzialy.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
