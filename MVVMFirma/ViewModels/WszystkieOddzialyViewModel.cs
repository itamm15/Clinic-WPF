using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class WszystkieOddzialyViewModel : WszystkieViewModel<Oddzialy>
    {
        public WszystkieOddzialyViewModel() : base()
        {
            base.DisplayName = "Oddzialy";
        }

        public override void Load()
        {
            List = new ObservableCollection<Oddzialy>(
                przychodniaEntities.Oddzialy.ToList() 
               );
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
