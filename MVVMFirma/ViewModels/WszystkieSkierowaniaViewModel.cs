using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieSkierowaniaViewModel : WszystkieViewModel<SkierowaniaForAllView>
    {
        public WszystkieSkierowaniaViewModel() : base()
        {
            base.DisplayName = "Wszystkie skierowania";
        }

        public override void Load()
        {
            List = new ObservableCollection<SkierowaniaForAllView>(
                from skierowanie in przychodniaEntities.Skierowanie
                select new SkierowaniaForAllView
                {
                    SkierowanieId = skierowanie.SkierowanieId,
                    NumerSkierowania = skierowanie.NumerSkierowania,
                    DataWydania = skierowanie.DataWydania,
                    BadanieId = skierowanie.BadanieId,
                    TypBadania = skierowanie.Badania.TypBadania,
                    DataBadania = skierowanie.Badania.DataBadania,
                    LekarzImieNazwisko = skierowanie.Badania.Lekarze.ImieNazwisko,
                    PacjentImieNazwisko = skierowanie.Badania.Pacjenci.ImieNazwisko,
                    PacjentPesel = skierowanie.Badania.Pacjenci.Pesel
                }
                );
        }
    }
}
