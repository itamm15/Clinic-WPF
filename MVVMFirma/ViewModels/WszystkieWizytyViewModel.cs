using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieWizytyViewModel : WszystkieViewModel<WizytyForAllView>
    {
        public WszystkieWizytyViewModel() : base()
        {
            base.DisplayName = "Wizyty";
        }

        public override void Load()
        {
            List = new ObservableCollection<WizytyForAllView>(
                from wizyta in przychodniaEntities.Wizyty
                select new WizytyForAllView
                {
                    WizytaId = wizyta.WizytaId,
                    DataWizyty = wizyta.DataWizyty,
                    LekarzImieNazwisko = wizyta.Lekarze.ImieNazwisko,
                    PacjentImieNazwisko = wizyta.Pacjenci.ImieNazwisko,
                    PacjentPesel = wizyta.Pacjenci.Pesel
                }
                );
        }
    }
}
