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
    /// Interaction logic for DodajIzmeniInstruktoraProzor.xaml
    /// </summary>
    public partial class DodajIzmeniInstruktoraProzor : Window
    {
        private Instruktor odabraniInstruktor;
        private EStatus odabraniStatus;
        public DodajIzmeniInstruktoraProzor(Instruktor instruktor, EStatus eStatus = EStatus.DODAJ)
        {
            InitializeComponent();

            odabraniInstruktor = instruktor;
            odabraniStatus = eStatus;

            if (odabraniStatus.Equals(EStatus.IZMENI))
            {
                this.Title = "Izmeni instruktora";

                if (eStatus.Equals(EStatus.IZMENI) && instruktor != null)
                {
                    txtIme.Text = instruktor.Korisnik.Ime;
                    txtPrezime.Text = instruktor.Korisnik.Prezime;
                    txtEmail.Text = instruktor.Korisnik.Email;
                    txtLozinka.Text = instruktor.Korisnik.Lozinka;
                    txtAdresa.Text = instruktor.Korisnik.Adresa;
                    txtJMBG.Text = instruktor.Korisnik.JMBG;
                    txtJMBG.IsEnabled = false;
                }
            }

            else
            {
                this.Title = "Dodaj instruktora";
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

            Instruktor instruktor = new Instruktor
            {
                //Ime = txtIme.Text,
                //Prezime = txtPrezime.Text,
                //JMBG = txtJMBG.Text,
                //Email = txtEmail.Text,
                //Aktivan = true,
                //Lozinka = txtIme.Text,
                //TipKorisnika = tip,
                Trening = "aaa",
                Korisnik = k
            };

            if (odabraniStatus.Equals(EStatus.DODAJ))
            {
                Podaci.Instanca.Korisnici.Add(k);
                Podaci.Instanca.Instruktori.Add(instruktor);
            }

            else
            {
                int izmenaInstruktora = Podaci.Instanca.Instruktori.ToList().FindIndex(i => i.Korisnik.JMBG.Equals(txtJMBG.Text));
                int izmenaKorisnika = Podaci.Instanca.Korisnici.ToList().FindIndex(i => i.JMBG.Equals(txtJMBG.Text));

                Podaci.Instanca.Korisnici[izmenaKorisnika] = k;
                Podaci.Instanca.Instruktori[izmenaInstruktora] = instruktor;
            }

            Podaci.Instanca.SacuvajEntitete("korisnici.txt");
            Podaci.Instanca.SacuvajEntitete("instruktori.txt");
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
