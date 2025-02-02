using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieOddzialyViewModel : WszystkieViewModel<Oddzialy>
    {
        public WszystkieOddzialyViewModel() : base()
        {
            base.DisplayName = "Oddzialy";
        }

        public override void Load()
        {
            List = new ObservableCollection<Oddzialy>(
                przychodniaEntities.Oddzialy.ToList() 
               );
        }


        #region sort and find
        // po czym sortowac
       public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Data otwarcia", "Lokalizacja" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Data otwarcia") List = new ObservableCollection<Oddzialy>(List.OrderBy(item => item.DataOtwarcia));
            if (SortField == "Lokalizacja") List = new ObservableCollection<Oddzialy>(List.OrderBy(item => item.Lokalizacja));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Lokalizacja", "Nazwa oddzialu" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Lokalizacja") List = new ObservableCollection<Oddzialy>(List.Where(item => item.Lokalizacja != null && item.Lokalizacja.StartsWith(FindTextBox)));
            if (FindField == "Nazwa oddzialu") List = new ObservableCollection<Oddzialy>(List.Where(item => item.NazwaOddzialu != null && item.NazwaOddzialu.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
