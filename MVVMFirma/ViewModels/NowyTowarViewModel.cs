using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Validators;

namespace MVVMFirma.ViewModels
{
    public class NowyTowarViewModel : JedenViewModel<Towar>, IDataErrorInfo
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

        #region Validation
        public String Error
        {
            get
            {
                return null;
            }

        }

        public String this[string name] 
        { 
            get
            {
                string komunikat = null;

                if (name == "Nazwa")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwa);
                }

                if (name == "Kod")
                {
                    komunikat = StringValidator.SprawdzKod(this.Kod);
                }

                if (name == "Cena")
                {
                    komunikat = BiznesValidator.SprawdzCena(this.Cena);
                }

                if (name == "Marza")
                {
                    komunikat = BiznesValidator.SprawdzCena(this.Marza);
                }

                if (name == "StawkaVatZakupu")
                {
                    komunikat = BiznesValidator.SprawdzVAT(this.StawkaVatZakupu);
                }

                if (name == "StawkaVatSprzedazy")
                {
                    komunikat = BiznesValidator.SprawdzVAT(this.StawkaVatSprzedazy);
                }

                return komunikat;
            }
        }


        // funckja sprawdza, czy rekord mozna zapisac w bazie
        public override bool IsValid()
        {
            return (this["Marza"] == null && 
                    this["Cena"] == null && 
                    this["Nazwa"] == null && 
                    this["StawkaVatSprzedazy"] == null && 
                    this["StawkaVatZakupu"] == null &&
                    this["Kod"] == null
               );
        }
        #endregion
    }
}
