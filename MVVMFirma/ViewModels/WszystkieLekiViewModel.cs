using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class WszystkieLekiViewModel : WszystkieViewModel<Leki>
    {
        public WszystkieLekiViewModel() : base()
        {
            base.DisplayName = "Leki";
        }

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<Leki>(
                przychodniaEntities.Leki.ToList()
                );
        }


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return new List<String> { "Nazwa", "Firma" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Nazwa") List = new ObservableCollection<Leki>(List.OrderBy(item => item.NazwaLeku));
            if (SortField == "Firma") List = new ObservableCollection<Leki>(List.OrderBy(item => item.FirmaTworzaca));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Nazwa", "Firma" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa") List = new ObservableCollection<Leki>(List.Where(item => item.NazwaLeku != null && item.NazwaLeku.StartsWith(FindField)));
            if (FindField == "Firma") List = new ObservableCollection<Leki>(List.Where(item => item.FirmaTworzaca != null && item.FirmaTworzaca.StartsWith(FindField)));
        }
        #endregion
    }
}
