using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Views
{
    /// <summary>
    /// Logika interakcji dla klasy WszystkiePlatnosciView.xaml
    /// </summary>
    public partial class WszystkiePlatnosciView : WszystkieViewBase
    {
        public WszystkiePlatnosciView()
        {
            InitializeComponent();
        }

        private void ObliczSume_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities db = new PrzychodniaEntities();
            int? sumaKwota = db.Platnosci.Sum(platnosc => platnosc.Kwota);
            
            SumaLabel.Content = sumaKwota.ToString();
        }
    }
}
