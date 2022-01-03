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
    /// Interaction logic for PregledLicnihPodatakaPolaznikWindow.xaml
    /// </summary>
    public partial class PregledLicnihPodatakaPolaznikWindow : Window
    {
        ICollectionView view;
        public PregledLicnihPodatakaPolaznikWindow()
        {
            InitializeComponent();
            UpdateView();
            view.Filter = CustomFilter;
        }

        private bool CustomFilter(object obj)
        {
            RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;
            //RegistrovaniKorisnik korisnik1 = (RegistrovaniKorisnik)obj ;

            if (korisnik.TipKorisnika.Equals(ETipKorisnika.POLAZNIK) && korisnik.Aktivan)
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
            DGPolaznici.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Util.Instance.Korisnici);
            DGPolaznici.ItemsSource = view;
            DGPolaznici.IsSynchronizedWithCurrentItem = true;

            DGPolaznici.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DGPolaznici.SelectedItems.Clear();
        }

        /*private void DodavanjePolaznika_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik noviKorisnik = new RegistrovaniKorisnik();
            AddEditPolaznici addEditPolaznici = new AddEditPolaznici(noviKorisnik);
            this.Hide();
            if (!(bool)addEditPolaznici.ShowDialog())
            {

            }
            this.Show();
        }*/

        private void IzmenaPolaznika_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik selectedPolaznik = view.CurrentItem as RegistrovaniKorisnik;

            RegistrovaniKorisnik stariPolaznik = selectedPolaznik.Clone();

            AddEditPolaznici addEditPolaznici = new AddEditPolaznici(selectedPolaznik, EStatus.IZMENI);
            this.Hide();
            if (!(bool)addEditPolaznici.ShowDialog())
            {
                int index = Util.Instance.Korisnici.ToList().FindIndex(k => k.Email.Equals(stariPolaznik.Email));
                Util.Instance.Korisnici[index] = stariPolaznik;
            }
            this.Show();

            view.Refresh();
            DGPolaznici.SelectedItems.Clear();

        }

        private void DGPolaznici_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
            HomeWindowZaAdministratora homeWindowZaAdministratora = new HomeWindowZaAdministratora();
            this.Hide();
            homeWindowZaAdministratora.Show();
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
