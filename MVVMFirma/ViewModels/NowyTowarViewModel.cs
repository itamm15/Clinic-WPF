﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class NowyTowarViewModel : JedenViewModel<Towar>
    {

        #region Constructor
        public NowyTowarViewModel() : base("Towar")
        {
            item = new Towar();
        }

        #endregion

        #region Properties
        public String Kod
        {
            get
            { return item.Kod; }
            set
            {
                item.Kod = value;
                OnPropertyChanged(() => Kod);
            }
        }

        public String Nazwa
        {
            get
            { return item.Nazwa; }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }

        public decimal? StawkaVatZakupu
        {
            get
            { return item.StawkaVatZakupu; }
            set
            {
                item.StawkaVatZakupu = value;
                OnPropertyChanged(() => StawkaVatZakupu);
            }
        }

        public decimal? StawkaVatSprzedazy
        {
            get
            { return item.StawkaVatSprzedazy; }
            set
            {
                item.StawkaVatSprzedazy = value;
                OnPropertyChanged(() => StawkaVatSprzedazy);
            }
        }

        public decimal? Cena
        {
            get
            { return item.Cena; }
            set
            {
                item.Cena = value;
                OnPropertyChanged(() => Cena);
            }
        }

        public decimal? Marza
        {
            get
            { 
                return item.Marza; 
            }
            set
            {
                item.Marza = value;
                OnPropertyChanged(() => Marza);
            }
        }
        #endregion

        public override void Save()
        {
            przychodniaEntities.Towar.Add(item); // stage
            przychodniaEntities.SaveChanges(); // push
        }
    }
}
