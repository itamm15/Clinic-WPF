using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels
{
    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>
    {
        #region Constructor
        public WszystkieTowaryViewModel() : base()
        {
            base.DisplayName = "Towary";
        }
        #endregion

        #region fields
        // do tego pola zostanie przypisany Towar wybrany na liscie
        private Towar _WybranyTowar;
        public Towar WybranyTowar
        {
            get
            {
                return _WybranyTowar;
            }
            set
            {
                _WybranyTowar = value;
                Messenger.Default.Send(_WybranyTowar);
                OnRequestClose();
            }
        }
        #endregion

        #region Helpers
        // pobierz wszystkie encje z bazy
        public override void Load()
        {
            List = new ObservableCollection<Towar>(
                przychodniaEntities.Towar.ToList()
                );
        }
        #endregion
    }
}