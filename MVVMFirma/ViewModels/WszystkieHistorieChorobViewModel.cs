using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieHistorieChorobViewModel : WszystkieViewModel<HistoriaChorobForAllView>
    {
        public WszystkieHistorieChorobViewModel() : base()
        {
            base.DisplayName = "Historie";
        }

        public override void Load()
        {
            List = new ObservableCollection<HistoriaChorobForAllView>(
                from historiaChoroby in przychodniaEntities.HistoriaChorob
                select new HistoriaChorobForAllView
                {
                    HistoriaChorobyId = historiaChoroby.HistoriaChorobyId,
                    OpisChoroby = historiaChoroby.OpisChoroby,
                    DataRopoznania = historiaChoroby.DataRozpoznania,
                    PacjentImieNazwisko = historiaChoroby.Pacjenci.ImieNazwisko,
                    PacjentDataUrodzenia = historiaChoroby.Pacjenci.DataUrodzenia,
                    PacjentMiasto = historiaChoroby.Pacjenci.Miasto
                }
                );
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Pacjent", "Data rozpoznania" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Pacjent") List = new ObservableCollection<HistoriaChorobForAllView>(List.OrderBy(item => item.PacjentImieNazwisko));
            if (SortField == "Data rozpoznania") List = new ObservableCollection<HistoriaChorobForAllView>(List.OrderBy(item => item.DataRopoznania));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Pacjent", "Opis choroby" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Pacjent") List = new ObservableCollection<HistoriaChorobForAllView>(List.Where(item => item.PacjentImieNazwisko != null && item.PacjentImieNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Opis choroby") List = new ObservableCollection<HistoriaChorobForAllView>(List.Where(item => item.OpisChoroby != null && item.OpisChoroby.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
