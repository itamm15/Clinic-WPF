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
            return new List<String> { "Data dolaczenia", "Lokalizacja" };
        }

        // jak sortowac
        public override void Sort()
        {
            Load();
            if (SortField == "Data dolaczenia") List = new ObservableCollection<PersonelOddzialForAllView>(List.OrderBy(item => item.DataDolaczenia));
            if (SortField == "Lokalizacja") List = new ObservableCollection<PersonelOddzialForAllView>(List.OrderBy(item => item.OddzialLokalizacja));
        }

        // po czym szukac
        public override List<String> GetComboboxFindList()
        {
            return new List<String> { "Lokalizacja", "Nazwa oddzialu" };
        }

        // jak szukac
        public override void Find()
        {
            Load();
            if (FindField == "Lokalizacja") List = new ObservableCollection<PersonelOddzialForAllView>(List.Where(item => item.OddzialLokalizacja != null && item.OddzialLokalizacja.StartsWith(FindField)));
            if (FindField == "Nazwa oddzialu") List = new ObservableCollection<PersonelOddzialForAllView>(List.Where(item => item.OddzialNazwaOddzialu != null && item.OddzialNazwaOddzialu.StartsWith(FindField)));
        }
        #endregion
    }
}
