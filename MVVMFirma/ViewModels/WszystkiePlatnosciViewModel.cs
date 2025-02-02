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
    public class WszystkiePlatnosciViewModel : WszystkieViewModel<PlatnosciForAllView>
    {
        public WszystkiePlatnosciViewModel() : base()
        {
            base.DisplayName = "Platnosci";
        }

        public override void Load()
        {
            List = new ObservableCollection<PlatnosciForAllView>(
                from platnosc in przychodniaEntities.Platnosci
                select new PlatnosciForAllView
                {
                    PlatnoscId = platnosc.PlatnoscId,
                    Kwota = platnosc.Kwota,
                    DataPlatnosci = platnosc.DataPlatnosci,
                    PacjentImieNazwisko = platnosc.Pacjenci.ImieNazwisko,
                    PacjentDataUrodzenia = platnosc.Pacjenci.DataUrodzenia,
                    PacjentMiasto = platnosc.Pacjenci.Miasto,
                }
            );
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Kwota", "Data platnosci", "Pacjent" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Kwota") List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.Kwota));
            if (SortField == "Data platnosci") List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.DataPlatnosci));
            if (SortField == "Pacjent") List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.PacjentImieNazwisko));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Kwota od", "Pacjent" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Kwota od") List = new ObservableCollection<PlatnosciForAllView>(List.Where(item => item.Kwota != null && item.Kwota >= decimal.Parse(FindTextBox)));
            if (FindField == "Pacjent") List = new ObservableCollection<PlatnosciForAllView>(List.Where(item => item.PacjentImieNazwisko != null && item.PacjentImieNazwisko.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
