using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class WszyscyLekarzeViewModel : WszystkieViewModel<Lekarze>
    {
        public WszyscyLekarzeViewModel() : base()
        {
            base.DisplayName = "Wszyscy lekarze";
        }

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<Lekarze>(
                przychodniaEntities.Lekarze.ToList()
                );
        }
    }
}
