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
    /// Interaction logic for TreninziInstruktorIns3PolaznikWindow.xaml
    /// </summary>
    public partial class TreninziInstruktorIns3PolaznikWindow : Window
    {
        ICollectionView view;

        public TreninziInstruktorIns3PolaznikWindow()
        {
            InitializeComponent();
            UpdateView();
            view.Filter = CustomFilter;

        }

        private bool CustomFilter(object obj)
        {
            Trening trening = obj as Trening;
            //RegistrovaniKorisnik korisnik1 = (RegistrovaniKorisnik)obj ;

            if (trening.Aktivan && trening.Instruktor.Equals(EImenaInstruktora.ins3))
            {
                if (txtPretraga.Text != "")
                {
                    return trening.Datum.Contains(txtPretraga.Text);
                }

                if (txtPretragaSifra.Text != "")
                {
                    return trening.Sifra.Contains(txtPretragaSifra.Text);
                }

                if (txtPretragaVremePocetka.Text != "")
                {
                    return trening.VremePocetka.Contains(txtPretragaVremePocetka.Text);
                }

                if (txtPretragaTrajanje.Text != "")
                {
                    return trening.Trajanje.Contains(txtPretragaTrajanje.Text);
                }

                else
                    return true;
            }
            return false;
        }

        private void UpdateView()
        {
            DGTreninzi.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Util.Instance.Treninzi);
            DGTreninzi.ItemsSource = view;
            DGTreninzi.IsSynchronizedWithCurrentItem = true;

            DGTreninzi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DGTreninzi.SelectedItems.Clear();
        }

        private void DGTreninzi_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeWindowZaPolaznika homeWindowZaPolaznika = new HomeWindowZaPolaznika();
            this.Hide();
            homeWindowZaPolaznika.Show();
        }

        private void txtPretragaSifra_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void txtPretragaVremePocetka_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void txtPretragaTrajanje_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
