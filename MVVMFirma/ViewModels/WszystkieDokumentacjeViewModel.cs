using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieDokumentacjeViewModel : WszystkieViewModel<DokumentacjaForAllView>
    {
        public WszystkieDokumentacjeViewModel() : base()
        {
            base.DisplayName = "Dokumentacja";
        }

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<DokumentacjaForAllView>(
                from dokumentacja in przychodniaEntities.Dokumentacja
                select new DokumentacjaForAllView
                {
                    DokumentacjaId = dokumentacja.DokumentId,
                    TypDokumentu = dokumentacja.TypDokumentu,
                    DataDokumentu = dokumentacja.DataDokumentu,
                    PacjentImieNazwisko = dokumentacja.Pacjenci.ImieNazwisko,
                    PacjentDataUrodzenia = dokumentacja.Pacjenci.DataUrodzenia,
                    PacjentMiasto = dokumentacja.Pacjenci.Miasto
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
