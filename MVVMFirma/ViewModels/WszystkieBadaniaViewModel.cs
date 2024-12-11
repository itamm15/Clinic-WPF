using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieBadaniaViewModel : WszystkieViewModel<BadaniaForAllView>
    {
        public WszystkieBadaniaViewModel() : base()
        {
            base.DisplayName = "Wszystkie badania";
        }

        public override void Load()
        {
            List = new ObservableCollection<BadaniaForAllView>(
                from badania in przychodniaEntities.Badania
                select new BadaniaForAllView
                {
                    BadanieId = badania.BadanieId,
                    TypBadania = badania.TypBadania,
                    DataBadania = badania.DataBadania,
                    PacjentImieNazwisko = badania.Pacjenci.ImieNazwisko,
                    PacjentDataUrodzenia = badania.Pacjenci.DataUrodzenia,
                    PacjentMiasto = badania.Pacjenci.Miasto,
                    LekarzImieNazwisko = badania.Lekarze.ImieNazwisko,
                    LekarzSpecjalizacja = badania.Lekarze.Specjalizacja,
                    LekarzNumerTelefonu = badania.Lekarze.NumerTelefonu,
                }
                );
        }
    }
}
