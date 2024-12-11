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
            base.DisplayName = "Cala dokumentacja medyczna";
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
    }
}
