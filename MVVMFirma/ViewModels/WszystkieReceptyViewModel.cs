using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieReceptyViewModel : WszystkieViewModel<ReceptyForAllView>
    {
        public WszystkieReceptyViewModel() : base()
        {
            base.DisplayName = "Recepty";
        }

        public override void Load()
        {
            List = new ObservableCollection<ReceptyForAllView>(
                from recepta in przychodniaEntities.Recepty
                select new ReceptyForAllView
                {
                    ReceptaId = recepta.ReceptaId,
                    DataWydania = recepta.DataWydania,
                    LekarzImieNazwisko = recepta.Lekarze.ImieNazwisko,
                    PacjentImieNazwisko = recepta.Pacjenci.ImieNazwisko,
                    PacjentPesel = recepta.Pacjenci.Pesel,
                }
            );
        }


        #region sort and find
        // po czym sortowac
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Data", "Lekarz", "Pacjent" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Data") List = new ObservableCollection<ReceptyForAllView>(List.OrderBy(item => item.DataWydania));
            if (SortField == "Lekarz") List = new ObservableCollection<ReceptyForAllView>(List.OrderBy(item => item.LekarzImieNazwisko));
            if (SortField == "Pacjent") List = new ObservableCollection<ReceptyForAllView>(List.OrderBy(item => item.PacjentImieNazwisko));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Lekarz", "Pacjent" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Lekarz") List = new ObservableCollection<ReceptyForAllView>(List.Where(item => item.LekarzImieNazwisko != null && item.LekarzImieNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Pacjent") List = new ObservableCollection<ReceptyForAllView>(List.Where(item => item.PacjentImieNazwisko != null && item.PacjentImieNazwisko.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
