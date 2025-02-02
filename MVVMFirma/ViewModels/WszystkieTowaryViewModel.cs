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

        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "kod", "nazwa", "cena", "nazwa i cena"};
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "nazwa") List = new ObservableCollection<Towar>(List.OrderBy(item => item.Nazwa));
            if (SortField == "kod") List = new ObservableCollection<Towar>(List.OrderBy(item => item.Kod));
            if (SortField == "cena") List = new ObservableCollection<Towar>(List.OrderBy(item => item.Cena));
            if (SortField == "nazwa i cena") List = new ObservableCollection<Towar>(List.OrderBy(item => item.Nazwa).OrderBy(item => item.Cena));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "kod", "nazwa"};
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "nazwa") List = new ObservableCollection<Towar>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "kod") List = new ObservableCollection<Towar>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
        }
        #endregion
    }
}