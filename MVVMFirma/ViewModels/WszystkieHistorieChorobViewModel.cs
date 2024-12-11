using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieHistorieChorobViewModel : WszystkieViewModel<HistoriaChorobForAllView>
    {
        public WszystkieHistorieChorobViewModel() : base()
        {
            base.DisplayName = "Historie chorob";
        }

        public override void Load()
        {
            List = new ObservableCollection<HistoriaChorobForAllView>(
                from historiaChoroby in przychodniaEntities.HistoriaChorob
                select new HistoriaChorobForAllView
                {
                    HistoriaChorobyId = historiaChoroby.HistoriaChorobyId,
                    OpisChoroby = historiaChoroby.OpisChoroby,
                    DataRopoznania = historiaChoroby.DataRozpoznania,
                    PacjentImieNazwisko = historiaChoroby.Pacjenci.ImieNazwisko,
                    PacjentDataUrodzenia = historiaChoroby.Pacjenci.DataUrodzenia,
                    PacjentMiasto = historiaChoroby.Pacjenci.Miasto
                }
                );
        }
    }
}
