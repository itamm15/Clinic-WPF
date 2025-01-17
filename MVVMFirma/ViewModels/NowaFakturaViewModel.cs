using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels
{
    public class NowaFakturaViewModel:JedenViewModel<Faktury>
    {
        public NowaFakturaViewModel() : base("Faktura") {
            item = new Faktury();
            // odbieranie Towaru wybranego z listy wszystkich towarow
            Messenger.Default.Register<Towar>(this, getTowar);
        }

        #region Command
        private BaseCommand _ShowTowary; // komenda do pokazywania wszystkich towarow (okno z lista wszystkich towarow)
        public ICommand ShowTowary
        {
            get
            {
                if (_ShowTowary == null)
                {
                    _ShowTowary = new BaseCommand(() => showTowary()); // bedzie otwierac okno z wyborem wszystkich towarow
                }

                return _ShowTowary;
            }
        }

        private void showTowary()
        {
            Messenger.Default.Send<string>("TowaryAll");
        }
        #endregion

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

        public string TowarNazwa { get; set; }
        public string TowarKod { get; set; }

        // Combobox

        public IQueryable<KeyAndValue> TowaryItems
        {
            get
            {
                return new TowarB(przychodniaEntities).GetTowaryKeyAndValueItems();
            }
        }

        // callback messengera, zeby ustawic wszystkie wartosci
        private void getTowar(Towar towar)
        {
            TowarId = towar.IdTowaru;
            TowarNazwa = towar.Nazwa;
            TowarKod = towar.Kod;
        }

        public override void Save()
        {
            przychodniaEntities.Faktury.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
