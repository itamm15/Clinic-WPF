using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieReceptyLekiViewModel : WszystkieViewModel<ReceptaLekiForAllView>
    {
        public WszystkieReceptyLekiViewModel() : base()
        {
            base.DisplayName = "Wszystkie recepty-leki";
        }

        public override void Load()
        {
            List = new ObservableCollection<ReceptaLekiForAllView>(
                from receptaLek in przychodniaEntities.ReceptaLeki
                select new ReceptaLekiForAllView
                {
                    ReceptaLekiId = receptaLek.ReceptaLekiId,
                    Dawkowanie = receptaLek.Dawkowanie,
                    LekNazwa = receptaLek.Leki.NazwaLeku,
                    LekTyp = receptaLek.Leki.TypLeku,
                    ReceptaId = receptaLek.ReceptaId,
                    PacjentImieNazwisko = receptaLek.Recepty.Pacjenci.ImieNazwisko
                }
                );
        }
    }
}
