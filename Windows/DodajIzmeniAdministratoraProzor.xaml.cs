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

namespace SR12_2020_POP2021.Prozori
{
    /// <summary>
    /// Interaction logic for DodajIzmeniAdministratoraProzor.xaml
    /// </summary>
    public partial class DodajIzmeniAdministratoraProzor : Window
    {
        private Administrator odabraniAdministrator;
        private EStatus odabraniStatus;
        public DodajIzmeniAdministratoraProzor(Administrator administrator, EStatus eStatus = EStatus.DODAJ)
        {
            InitializeComponent();

            odabraniAdministrator = administrator;
            odabraniStatus = eStatus;

            if (odabraniStatus.Equals(EStatus.IZMENI))
            {
                this.Title = "Izmeni administratora";

                if (eStatus.Equals(EStatus.IZMENI) && administrator != null)
                {
                    txtIme.Text = administrator.Korisnik.Ime;
                    txtPrezime.Text = administrator.Korisnik.Prezime;
                    txtEmail.Text = administrator.Korisnik.Email;
                    txtLozinka.Text = administrator.Korisnik.Lozinka;
                    txtAdresa.Text = administrator.Korisnik.Adresa;
                    txtJMBG.Text = administrator.Korisnik.JMBG;
                    txtJMBG.IsEnabled = false;
                }
            }

            else
            {
                this.Title = "Dodaj administratora";
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            ComboBoxItem selektovaniItemTipKorisnika = (ComboBoxItem)cmbTipKorisnika.SelectedItem;
            ComboBoxItem selektovaniItemPol = (ComboBoxItem)cmbPol.SelectedItem;
            string valueTipKorisnika = selektovaniItemTipKorisnika.Content.ToString();
            string valuePol = selektovaniItemPol.Content.ToString();
            Enum.TryParse(valueTipKorisnika, out ETipKorisnika tip);
            Enum.TryParse(valuePol, out EPol pol);

            Korisnik k = new Korisnik
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                JMBG = txtJMBG.Text,
                Email = txtEmail.Text,
                Lozinka = txtLozinka.Text,
                Pol = pol,
                Adresa = txtAdresa.Text,
                TipKorisnika = tip,
                Aktivan = true
            };

            Administrator administrator = new Administrator
            {
                //Ime = txtIme.Text,
                //Prezime = txtPrezime.Text,
                //JMBG = txtJMBG.Text,
                //Email = txtEmail.Text,
                //Aktivan = true,
                //Lozinka = txtIme.Text,
                //TipKorisnika = tip,
                Korisnik = k
            };

            if (odabraniStatus.Equals(EStatus.DODAJ))
            {
                Podaci.Instanca.Korisnici.Add(k);
                Podaci.Instanca.Administratori.Add(administrator);
            }

            else
            {
                int izmenaAdministratora = Podaci.Instanca.Administratori.ToList().FindIndex(a => a.Korisnik.JMBG.Equals(txtJMBG.Text));
                int izmenaKorisnika = Podaci.Instanca.Korisnici.ToList().FindIndex(a => a.JMBG.Equals(txtJMBG.Text));

                Podaci.Instanca.Korisnici[izmenaKorisnika] = k;
                Podaci.Instanca.Administratori[izmenaAdministratora] = administrator;
            }

            Podaci.Instanca.SacuvajEntitete("korisnici.txt");
            Podaci.Instanca.SacuvajEntitete("administratori.txt");
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
