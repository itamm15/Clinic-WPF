using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

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
    }
}
