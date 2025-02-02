using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class WszyscyLekarzeViewModel : WszystkieViewModel<Lekarze>
    {
        public WszyscyLekarzeViewModel() : base()
        {
            base.DisplayName = "Lekarze";
        }

        #region fields
        private Lekarze _WybranyLekarz;
        public Lekarze WybranyLekarz
        {
            get
            {
                return _WybranyLekarz;
            }
            set
            {
                _WybranyLekarz = value;
                Messenger.Default.Send(_WybranyLekarz);
                OnRequestClose();
            }
        }
        #endregion

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<Lekarze>(
                przychodniaEntities.Lekarze.ToList()
                );
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Godnosc", "Specjalizacja" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Godnosc") List = new ObservableCollection<Lekarze>(List.OrderBy(item => item.ImieNazwisko));
            if (SortField == "Specjalizacja") List = new ObservableCollection<Lekarze>(List.OrderBy(item => item.Specjalizacja));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Godnosc", "Specjalizacja" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Godnosc") List = new ObservableCollection<Lekarze>(List.Where(item => item.ImieNazwisko != null && item.ImieNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Specjalizacja") List = new ObservableCollection<Lekarze>(List.Where(item => item.Specjalizacja != null && item.Specjalizacja.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
