using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using System.Windows.Documents;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Helper;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class WszystkieFakturyViewModel:WszystkieViewModel<FakturaForAllView>
    {
        #region Constructor
        public WszystkieFakturyViewModel() : base()
        {
            base.DisplayName = "Faktury";
        }
        #endregion

        #region Helpers
        // pobierz wszystkie encje z bazy
        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>(
                from faktura in przychodniaEntities.Faktury
                select new FakturaForAllView
                {
                    FakturaId = faktura.FakturaId,
                    Nazwa = faktura.Nazwa,
                    Opis = faktura.Opis,
                    DataWystawienia = faktura.DataWystawienia,
                    TowarKod = faktura.Towar.Kod,
                    TowarNazwa = faktura.Towar.Nazwa,
                    TowarCena = faktura.Towar.Cena
                }
                );
        }
        #endregion


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Opis", "Nazwa towaru" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Opis") List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.Opis));
            if (SortField == "Nazwa towaru") List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.TowarNazwa));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Opis", "Nazwa towaru" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Opis") List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindField)));
            if (FindField == "Nazwa towaru") List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.TowarNazwa != null && item.TowarNazwa.StartsWith(FindField)));
        }
        #endregion
    }
}
