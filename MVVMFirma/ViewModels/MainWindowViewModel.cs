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
using GalaSoft.MvvmLight.Messaging;

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
            // on oczekuje wiadomosci (typu string), a pozniej wywoluje open
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                  new CommandViewModel("Dodaj towar", new BaseCommand(() => this.CreateTowar())),
                  new CommandViewModel("Towary", new BaseCommand(() => this.ShowAllTowar())),
                  new CommandViewModel("Dodaj Fakture", new BaseCommand(() => this.CreateFaktura())),
                  new CommandViewModel("Faktury", new BaseCommand(() => this.ShowAllFaktury())),
                  new CommandViewModel("Dodaj oddzial", new BaseCommand(() => this.CreateOddzial())),
                  new CommandViewModel("Oddzialy", new BaseCommand(() => this.ShowAllOddzialy())),
                  new CommandViewModel("Dodaj Personel", new BaseCommand(() => this.CreatePersonel())),
                  new CommandViewModel("Caly Personel", new BaseCommand(() => this.ShowAllPersonel())),
                  new CommandViewModel("Dodaj lekarz oddzial", new BaseCommand(() => this.CreateLekarzOddzial())),
                  new CommandViewModel("Lekarze oddzialy", new BaseCommand(() => this.ShowAllLekarzOddzial())),
                  new CommandViewModel("Dodaj Personel oddzialy", new BaseCommand(() => this.CreatePersonelOddzial())),
                  new CommandViewModel("Personel oddzialy", new BaseCommand(() => this.ShowAllPersonelOddzial())),
                  new CommandViewModel("Dodaj lekarza", new BaseCommand(() => this.CreateLekarz())),
                  new CommandViewModel("Lekarze", new BaseCommand(() => this.ShowAllLekarz())),
                  new CommandViewModel("Dodaj wizyte", new BaseCommand(() => this.CreateWizyta())),
                  new CommandViewModel("Wizyty", new BaseCommand(() => this.ShowAllWizyty())),
                  new CommandViewModel("Dodaj badanie", new BaseCommand(() => this.CreateBadanie())),
                  new CommandViewModel("Badania", new BaseCommand(() => this.ShowAllBadania())),
                  new CommandViewModel("Dodaj skierowanie", new BaseCommand(() => this.CreateSkierowanie())),
                  new CommandViewModel("Skierowania", new BaseCommand(() => this.ShowAllSkierowania())),
                  new CommandViewModel("Dodaj platnosc", new BaseCommand(() => this.CreatePlatnosc())),
                  new CommandViewModel("Platnosci", new BaseCommand(() => this.ShowAllPlatnosci())),
                  new CommandViewModel("Dodaj pacjenta", new BaseCommand(() => this.CreatePacjent())),
                  new CommandViewModel("Pacjenci", new BaseCommand(() => this.ShowAllPacjenci())),
                  new CommandViewModel("Dodaj historie choroby", new BaseCommand(() => this.CreateHistoriaChorob())),
                  new CommandViewModel("Historie chorob", new BaseCommand(() => this.ShowAllHistorieChorob())),
                  new CommandViewModel("Dodaj dokumentacje", new BaseCommand(() => this.CreateDokumentacja())),
                  new CommandViewModel("Dokumentacja", new BaseCommand(() => this.ShowAllDokumentacja())),
                  new CommandViewModel("Dodaj lek", new BaseCommand(() => this.CreateLek())),
                  new CommandViewModel("Leki", new BaseCommand(() => this.ShowAllLeki())),
                  new CommandViewModel("Dodaj recepte", new BaseCommand(() => this.CreateRecepta())),
                  new CommandViewModel("Recepty", new BaseCommand(() => this.ShowAllRecepty())),
                  new CommandViewModel("Dodaj recepta lek", new BaseCommand(() => this.CreateReceptaLek())),
                  new CommandViewModel("Recepta leki", new BaseCommand(() => this.ShowAllReceptyLeki())),
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
        private void open(string name) // wyslany komunikat
        {
            if (name == "TowaryAdd") CreateView(new NowyTowarViewModel());
            if (name == "LekarzeAdd") CreateView(new NowyLekarzViewModel());
            if (name == "PacjenciAdd") CreateView(new NowyPacjentViewModel());
            if (name == "BadaniaAdd") CreateView(new NoweBadanieViewModel());
            if (name == "DokumentacjaAdd") CreateView(new NowaDokumentacjaViewModel());
            if (name == "FakturyAdd") CreateView(new NowaFakturaViewModel());
            if (name == "HistorieAdd") CreateView(new NowaHistoriaChorobViewModel());
            if (name == "LekarzOddzialAdd") CreateView(new NowyLekarzOddzialViewModel());
            if (name == "LekiAdd") CreateView(new NowyLekViewModel());
            if (name == "OddzialyAdd") CreateView(new NowyOddzialViewModel());
            if (name == "PersonelOddzialyAdd") CreateView(new NowyPersonelOddzialViewModel());
            if (name == "PersonelAdd") CreateView(new NowyPersonelViewModel());
            if (name == "PlatnosciAdd") CreateView(new NowaPlatnoscViewModel());
            if (name == "ReceptyLekiAdd") CreateView(new NowaReceptaLekViewModel());
            if (name == "ReceptyAdd") CreateView(new NowaReceptaViewModel());
            if (name == "SkierowaniaAdd") CreateView(new NoweSkierowanieViewModel());
            if (name == "SkierowaniaAdd") CreateView(new NoweSkierowanieViewModel());
            if (name == "WizytyAdd") CreateView(new NowaWizytaViewModel());
        }

        private void CreateView(WorkspaceViewModel nowy)
        {
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
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

        private void ShowAllPersonelOddzial()
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

        private void CreateLekarz()
        {
            NowyLekarzViewModel workspace = new NowyLekarzViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        
        private void ShowAllLekarz()
        {
            WszyscyLekarzeViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyLekarzeViewModel) as WszyscyLekarzeViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyLekarzeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateWizyta()
        {
            NowaWizytaViewModel workspace = new NowaWizytaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllWizyty()
        {
            WszystkieWizytyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieWizytyViewModel) as WszystkieWizytyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieWizytyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateBadanie()
        {
            NoweBadanieViewModel workspace = new NoweBadanieViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllBadania()
        {
            WszystkieBadaniaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieBadaniaViewModel) as WszystkieBadaniaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieBadaniaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateSkierowanie()
        {
            NoweSkierowanieViewModel workspace = new NoweSkierowanieViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllSkierowania()
        {
            WszystkieSkierowaniaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieSkierowaniaViewModel) as WszystkieSkierowaniaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSkierowaniaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreatePlatnosc()
        {
            NowaPlatnoscViewModel workspace = new NowaPlatnoscViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllPlatnosci()
        {
            WszystkiePlatnosciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkiePlatnosciViewModel) as WszystkiePlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePlatnosciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreatePacjent()
        {
            NowyPacjentViewModel workspace = new NowyPacjentViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllPacjenci()
        {
            WszyscyPacjenciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyPacjenciViewModel) as WszyscyPacjenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPacjenciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateHistoriaChorob()
        {
            NowaHistoriaChorobViewModel workspace = new NowaHistoriaChorobViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllHistorieChorob()
        {
            WszystkieHistorieChorobViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieHistorieChorobViewModel) as WszystkieHistorieChorobViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieHistorieChorobViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateDokumentacja()
        {
            NowaDokumentacjaViewModel workspace = new NowaDokumentacjaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllDokumentacja()
        {
            WszystkieDokumentacjeViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieDokumentacjeViewModel) as WszystkieDokumentacjeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieDokumentacjeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateLek()
        {
            NowyLekViewModel workspace = new NowyLekViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllLeki()
        {
            WszystkieLekiViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieLekiViewModel) as WszystkieLekiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieLekiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateRecepta()
        {
            NowaReceptaViewModel workspace = new NowaReceptaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllRecepty()
        {
            WszystkieReceptyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieReceptyViewModel) as WszystkieReceptyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieReceptyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateReceptaLek()
        {
            NowaReceptaLekViewModel workspace = new NowaReceptaLekViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllReceptyLeki()
        {
            WszystkieReceptyLekiViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieReceptyLekiViewModel) as WszystkieReceptyLekiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieReceptyLekiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void CreateTowar()
        {
            NowyTowarViewModel workspace = new NowyTowarViewModel();
            this.Workspaces.Add(workspace);
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

        private void CreateFaktura()
        {
            NowaFakturaViewModel workspace = new NowaFakturaViewModel();
            this.Workspaces.Add(workspace);
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
