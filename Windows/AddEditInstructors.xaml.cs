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
    /// Interaction logic for AddEditInstructors.xaml
    /// </summary>
    public partial class AddEditInstructors : Window
    {
        private EStatus odabraniStatus;
        private RegistrovaniKorisnik odabraniInstruktor;

        public AddEditInstructors(RegistrovaniKorisnik instruktor, EStatus status = EStatus.DODAJ)
        {
            InitializeComponent();


            this.DataContext = instruktor;
            ComboTipKorisnika.ItemsSource = Enum.GetValues(typeof(ETipKorisnika)).Cast<ETipKorisnika>();
            ComboPol.ItemsSource = Enum.GetValues(typeof(EPol)).Cast<EPol>();

            odabraniInstruktor = instruktor;
            odabraniStatus = status;

            if (status.Equals(EStatus.IZMENI) && instruktor != null)
            {
                this.Title = "Izmeni instruktora";

            }
            else
            {
                this.Title = "Dodaj Instruktora";
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
                    odabraniInstruktor.Aktivan = true;
                    Instruktor instruktor = new Instruktor
                    {

                        Korisnik = odabraniInstruktor
                    };
                    Util.Instance.Korisnici.Add(odabraniInstruktor);
                    Util.Instance.Instruktori.Add(instruktor);
                }

                Util.Instance.SacuvajEntitet("korisnici.txt");
                Util.Instance.SacuvajEntitet("instruktori.txt");

                this.DialogResult = true;
                this.Close();
            }

            //else
            //{
                //MessageBox.Show("Nesto nije u redu!");
            //}
        }

        private bool IsValid()
        {
            return !Validation.GetHasError(txtJmbg) && !Validation.GetHasError(txtEmail) && !Validation.GetHasError(txtIme)
                && !Validation.GetHasError(txtPrezime) && !Validation.GetHasError(txtLozinka) && !Validation.GetHasError(txtSifra)
                && !Validation.GetHasError(txtUlica) && !Validation.GetHasError(txtBroj) && !Validation.GetHasError(txtGrad)
                && !Validation.GetHasError(txtDrzava);
        }
    }
}
