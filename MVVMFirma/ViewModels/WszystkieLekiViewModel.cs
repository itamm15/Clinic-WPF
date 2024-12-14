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
    }
}
