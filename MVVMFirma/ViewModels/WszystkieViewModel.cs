using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region DB
        protected readonly PrzychodniaEntities przychodniaEntities;
        #endregion

        #region Command
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add()); // bedzie otwierac nowe okno dodawania
                }

                return _AddCommand;
            }
        }
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load());
                }

                return _LoadCommand;
            }
        }
        #endregion

        #region List
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                {
                    Load();
                }

                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List); // odswiezenie listy na interfejsie
            }
        }
        #endregion

        #region Constructor
        public WszystkieViewModel()
        {
            przychodniaEntities = new PrzychodniaEntities();
        }
        #endregion

        #region Helpers
        public abstract void Load();
        private void add()
        {
            // Messenger jest z MVVMLight - dzieki niemu, wysylamy do innych obiektow komunikat DisplayName + "Add"
            // I zostanie odebrany przez MainWindowViewModel (one odpowiada za otwieranie okien)
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion
    }
}
