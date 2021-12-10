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
    /// Interaction logic for TreninziWindow.xaml
    /// </summary>
    public partial class TreninziWindow : Window
    {
        public TreninziWindow()
        {
            InitializeComponent();

            UpdateView();
        }

        private void UpdateView()
        {
            dgTreninzi.ItemsSource = null;
            dgTreninzi.ItemsSource = Podaci.Instanca.Treninzi;
            dgTreninzi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgTreninzi_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //if (e.PropertyName.Equals("Aktivan"))
            //{
            //e.Column.Visibility = Visibility.Collapsed;
            //}
        }

        private void miDodajTrening_Click(object sender, RoutedEventArgs e)
        {
            DodajIzmeniTreningProzor dodajIzmeniTreningProzor = new DodajIzmeniTreningProzor(null); //rezim dodavanja

            this.Hide();
            if ((bool)dodajIzmeniTreningProzor.ShowDialog())
            {
                UpdateView();
            }
            this.Show();
        }

        private void miIzmeniTrening_Click(object sender, RoutedEventArgs e)
        {
            Trening stariTrening = (Trening)dgTreninzi.SelectedItem;
            DodajIzmeniTreningProzor dodajIzmeniTreningProzor = new DodajIzmeniTreningProzor(stariTrening, EStatus.IZMENI);

            this.Hide();
            if (!(bool)dodajIzmeniTreningProzor.ShowDialog())
            {
                //cancel kliknuto
            }

            this.Show();
        }

        private void miIzbrisiTrening_Click(object sender, RoutedEventArgs e)
        {
            Trening obrisiTrening = (Trening)dgTreninzi.SelectedItem;
            Podaci.Instanca.ObrisiTrening(obrisiTrening.Sifra);

            int index = Podaci.Instanca.Treninzi.ToList().FindIndex(t => t.Sifra.Equals(obrisiTrening.Sifra));
            Podaci.Instanca.Treninzi[index].Aktivan = false;

            Podaci.Instanca.SacuvajEntitete("treninzi.txt");

            UpdateView();
        }
    }
}
