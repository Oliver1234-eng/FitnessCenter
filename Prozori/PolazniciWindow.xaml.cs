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
    /// Interaction logic for PolazniciWindow.xaml
    /// </summary>
    public partial class PolazniciWindow : Window
    {
        public PolazniciWindow()
        {
            InitializeComponent();

            UpdateView();
        }

        private void UpdateView()
        {
            dgPolaznici.ItemsSource = null;
            dgPolaznici.ItemsSource = Podaci.Instanca.Polaznici;
            dgPolaznici.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgPolaznici_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //if (e.PropertyName.Equals("Aktivan"))
            //{
            //e.Column.Visibility = Visibility.Collapsed;
            //}
        }

        private void miDodajPolaznika_Click(object sender, RoutedEventArgs e)
        {
            DodajIzmeniPolaznikaProzor dodajIzmeniPolaznikaProzor = new DodajIzmeniPolaznikaProzor(null); //rezim dodavanja

            this.Hide();
            if ((bool)dodajIzmeniPolaznikaProzor.ShowDialog())
            {
                UpdateView();
            }
            this.Show();
        }

        private void miIzmeniPolaznika_Click(object sender, RoutedEventArgs e)
        {
            Polaznik stariPolaznik = (Polaznik)dgPolaznici.SelectedItem;
            DodajIzmeniPolaznikaProzor dodajIzmeniPolaznikaProzor = new DodajIzmeniPolaznikaProzor(stariPolaznik, EStatus.IZMENI);

            this.Hide();
            if (!(bool)dodajIzmeniPolaznikaProzor.ShowDialog())
            {
                //cancel kliknuto
            }

            this.Show();
        }

        private void miIzbrisiPolaznika_Click(object sender, RoutedEventArgs e)
        {
            Polaznik obrisiPolaznik = (Polaznik)dgPolaznici.SelectedItem;
            Podaci.Instanca.ObrisiPolaznika(obrisiPolaznik.Korisnik.JMBG);

            int index = Podaci.Instanca.Korisnici.ToList().FindIndex(i => i.JMBG.Equals(obrisiPolaznik.Korisnik.JMBG));
            Podaci.Instanca.Korisnici[index].Aktivan = false;

            Podaci.Instanca.SacuvajEntitete("korisnici.txt");
            Podaci.Instanca.SacuvajEntitete("polaznici.txt");

            UpdateView();
        }
    }
}
