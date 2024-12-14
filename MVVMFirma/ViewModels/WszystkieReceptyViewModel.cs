using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieReceptyViewModel : WszystkieViewModel<ReceptyForAllView>
    {
        public WszystkieReceptyViewModel() : base()
        {
            base.DisplayName = "Recepty";
        }

        public override void Load()
        {
            List = new ObservableCollection<ReceptyForAllView>(
                from recepta in przychodniaEntities.Recepty
                select new ReceptyForAllView
                {
                    ReceptaId = recepta.ReceptaId,
                    DataWydania = recepta.DataWydania,
                    LekarzImieNazwisko = recepta.Lekarze.ImieNazwisko,
                    PacjentImieNazwisko = recepta.Pacjenci.ImieNazwisko,
                    PacjentPesel = recepta.Pacjenci.Pesel,
                }
            );
        }
    }
}
