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
    /// Interaction logic for AddEditAdministratori.xaml
    /// </summary>
    public partial class AddEditAdministratori : Window
    {
        private EStatus odabraniStatus;
        private RegistrovaniKorisnik odabraniAdministrator;

        public AddEditAdministratori(RegistrovaniKorisnik administrator, EStatus status = EStatus.DODAJ)
        {
            InitializeComponent();


            this.DataContext = administrator;
            ComboTipKorisnika.ItemsSource = Enum.GetValues(typeof(ETipKorisnika)).Cast<ETipKorisnika>();
            ComboPol.ItemsSource = Enum.GetValues(typeof(EPol)).Cast<EPol>();

            odabraniAdministrator = administrator;
            odabraniStatus = status;

            if (status.Equals(EStatus.IZMENI) && administrator != null)
            {
                this.Title = "Izmeni administratora";

            }
            else
            {
                this.Title = "Dodaj administratora";
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
                    odabraniAdministrator.Aktivan = true;
                    Administrator administrator = new Administrator
                    {

                        Korisnik = odabraniAdministrator
                    };
                    Util.Instance.Korisnici.Add(odabraniAdministrator);
                    Util.Instance.Administratori.Add(administrator);
                }

                Util.Instance.SacuvajEntitet("korisnici.txt");
                Util.Instance.SacuvajEntitet("administratori.txt");

                this.DialogResult = true;
                this.Close();
            }
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
