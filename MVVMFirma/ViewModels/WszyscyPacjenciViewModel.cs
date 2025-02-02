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
    public class WszyscyPacjenciViewModel : WszystkieViewModel<Pacjenci>
    {
        public WszyscyPacjenciViewModel() : base()
        {
            base.DisplayName = "Pacjenci";
        }

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<Pacjenci>(przychodniaEntities.Pacjenci.ToList());
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Godnosc", "Miasto" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Godnosc") List = new ObservableCollection<Pacjenci>(List.OrderBy(item => item.ImieNazwisko));
            if (SortField == "Miasto") List = new ObservableCollection<Pacjenci>(List.OrderBy(item => item.Miasto));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Godnosc", "Miasto" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Godnosc") List = new ObservableCollection<Pacjenci>(List.Where(item => item.ImieNazwisko != null && item.ImieNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Miasto") List = new ObservableCollection<Pacjenci>(List.Where(item => item.Miasto != null && item.Miasto.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
