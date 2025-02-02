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
    public class WszystkieSkierowaniaViewModel : WszystkieViewModel<SkierowaniaForAllView>
    {
        public WszystkieSkierowaniaViewModel() : base()
        {
            base.DisplayName = "Skierowania";
        }

        public override void Load()
        {
            List = new ObservableCollection<SkierowaniaForAllView>(
                from skierowanie in przychodniaEntities.Skierowanie
                select new SkierowaniaForAllView
                {
                    SkierowanieId = skierowanie.SkierowanieId,
                    NumerSkierowania = skierowanie.NumerSkierowania,
                    DataWydania = skierowanie.DataWydania,
                    BadanieId = skierowanie.BadanieId,
                    TypBadania = skierowanie.Badania.TypBadania,
                    DataBadania = skierowanie.Badania.DataBadania,
                    LekarzImieNazwisko = skierowanie.Badania.Lekarze.ImieNazwisko,
                    PacjentImieNazwisko = skierowanie.Badania.Pacjenci.ImieNazwisko,
                    PacjentPesel = skierowanie.Badania.Pacjenci.Pesel
                }
                );
        }


        #region sort and find
        // po czym sortowac
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Data", "Lekarz", "Pacjent", "Numer skierowania" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Data") List = new ObservableCollection<SkierowaniaForAllView>(List.OrderBy(item => item.DataWydania));
            if (SortField == "Lekarz") List = new ObservableCollection<SkierowaniaForAllView>(List.OrderBy(item => item.LekarzImieNazwisko));
            if (SortField == "Pacjent") List = new ObservableCollection<SkierowaniaForAllView>(List.OrderBy(item => item.PacjentImieNazwisko));
            if (SortField == "Numer skierowania") List = new ObservableCollection<SkierowaniaForAllView>(List.OrderBy(item => item.NumerSkierowania));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Lekarz", "Pacjent", "Numer skierowania" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Lekarz") List = new ObservableCollection<SkierowaniaForAllView>(List.Where(item => item.LekarzImieNazwisko != null && item.LekarzImieNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Pacjent") List = new ObservableCollection<SkierowaniaForAllView>(List.Where(item => item.PacjentImieNazwisko != null && item.PacjentImieNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Numer skierowania") List = new ObservableCollection<SkierowaniaForAllView>(List.Where(item => item.NumerSkierowania != null && item.NumerSkierowania.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
