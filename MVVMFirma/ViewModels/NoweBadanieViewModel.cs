using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class NoweBadanieViewModel : JedenViewModel<Badania>
    {
        public NoweBadanieViewModel() : base("Nowe badanie")
        {
            item = new Badania();
            Messenger.Default.Register<Lekarze>(this, getLekarz);
        }

        // commands
        private BaseCommand _ShowLekarze;
        public ICommand ShowLekarze
        {
            get
            {
                if (_ShowLekarze == null)
                {
                    _ShowLekarze = new BaseCommand(() => showLekarze());
                }
                return _ShowLekarze;
            }
        }

        private void showLekarze()
        {
            Messenger.Default.Send("LekarzeAll");
        }

        // fields 
        public String TypBadania
        {
            get
            {
                return item.TypBadania;
            }
            set
            {
                item.TypBadania = value;
                OnPropertyChanged(() =>  TypBadania);
            }
        }

        public DateTime? DataBadania
        {
            get
            {
                return item.DataBadania;
            }
            set
            {
                item.DataBadania = value;
                OnPropertyChanged(() => DataBadania);
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

        public string LekarzImieNazwisko { get; set; }
        public string LekarzSpecjalizacja { get; set; }

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

        private void getLekarz(Lekarze lekarz)
        {
            LekarzId = lekarz.LekarzId;
            LekarzImieNazwisko = lekarz.ImieNazwisko;
            LekarzSpecjalizacja = lekarz.Specjalizacja;
        }
        public override void Save()
        {
            przychodniaEntities.Badania.Add(item);
            przychodniaEntities.SaveChanges();
        }
    }
}
