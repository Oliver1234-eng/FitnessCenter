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
            }
            else
            {
                this.Title = "Dodaj instruktora";
            }
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            ComboBoxItem selektovaniItem = (ComboBoxItem)cmbTipKorisnika.SelectedItem;
            string value = selektovaniItem.Content.ToString();
            Enum.TryParse(value, out ETipKorisnika tip);
            Enum.TryParse(value, out EPol pol);

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

            Podaci.Instanca.Korisnici.Add(k);
            Podaci.Instanca.Instruktori.Add(instruktor);
            Podaci.Instanca.SacuvajEntitete("korisnici.txt");
            Podaci.Instanca.SacuvajEntitete("instruktori.txt");
            this.Close();
        }
    }
}
