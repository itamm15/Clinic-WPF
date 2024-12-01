using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyPacjentViewModel : JedenViewModel<Pacjenci>
    {
        public NowyPacjentViewModel() : base("Nowy pacjent")
        {
            item = new Pacjenci();
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

        public DateTime? DataUrodzenia
        {
            get
            {
                return item.DataUrodzenia;
            }
            set
            {
                item.DataUrodzenia = value;
                OnPropertyChanged(() => DataUrodzenia);
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

        public String Pesel
        {
            get
            {
                return item.Pesel;
            }
            set
            {
                item.Pesel = value;
                OnPropertyChanged(() => Pesel);
            }
        }

        public String Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                item.Miasto = value;
                OnPropertyChanged(() => Miasto);
            }
        }

        public String Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }
        #endregion

        public override void Save()
        {
            przychodniaEntities.Pacjenci.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
