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
    public class WszystkiePlatnosciViewModel : WszystkieViewModel<PlatnosciForAllView>
    {
        public WszystkiePlatnosciViewModel() : base()
        {
            base.DisplayName = "Platnosci";
        }

        public override void Load()
        {
            List = new ObservableCollection<PlatnosciForAllView>(
                from platnosc in przychodniaEntities.Platnosci
                select new PlatnosciForAllView
                {
                    PlatnoscId = platnosc.PlatnoscId,
                    Kwota = platnosc.Kwota,
                    DataPlatnosci = platnosc.DataPlatnosci,
                    PacjentImieNazwisko = platnosc.Pacjenci.ImieNazwisko,
                    PacjentDataUrodzenia = platnosc.Pacjenci.DataUrodzenia,
                    PacjentMiasto = platnosc.Pacjenci.Miasto,
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
