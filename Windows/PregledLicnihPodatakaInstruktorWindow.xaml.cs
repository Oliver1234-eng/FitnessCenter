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
    /// Interaction logic for PregledLicnihPodatakaInstruktorWindow.xaml
    /// </summary>
    public partial class PregledLicnihPodatakaInstruktorWindow : Window
    {
        ICollectionView view;

        public PregledLicnihPodatakaInstruktorWindow()
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

                if (txtPretragaEmail.Text != "")
                {
                    return korisnik.Email.Contains(txtPretragaEmail.Text);
                }

                if (txtPretragaIdAdrese.Text != "")
                {
                    return korisnik.Sifra.Contains(txtPretragaIdAdrese.Text);
                }

                if (txtPretragaUlica.Text != "")
                {
                    return korisnik.Ulica.Contains(txtPretragaUlica.Text);
                }

                if (txtPretragaBroj.Text != "")
                {
                    return korisnik.Broj.Contains(txtPretragaBroj.Text);
                }

                if (txtPretragaGrad.Text != "")
                {
                    return korisnik.Grad.Contains(txtPretragaGrad.Text);
                }

                if (txtPretragaDrzava.Text != "")
                {
                    return korisnik.Drzava.Contains(txtPretragaDrzava.Text);
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

        /*private void DodavanjeInstruktora_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik noviKorisnik = new RegistrovaniKorisnik();
            AddEditInstructors addEditInstructors = new AddEditInstructors(noviKorisnik);
            this.Hide();
            if (!(bool)addEditInstructors.ShowDialog())
            {

            }
            this.Show();
        }*/

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

        private void txtPretragaEmail_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void txtPretragaIdAdrese_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void txtPretragaUlica_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void txtPretragaBroj_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeWindowZaInstruktora homeWindowZaInstruktora = new HomeWindowZaInstruktora();
            this.Hide();
            homeWindowZaInstruktora.Show();

        }

        private void txtPretragaGrad_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void txtPretragaDrzava_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
