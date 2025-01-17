using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{

    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region DB  
        protected PrzychodniaEntities przychodniaEntities;
        #endregion

        #region Item
        protected T item;
        #endregion

        #region Command
        private BaseCommand _SaveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                }
                return _SaveCommand;
            }
        }
        #endregion

        #region Constructor
        public JedenViewModel(String displayName)
        {
            base.DisplayName = displayName;
            przychodniaEntities = new PrzychodniaEntities();
        }
        #endregion

        #region Helpers
        public abstract void Save();
        public void SaveAndClose()
        {
            // sprawdzamy czy dane sa okej
            if (IsValid())
            {
                Save();
                OnRequestClose();
            } 
        }
        #endregion

        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion
    }
}
