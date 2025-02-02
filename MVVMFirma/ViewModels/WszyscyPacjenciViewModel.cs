using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

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
            return null;
        }

        // jak sortowac
        public override void Sort()
        {

        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return null;
        }

        // jak szukac
        public override void Find()
        {

        }
        #endregion
    }
}
