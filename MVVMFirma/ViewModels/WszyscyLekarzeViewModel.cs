﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class WszyscyLekarzeViewModel : WszystkieViewModel<Lekarze>
    {
        public WszyscyLekarzeViewModel() : base()
        {
            base.DisplayName = "Lekarze";
        }

        #region fields
        private Lekarze _WybranyLekarz;
        public Lekarze WybranyLekarz
        {
            get
            {
                return _WybranyLekarz;
            }
            set
            {
                _WybranyLekarz = value;
                Messenger.Default.Send(_WybranyLekarz);
                OnRequestClose();
            }
        }
        #endregion

        public override void Load()
        {
            List = new System.Collections.ObjectModel.ObservableCollection<Lekarze>(
                przychodniaEntities.Lekarze.ToList()
                );
        }
    }
}
