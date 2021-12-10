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
    /// Interaction logic for DodajIzmeniPolaznikaProzor.xaml
    /// </summary>
    public partial class DodajIzmeniPolaznikaProzor : Window
    {
        private Polaznik odabraniPolaznik;
        private EStatus odabraniStatus;
        public DodajIzmeniPolaznikaProzor(Polaznik polaznik, EStatus eStatus = EStatus.DODAJ)
        {
            InitializeComponent();

            odabraniPolaznik = polaznik;
            odabraniStatus = eStatus;

            if (odabraniStatus.Equals(EStatus.IZMENI))
            {
                this.Title = "Izmeni polaznika";

                if (eStatus.Equals(EStatus.IZMENI) && polaznik != null)
                {
                    txtIme.Text = polaznik.Korisnik.Ime;
                    txtPrezime.Text = polaznik.Korisnik.Prezime;
                    txtEmail.Text = polaznik.Korisnik.Email;
                    txtLozinka.Text = polaznik.Korisnik.Lozinka;
                    txtAdresa.Text = polaznik.Korisnik.Adresa;
                    txtJMBG.Text = polaznik.Korisnik.JMBG;
                    txtJMBG.IsEnabled = false;
                }
            }

            else
            {
                this.Title = "Dodaj polaznika";
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

            Polaznik polaznik = new Polaznik
            {
                //Ime = txtIme.Text,
                //Prezime = txtPrezime.Text,
                //JMBG = txtJMBG.Text,
                //Email = txtEmail.Text,
                //Aktivan = true,
                //Lozinka = txtIme.Text,
                //TipKorisnika = tip,
                RezervisaniTrening = "aaa",
                Korisnik = k
            };

            if (odabraniStatus.Equals(EStatus.DODAJ))
            {
                Podaci.Instanca.Korisnici.Add(k);
                Podaci.Instanca.Polaznici.Add(polaznik);
            }

            else
            {
                int izmenaPolaznika = Podaci.Instanca.Polaznici.ToList().FindIndex(p => p.Korisnik.JMBG.Equals(txtJMBG.Text));
                int izmenaKorisnika = Podaci.Instanca.Korisnici.ToList().FindIndex(p => p.JMBG.Equals(txtJMBG.Text));

                Podaci.Instanca.Korisnici[izmenaKorisnika] = k;
                Podaci.Instanca.Polaznici[izmenaPolaznika] = polaznik;
            }

            Podaci.Instanca.SacuvajEntitete("korisnici.txt");
            Podaci.Instanca.SacuvajEntitete("polaznici.txt");
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
