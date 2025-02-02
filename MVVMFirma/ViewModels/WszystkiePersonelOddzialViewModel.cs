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
            base.DisplayName = "PersonelOddzialy";
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


        #region sort and find
        // po czym sortowac
        public override List<String> GetComboboxSortList()
        {
            return null;
        }

        // jak sortowac
        public override void Sort()
        {

        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return null;
        }

        // jak szukac
        public override void Find()
        {

        }
        #endregion
    }
}
