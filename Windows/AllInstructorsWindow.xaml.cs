using SR12_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AllInstructorsWindow.xaml
    /// </summary>
    public partial class AllInstructorsWindow : Window
    {
        ICollectionView view;

        public AllInstructorsWindow()
        {
            InitializeComponent();
            UpdateView();
            view.Filter = CustomFilter;

        }

        private bool CustomFilter(object obj)
        {
            RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;
            //RegistrovaniKorisnik korisnik1 = (RegistrovaniKorisnik)obj ;

            if (korisnik.TipKorisnika.Equals(ETipKorisnika.INSTRUKTOR) && korisnik.Aktivan)
            {
                if (txtPretraga.Text != "")
                {
                    return korisnik.Ime.Contains(txtPretraga.Text);
                }
                if (txtPretragaPrezime.Text != "")
                {
                    return korisnik.Prezime.Contains(txtPretragaPrezime.Text);
                }

                else
                    return true;
            }
            return false;
        }

        private void UpdateView()
        {
            DGInstruktori.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Util.Instance.Korisnici);
            DGInstruktori.ItemsSource = view;
            DGInstruktori.IsSynchronizedWithCurrentItem = true;

            DGInstruktori.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DGInstruktori.SelectedItems.Clear();
        }

        private void DodavanjeInstruktora_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik noviKorisnik = new RegistrovaniKorisnik();
            AddEditInstructors addEditInstructors = new AddEditInstructors(noviKorisnik);
            this.Hide();
            if (!(bool)addEditInstructors.ShowDialog())
            {

            }
            this.Show();
        }

        private void IzmenaInstruktora_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik selectedInstruktor = view.CurrentItem as RegistrovaniKorisnik;

            RegistrovaniKorisnik stariInstruktor = selectedInstruktor.Clone();

            AddEditInstructors addEditInstructors = new AddEditInstructors(selectedInstruktor, EStatus.IZMENI);
            this.Hide();
            if (!(bool)addEditInstructors.ShowDialog())
            {
                int index = Util.Instance.Korisnici.ToList().FindIndex(k => k.Email.Equals(stariInstruktor.Email));
                Util.Instance.Korisnici[index] = stariInstruktor;
            }
            this.Show();

            view.Refresh();
            DGInstruktori.SelectedItems.Clear();

        }

        private void BrisanjeInstruktora_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik instruktorZaBrisanje = view.CurrentItem as RegistrovaniKorisnik;
            Util.Instance.DeleteUser(instruktorZaBrisanje.Email);

            int index = Util.Instance.Korisnici.ToList().FindIndex(korisnik => korisnik.Email.Equals(instruktorZaBrisanje.Email));
            Util.Instance.Korisnici[index].Aktivan = false;


            UpdateView();
            view.Refresh();
        }

        private void DGInstruktori_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Aktivan") || e.PropertyName.Equals("Error"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void txtPretraga_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void txtPretragaPrezime_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
