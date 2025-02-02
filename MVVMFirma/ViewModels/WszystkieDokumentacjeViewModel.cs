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
    public class WszystkieDokumentacjeViewModel : WszystkieViewModel<DokumentacjaForAllView>
    {
        public WszystkieDokumentacjeViewModel() : base()
        {
            base.DisplayName = "Dokumentacja";
        }

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<DokumentacjaForAllView>(
                from dokumentacja in przychodniaEntities.Dokumentacja
                select new DokumentacjaForAllView
                {
                    DokumentacjaId = dokumentacja.DokumentId,
                    TypDokumentu = dokumentacja.TypDokumentu,
                    DataDokumentu = dokumentacja.DataDokumentu,
                    PacjentImieNazwisko = dokumentacja.Pacjenci.ImieNazwisko,
                    PacjentDataUrodzenia = dokumentacja.Pacjenci.DataUrodzenia,
                    PacjentMiasto = dokumentacja.Pacjenci.Miasto
                }
                );   
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Pacjent", "Typ dokumentu" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Pacjent") List = new ObservableCollection<DokumentacjaForAllView>(List.OrderBy(item => item.PacjentImieNazwisko));
            if (SortField == "Typ dokumentu") List = new ObservableCollection<DokumentacjaForAllView>(List.OrderBy(item => item.TypDokumentu));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Pacjent", "Typ dokumentu" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Pacjent") List = new ObservableCollection<DokumentacjaForAllView>(List.Where(item => item.PacjentImieNazwisko != null && item.PacjentImieNazwisko.StartsWith(FindField)));
            if (FindField == "Typ dokumentu") List = new ObservableCollection<DokumentacjaForAllView>(List.Where(item => item.TypDokumentu != null && item.TypDokumentu.StartsWith(FindField)));
        }
        #endregion
    }
}
