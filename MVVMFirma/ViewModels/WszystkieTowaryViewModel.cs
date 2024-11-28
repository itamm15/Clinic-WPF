using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>
    {
        #region Constructor
        public WszystkieTowaryViewModel() : base()
        {
            base.DisplayName = "Towary";
        }
        #endregion

        #region Helpers
        // pobierz wszystkie encje z bazy
        public override void Load()
        {
            List = new ObservableCollection<Towar>(
                przychodniaEntities.Towar.ToList()
                );
        }
        #endregion
    }
}