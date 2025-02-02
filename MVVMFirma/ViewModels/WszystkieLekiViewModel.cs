using System;
using System.Collections.Generic;
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
