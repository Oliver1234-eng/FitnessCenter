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
    /// Interaction logic for FitnesCentarPodaciZaNeregistrovanogKorisnika.xaml
    /// </summary>
    public partial class FitnesCentarPodaciZaNeregistrovanogKorisnika : Window
    {
        ICollectionView view;
        public FitnesCentarPodaciZaNeregistrovanogKorisnika()
        {
            InitializeComponent();
            UpdateView();

        }

        private void UpdateView()
        {
            DGFitnesCentar.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Util.Instance.FitnesCentri);
            DGFitnesCentar.ItemsSource = view;
            DGFitnesCentar.IsSynchronizedWithCurrentItem = true;

            DGFitnesCentar.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DGFitnesCentar.SelectedItems.Clear();
        }

        private void DGFitnesCentar_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Aktivan") || e.PropertyName.Equals("Error"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeWindowNeregistrovaniKorisnik homeWindowNeregistrovaniKorisnik = new HomeWindowNeregistrovaniKorisnik();
            this.Hide();
            homeWindowNeregistrovaniKorisnik.Show();
        }
    }
}
