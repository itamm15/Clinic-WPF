using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using System.Windows.Documents;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszystkieFakturyViewModel:WszystkieViewModel<FakturaForAllView>
    {
        #region Constructor
        public WszystkieFakturyViewModel() : base()
        {
            base.DisplayName = "Faktury";
        }
        #endregion

        #region Helpers
        // pobierz wszystkie encje z bazy
        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>(
                from faktura in przychodniaEntities.Faktury
                select new FakturaForAllView
                {
                    FakturaId = faktura.FakturaId,
                    Nazwa = faktura.Nazwa,
                    Opis = faktura.Opis,
                    DataWystawienia = faktura.DataWystawienia
                }
                );
        }
        #endregion
    }
}
