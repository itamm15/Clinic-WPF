using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyLekarzViewModel : JedenViewModel<Lekarze>
    {
        public NowyLekarzViewModel() : base("Nowy lekarz")
        {
            item = new Lekarze();
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

        public String Specjalizacja
        {
            get
            {
                return item.Specjalizacja;
            }
            set
            {
                item.Specjalizacja = value;
                OnPropertyChanged(() =>  Specjalizacja);
            }
        }

        public String NumerTelefonu
        {
            get
            {
                return item.NumerTelefonu;
            }
            set
            {
                item.NumerTelefonu = value;
                OnPropertyChanged(() => NumerTelefonu);
            }
        }
        #endregion

        public override void Save()
        {
            przychodniaEntities.Lekarze.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
