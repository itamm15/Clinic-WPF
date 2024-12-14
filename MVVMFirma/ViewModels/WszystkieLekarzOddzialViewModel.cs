using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieLekarzOddzialViewModel : WszystkieViewModel<LekarzOddzialyForAllView>
    {
        public WszystkieLekarzOddzialViewModel()
        {
            base.DisplayName = "LekarzOddzial";
        }

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<LekarzOddzialyForAllView>(
                    from lekarzOddzial in przychodniaEntities.LekarzOddzial
                    select new LekarzOddzialyForAllView
                    {
                        DoktorOddzialId = lekarzOddzial.DoktorOddzialId,
                        DataDolaczenia = lekarzOddzial.DataDolaczenia,
                        LekarzImieNazwisko = lekarzOddzial.Lekarze.ImieNazwisko,
                        LekarzSpecjalizacja = lekarzOddzial.Lekarze.Specjalizacja,
                        OddzialNazwa = lekarzOddzial.Oddzialy.NazwaOddzialu,
                        OddzialLokalizacja = lekarzOddzial.Oddzialy.Lokalizacja
                    }
                );
        }
    }
}
