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
    public class WszystkieWizytyViewModel : WszystkieViewModel<WizytyForAllView>
    {
        public WszystkieWizytyViewModel() : base()
        {
            base.DisplayName = "Wizyty";
        }

        public override void Load()
        {
            List = new ObservableCollection<WizytyForAllView>(
                from wizyta in przychodniaEntities.Wizyty
                select new WizytyForAllView
                {
                    WizytaId = wizyta.WizytaId,
                    DataWizyty = wizyta.DataWizyty,
                    LekarzImieNazwisko = wizyta.Lekarze.ImieNazwisko,
                    PacjentImieNazwisko = wizyta.Pacjenci.ImieNazwisko,
                    PacjentPesel = wizyta.Pacjenci.Pesel
                }
                );
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Data", "Lekarz", "Pacjent" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Data") List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.DataWizyty));
            if (SortField == "Lekarz") List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.LekarzImieNazwisko));
            if (SortField == "Pacjent") List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.PacjentImieNazwisko));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Data od", "Lekarz" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Data od") List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.DataWizyty != null && item.DataWizyty >= DateTime.Parse(FindTextBox)));
            if (FindField == "Lekarz") List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.LekarzImieNazwisko != null && item.LekarzImieNazwisko.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
