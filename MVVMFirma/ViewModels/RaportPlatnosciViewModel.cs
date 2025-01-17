﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class RaportPlatnosciViewModel : WorkspaceViewModel
    {
        private PrzychodniaEntities przychodniaEntities;
        public RaportPlatnosciViewModel() 
        {
            base.DisplayName = "Raport platnosci";
            przychodniaEntities = new PrzychodniaEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            PlatnosciSuma = 0;
        }

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

        private decimal? _PlatnosciSuma;
        public decimal? PlatnosciSuma
        {
            get
            {
                return _PlatnosciSuma;
            }
            set
            {
                if (_PlatnosciSuma != value)
                {
                    _PlatnosciSuma = value;
                    OnPropertyChanged(() => PlatnosciSuma);
                }
            }
        }

        private List<PlatnosciForAllView> _PlatnosciLista;
        public List<PlatnosciForAllView> PlatnosciLista
        {
            get
            {
                return _PlatnosciLista;
            }
            set
            {
                if (_PlatnosciLista != value)
                {
                    _PlatnosciLista = value;
                    OnPropertyChanged(() => PlatnosciLista);
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

        // Ta komenda zostanie podpieta pod przycisk Oblicz dla Raportu Platnosci
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => this.obliczPlatnosciClick());
                }

                return _ObliczCommand;
            }
        }

        private void obliczPlatnosciClick()
        {
            // Oblicz sume platnosci dla wybranego pacjenta w okresie od DataOd do DataDo
            PlatnosciSuma = new RaportPlatnoscB(przychodniaEntities).PlatnoscOkresPacjent(PacjentId, DataOd, DataDo);
            if(PlatnosciSuma == null)
            {
                PlatnosciSuma = 0;
            }

            PlatnosciLista = new RaportPlatnoscB(przychodniaEntities).GetPlatnosci(PacjentId, DataOd, DataDo);
        }
    }
}
