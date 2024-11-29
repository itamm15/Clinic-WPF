using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyTowarViewModel : WorkspaceViewModel
    {
        #region DB  
        private PrzychodniaEntities przychodniaEntities;
        #endregion

        #region Item
        private Towar towar;
        #endregion

        #region Command
        private BaseCommand _SaveCommand;

        public ICommand SaveCommand 
        { 
            get 
            { 
                if (_SaveCommand == null)
                {
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                }
                return _SaveCommand; 
            } 
        }
        #endregion

        #region Constructor
        public NowyTowarViewModel()
        {
            base.DisplayName = "Towar";
            przychodniaEntities = new PrzychodniaEntities();
            towar = new Towar();
        }

        #endregion

        #region Properties
        public String Kod
        {
            get
            { return towar.Kod; }
            set
            { 
                towar.Kod = value;
                OnPropertyChanged(() => Kod);
            }
        }

        public String Nazwa
        {
            get
            { return towar.Nazwa; }
            set
            {
                towar.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }

        public decimal? StawkaVatZakupu
        {
            get
            { return towar.StawkaVatZakupu; }
            set
            {
                towar.StawkaVatZakupu = value;
                OnPropertyChanged(() => StawkaVatZakupu);
            }
        }

        public decimal? StawkaVatSprzedazy
        {
            get
            { return towar.StawkaVatSprzedazy; }
            set
            {
                towar.StawkaVatSprzedazy = value;
                OnPropertyChanged(() => StawkaVatSprzedazy);
            }
        }

        public decimal? Cena
        {
            get
            { return towar.Cena; }
            set
            {
                towar.Cena = value;
                OnPropertyChanged(() => Cena);
            }
        }

        public decimal? Marza
        {
            get
            { 
                return towar.Marza; 
            }
            set
            {
                towar.Marza = value;
                OnPropertyChanged(() => Marza);
            }
        }
        #endregion

        public void Save()
        {
            przychodniaEntities.Towar.Add(towar); // stage
            przychodniaEntities.SaveChanges(); // push
        }

        public void SaveAndClose()
        {
            Save();

            OnRequestClose();
        }
    }
}
