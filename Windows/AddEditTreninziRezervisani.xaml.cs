using SR12_2020_POP2021.Model;
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
using System.Windows.Shapes;

namespace SR12_2020_POP2021.Windows
{
    /// <summary>
    /// Interaction logic for AddEditTreninziRezervisani.xaml
    /// </summary>
    public partial class AddEditTreninziRezervisani : Window
    {
        private EStatus odabraniStatus;
        private Trening odabraniTrening;

        public AddEditTreninziRezervisani(Trening trening, EStatus status = EStatus.DODAJ)
        {
            InitializeComponent();


            this.DataContext = trening;
            ComboStatusTreninga.ItemsSource = Enum.GetValues(typeof(EStatusTreninga)).Cast<EStatusTreninga>();
            ComboInstruktor.ItemsSource = Enum.GetValues(typeof(EImenaInstruktora)).Cast<EImenaInstruktora>();
            ComboPolaznik.ItemsSource = Enum.GetValues(typeof(EImenaPolaznika)).Cast<EImenaPolaznika>();


            odabraniTrening = trening;
            odabraniStatus = status;

            if (status.Equals(EStatus.IZMENI) && trening != null)
            {
                this.Title = "Izmeni treninga";

            }
            else
            {
                this.Title = "Dodaj trening";
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                if (odabraniStatus.Equals(EStatus.DODAJ))
                {
                    odabraniTrening.Aktivan = true;
                    Trening trening = new Trening
                    {

                        //Trening = odabraniTrening
                    };
                    Util.Instance.Treninzi.Add(odabraniTrening);
                }

                Util.Instance.SacuvajEntitet("treninzi.txt");

                this.DialogResult = true;
                this.Close();
            }
        }

        private bool IsValid()
        {
            return !Validation.GetHasError(txtSifra) && !Validation.GetHasError(txtDatum) && !Validation.GetHasError(txtVremePocetka)
                && !Validation.GetHasError(txtTrajanje);
        }
    }
}
