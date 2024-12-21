using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class RaportBadaniaViewModel : WorkspaceViewModel
    {
        private PrzychodniaEntities przychodniaEntities;
        public RaportBadaniaViewModel()
        {
            base.DisplayName = "Raport badania";
            przychodniaEntities = new PrzychodniaEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            LiczbaBadan = 0;
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

        private int _LiczbaBadan;
        public int LiczbaBadan
        {
            get
            {
                return _LiczbaBadan;
            }
            set
            {
                if (_LiczbaBadan != value)
                {
                    _LiczbaBadan = value;
                    OnPropertyChanged(() => LiczbaBadan);
                }
            }
        }

        public IQueryable<KeyAndValue> PacjentItems
        {
            get
            {
                IQueryable<KeyAndValue> pacjentQuery = new PacjentB(przychodniaEntities).GetPacjentKeyAndTowarItems();
                List<KeyAndValue> pacjentList = pacjentQuery.ToList();

                pacjentList.Insert(0, new KeyAndValue
                {
                    Key = -1,
                    Value = "Wszyscy pacjenci"
                });

                return pacjentList.AsQueryable();
            }
        }

        private List<BadaniaForAllView> _BadaniaLista;
        public List<BadaniaForAllView> BadaniaLista
        {
            get
            {
                return _BadaniaLista;
            }
            set
            {
                if (_BadaniaLista != value)
                {
                    _BadaniaLista = value;
                    OnPropertyChanged(() => BadaniaLista);
                }
            }
        }

        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => this.Oblicz());
                }
                return _ObliczCommand;
            }
        }

        private void Oblicz()
        {
            LiczbaBadan = new RaportBadaniaB(przychodniaEntities).GetLiczbaBadan(PacjentId, DataOd, DataDo);
            BadaniaLista = new RaportBadaniaB(przychodniaEntities).GetBadania(PacjentId, DataOd, DataDo);
        }
    }
}
