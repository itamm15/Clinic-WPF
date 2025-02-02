using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieBadaniaViewModel : WszystkieViewModel<BadaniaForAllView>
    {
        public WszystkieBadaniaViewModel() : base()
        {
            base.DisplayName = "Badania";
        }

        public override void Load()
        {
            List = new ObservableCollection<BadaniaForAllView>(
                from badania in przychodniaEntities.Badania
                select new BadaniaForAllView
                {
                    BadanieId = badania.BadanieId,
                    TypBadania = badania.TypBadania,
                    DataBadania = badania.DataBadania,
                    PacjentImieNazwisko = badania.Pacjenci.ImieNazwisko,
                    PacjentDataUrodzenia = badania.Pacjenci.DataUrodzenia,
                    PacjentMiasto = badania.Pacjenci.Miasto,
                    LekarzImieNazwisko = badania.Lekarze.ImieNazwisko,
                    LekarzSpecjalizacja = badania.Lekarze.Specjalizacja,
                    LekarzNumerTelefonu = badania.Lekarze.NumerTelefonu,
                }
                );
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Pacjent", "Typ badania" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Pacjent") List = new ObservableCollection<BadaniaForAllView>(List.OrderBy(item => item.PacjentImieNazwisko));
            if (SortField == "Typ badania") List = new ObservableCollection<BadaniaForAllView>(List.OrderBy(item => item.TypBadania));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Pacjent", "Typ badania" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Pacjent") List = new ObservableCollection<BadaniaForAllView>(List.Where(item => item.PacjentImieNazwisko != null && item.PacjentImieNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Typ badania") List = new ObservableCollection<BadaniaForAllView>(List.Where(item => item.TypBadania != null && item.TypBadania.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
