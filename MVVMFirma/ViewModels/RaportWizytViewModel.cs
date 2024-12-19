using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class RaportWizytViewModel : WorkspaceViewModel
    {
        private PrzychodniaEntities przychodniaEntities;
        public RaportWizytViewModel()
        {
            base.DisplayName = "Raport wizyt";
            przychodniaEntities = new PrzychodniaEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            LiczbaWizyt = 0;
        }

        // fields

        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }

        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }

        private int _PacjentId;
        public int PacjentId
        {
            get
            {
                return _PacjentId;
            }
            set
            {
                if (_PacjentId != value)
                {
                    _PacjentId = value;
                    OnPropertyChanged(() => PacjentId);
                }
            }
        }

        private int? _LiczbaWizyt;
        public int? LiczbaWizyt
        {
            get
            {
                return _LiczbaWizyt;
            }
            set
            {
                if (_LiczbaWizyt != value)
                {
                    _LiczbaWizyt = value;
                    OnPropertyChanged(() => LiczbaWizyt);
                }
            }
        }

        public IQueryable<KeyAndValue> PacjentItems
        {
            get
            {
                IQueryable<KeyAndValue> pacjenciQuery = new PacjentB(przychodniaEntities).GetPacjentKeyAndTowarItems();
                List<KeyAndValue> pacjenciLista = pacjenciQuery.ToList();

                pacjenciLista.Insert(0, new KeyAndValue
                {
                    Key = -1,
                    Value = "Wszyscy"
                });

                return pacjenciLista.AsQueryable();
            }
        }

        private List<WizytyForAllView> _Wizyty;
        public List<WizytyForAllView> Wizyty
        {
            get
            {
                return _Wizyty;
            }
            set
            {
                if (_Wizyty != value)
                {
                    _Wizyty = value;
                    OnPropertyChanged(() => Wizyty);
                }
            }
        }

        // Ta komenda zostanie podpieta pod przycisk Oblicz dla Raportu wizyt
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => this.obliczLiczbeWizyt());
                }

                return _ObliczCommand;
            }
        }

        private void obliczLiczbeWizyt()
        {
            RaportWizytB raportWizyty = new RaportWizytB(przychodniaEntities);
            LiczbaWizyt = raportWizyty.WizytyOkresPacjent(PacjentId, DataOd, DataDo);
            Wizyty = raportWizyty.GetAllWizyty(PacjentId, DataOd, DataDo);
        }
    }
}
