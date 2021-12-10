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
    /// Interaction logic for AdministratoriWindow.xaml
    /// </summary>
    public partial class AdministratoriWindow : Window
    {
        public AdministratoriWindow()
        {
            InitializeComponent();

            UpdateView();
        }

        private void UpdateView()
        {
            dgAdministratori.ItemsSource = null;
            dgAdministratori.ItemsSource = Podaci.Instanca.Administratori;
            dgAdministratori.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgAdministratori_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //if (e.PropertyName.Equals("Aktivan"))
            //{
            //e.Column.Visibility = Visibility.Collapsed;
            //}
        }

        private void miDodajAdministratora_Click(object sender, RoutedEventArgs e)
        {
            DodajIzmeniAdministratoraProzor dodajIzmeniAdministratoraProzor = new DodajIzmeniAdministratoraProzor(null); //rezim dodavanja

            this.Hide();
            if ((bool)dodajIzmeniAdministratoraProzor.ShowDialog())
            {
                UpdateView();
            }
            this.Show();
        }

        private void miIzmeniAdministratora_Click(object sender, RoutedEventArgs e)
        {
            Administrator stariAdministrator = (Administrator)dgAdministratori.SelectedItem;
            DodajIzmeniAdministratoraProzor dodajIzmeniAdministratoraProzor = new DodajIzmeniAdministratoraProzor(stariAdministrator, EStatus.IZMENI);

            this.Hide();
            if (!(bool)dodajIzmeniAdministratoraProzor.ShowDialog())
            {
                //cancel kliknuto
            }

            this.Show();
        }

        private void miIzbrisiAdministratora_Click(object sender, RoutedEventArgs e)
        {
            Administrator obrisiAdministrator = (Administrator)dgAdministratori.SelectedItem;
            Podaci.Instanca.ObrisiAdministratora(obrisiAdministrator.Korisnik.JMBG);

            int index = Podaci.Instanca.Korisnici.ToList().FindIndex(a => a.JMBG.Equals(obrisiAdministrator.Korisnik.JMBG));
            Podaci.Instanca.Korisnici[index].Aktivan = false;

            Podaci.Instanca.SacuvajEntitete("korisnici.txt");
            Podaci.Instanca.SacuvajEntitete("administratori.txt");

            UpdateView();
        }
    }
}
