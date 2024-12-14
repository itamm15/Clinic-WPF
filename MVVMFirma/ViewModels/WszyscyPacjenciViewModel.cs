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
    }
}
