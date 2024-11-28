using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Towary",
                    new BaseCommand(() => this.ShowAllTowar())),

                new CommandViewModel(
                    "Towar",
                    new BaseCommand(() => this.CreateTowar())),
                 new CommandViewModel(
                    "Faktury",
                    new BaseCommand(() => this.ShowAllFaktury())),
                  new CommandViewModel(
                    "Faktura",
                    new BaseCommand(() => this.CreateFaktura())),
                  new CommandViewModel(
                    "Film",
                    new BaseCommand(() => this.CreateFilm())),
                  new CommandViewModel(
                    "Filmy",
                    new BaseCommand(() => this.ShowAllFilmy())),

                  new CommandViewModel("Oddzial", new BaseCommand(() => this.CreateOddzial())),
                  new CommandViewModel("Oddzialy", new BaseCommand(() => this.ShowAllOddzialy())),
                  new CommandViewModel("Dodaj Personel", new BaseCommand(() => this.CreatePersonel())),
                  new CommandViewModel("Caly Personel", new BaseCommand(() => this.ShowAllPersonel())),
                  new CommandViewModel("Dodaj lekarz oddzial", new BaseCommand(() => this.CreateLekarzOddzial())),
                  new CommandViewModel("Lekarze oddzialy", new BaseCommand(() => this.ShowAllLekarzOddzial())),
                  new CommandViewModel("Dodaj Personel oddzialy", new BaseCommand(() => this.CreatePersonelOddzial())),
                  new CommandViewModel("Personel oddzialy", new BaseCommand(() => this.ShowAllPersoneOddzial()))
                  
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateTowar()
        {
            NowyTowarViewModel workspace = new NowyTowarViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateFaktura()
        {
            NowaFakturaViewModel workspace = new NowaFakturaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateFilm()
        {
            NowyFilmViewModel workspace = new NowyFilmViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFilmy()
        {
            WszystkieFilmyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieFilmyViewModel)
                as WszystkieFilmyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFilmyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void CreatePersonel()
        {
            NowyPersonelViewModel workspace = new NowyPersonelViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllPersonel()
        {
            WszystkiePersonelViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePersonelViewModel)
                as WszystkiePersonelViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePersonelViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void CreatePersonelOddzial()
        {
            NowyPersonelOddzialViewModel workspace = new NowyPersonelOddzialViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllPersoneOddzial()
        {
            WszystkiePersonelOddzialViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePersonelOddzialViewModel)
                as WszystkiePersonelOddzialViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePersonelOddzialViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void CreateOddzial()
        {
            NowyOddzialViewModel workspace = new NowyOddzialViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllOddzialy()
        {
            WszystkieOddzialyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieOddzialyViewModel) as WszystkieOddzialyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieOddzialyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateLekarzOddzial()
        {
            NowyLekarzOddzialViewModel workspace = new NowyLekarzOddzialViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllLekarzOddzial()
        {
            WszystkieLekarzOddzialViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieLekarzOddzialViewModel) as WszystkieLekarzOddzialViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieLekarzOddzialViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllTowar()
        {
            WszystkieTowaryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
                as WszystkieTowaryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFaktury()
        {
            WszystkieFakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel)
                as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
