using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieReceptyLekiViewModel : WszystkieViewModel<ReceptaLekiForAllView>
    {
        public WszystkieReceptyLekiViewModel() : base()
        {
            base.DisplayName = "ReceptyLeki";
        }

        public override void Load()
        {
            List = new ObservableCollection<ReceptaLekiForAllView>(
                from receptaLek in przychodniaEntities.ReceptaLeki
                select new ReceptaLekiForAllView
                {
                    ReceptaLekiId = receptaLek.ReceptaLekiId,
                    Dawkowanie = receptaLek.Dawkowanie,
                    LekNazwa = receptaLek.Leki.NazwaLeku,
                    LekTyp = receptaLek.Leki.TypLeku,
                    ReceptaId = receptaLek.ReceptaId,
                    PacjentImieNazwisko = receptaLek.Recepty.Pacjenci.ImieNazwisko
                }
                );
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Dawkowanie", "Nazwa leku", "Pacjent" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Dawkowanie") List = new ObservableCollection<ReceptaLekiForAllView>(List.OrderBy(item => item.Dawkowanie));
            if (SortField == "Nazwa leku") List = new ObservableCollection<ReceptaLekiForAllView>(List.OrderBy(item => item.LekNazwa));
            if (SortField == "Pacjent") List = new ObservableCollection<ReceptaLekiForAllView>(List.OrderBy(item => item.PacjentImieNazwisko));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Nazwa leku", "Pacjent" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa leku") List = new ObservableCollection<ReceptaLekiForAllView>(List.Where(item => item.LekNazwa != null && item.LekNazwa.StartsWith(FindTextBox)));
            if (FindField == "Pacjent") List = new ObservableCollection<ReceptaLekiForAllView>(List.Where(item => item.PacjentImieNazwisko != null && item.PacjentImieNazwisko.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
