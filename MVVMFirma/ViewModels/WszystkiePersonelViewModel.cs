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
    public class WszystkiePersonelViewModel : WszystkieViewModel<Personel>
    {
        public WszystkiePersonelViewModel() : base()
        {
            base.DisplayName = "Personel";
        }

        public override void Load()
        {
            List = new ObservableCollection<Personel>(
                przychodniaEntities.Personel.ToList()
                );
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Godnosc personelu" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Godnosc personelu") List = new ObservableCollection<Personel>(List.OrderBy(item => item.ImieNazwisko));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Godnosc personelu" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Godnosc personelu") List = new ObservableCollection<Personel>(List.Where(item => item.ImieNazwisko != null && item.ImieNazwisko.StartsWith(FindField));
        }
        #endregion
    }
}
