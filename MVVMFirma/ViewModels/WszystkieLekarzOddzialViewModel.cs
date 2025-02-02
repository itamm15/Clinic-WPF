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
    public class WszystkieLekarzOddzialViewModel : WszystkieViewModel<LekarzOddzialyForAllView>
    {
        public WszystkieLekarzOddzialViewModel()
        {
            base.DisplayName = "LekarzOddzial";
        }

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<LekarzOddzialyForAllView>(
                    from lekarzOddzial in przychodniaEntities.LekarzOddzial
                    select new LekarzOddzialyForAllView
                    {
                        DoktorOddzialId = lekarzOddzial.DoktorOddzialId,
                        DataDolaczenia = lekarzOddzial.DataDolaczenia,
                        LekarzImieNazwisko = lekarzOddzial.Lekarze.ImieNazwisko,
                        LekarzSpecjalizacja = lekarzOddzial.Lekarze.Specjalizacja,
                        OddzialNazwa = lekarzOddzial.Oddzialy.NazwaOddzialu,
                        OddzialLokalizacja = lekarzOddzial.Oddzialy.Lokalizacja
                    }
                );
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Lekarz", "Nazwa oddzialu" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Lekarz") List = new ObservableCollection<LekarzOddzialyForAllView>(List.OrderBy(item => item.LekarzImieNazwisko));
            if (SortField == "Nazwa oddzialu") List = new ObservableCollection<LekarzOddzialyForAllView>(List.OrderBy(item => item.OddzialNazwa));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Lekarz", "Nazwa oddzialu" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Lekarz") List = new ObservableCollection<LekarzOddzialyForAllView>(List.Where(item => item.LekarzImieNazwisko != null && item.LekarzImieNazwisko.StartsWith(FindField)));
            if (FindField == "Nazwa oddzialu") List = new ObservableCollection<LekarzOddzialyForAllView>(List.Where(item => item.OddzialNazwa != null && item.OddzialNazwa.StartsWith(FindField)));
        }
        #endregion
    }
}
