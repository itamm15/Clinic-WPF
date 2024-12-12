using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkiePersonelOddzialViewModel : WszystkieViewModel<PersonelOddzialForAllView>
    {
        public WszystkiePersonelOddzialViewModel() : base()
        {
            base.DisplayName = "Personel oddzial";
        }

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<PersonelOddzialForAllView>(
                from personelOddzial in przychodniaEntities.PersonelOddzial
                select new PersonelOddzialForAllView
                {
                    PersonelOddzialId = personelOddzial.PersonelOddzial1,
                    DataDolaczenia = personelOddzial.DataDolaczenia,
                    OddzialNazwaOddzialu = personelOddzial.Oddzialy.NazwaOddzialu,
                    OddzialLokalizacja = personelOddzial.Oddzialy.Lokalizacja,
                    OddzialDataOtwarcia = personelOddzial.Oddzialy.DataOtwarcia,
                    PersonelImieNazwisko = personelOddzial.Personel.ImieNazwisko,
                    PersonelStanowisko = personelOddzial.Personel.Stanowisko
                }
                );
        }
    }
}
