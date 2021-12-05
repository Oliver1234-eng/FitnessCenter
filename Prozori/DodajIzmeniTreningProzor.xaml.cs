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
    /// Interaction logic for DodajIzmeniTreningProzor.xaml
    /// </summary>
    public partial class DodajIzmeniTreningProzor : Window
    {
        private Trening odabraniTrening;
        private EStatus odabraniStatus;
        public DodajIzmeniTreningProzor(Trening trening, EStatus eStatus = EStatus.DODAJ)
        {
            InitializeComponent();

            odabraniTrening = trening;
            odabraniStatus = eStatus;

            if (odabraniStatus.Equals(EStatus.IZMENI))
            {
                this.Title = "Izmeni trening";

                if (eStatus.Equals(EStatus.IZMENI) && trening != null)
                {
                    txtSifra.Text = trening.Sifra;
                    txtDatum.Text = trening.Datum;
                    txtVremePocetka.Text = trening.VremePocetka;
                    txtTrajanje.Text = trening.Trajanje;
                    txtImeInstruktora.Text = trening.Instruktor.Korisnik.Ime;
                    txtImePolaznika.Text = trening.Polaznik.Korisnik.Ime;
                    txtSifra.IsEnabled = false;
                }
            }

            else
            {
                this.Title = "Dodaj trening";
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            ComboBoxItem selektovaniItemStatusTreninga = (ComboBoxItem)cmbStatusTreninga.SelectedItem;
            string valueStatusTreninga = selektovaniItemStatusTreninga.Content.ToString();
            Enum.TryParse(valueStatusTreninga, out EStatusTreninga status);
            Instruktor instruktor = Podaci.Instanca.Instruktori.Find(i => i.Korisnik.Ime.Equals(txtImeInstruktora.Text));
            Polaznik polaznik = Podaci.Instanca.Polaznici.Find(p => p.Korisnik.Ime.Equals(txtImePolaznika.Text));

            Trening t = new Trening
            {
                Sifra = txtSifra.Text,
                Datum = txtDatum.Text,
                VremePocetka = txtVremePocetka.Text,
                Trajanje = txtTrajanje.Text,
                StatusTreninga = status,
                Instruktor = instruktor,
                Polaznik = polaznik,
                Aktivan = true
            };


            if (odabraniStatus.Equals(EStatus.DODAJ))
            {
                Podaci.Instanca.Treninzi.Add(t);
            }

            else
            {
                int izmenaTreninga = Podaci.Instanca.Treninzi.ToList().FindIndex(tr => tr.Sifra.Equals(txtSifra.Text));

                Podaci.Instanca.Treninzi[izmenaTreninga] = t;
            }

            Podaci.Instanca.SacuvajEntitete("treninzi.txt");
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
