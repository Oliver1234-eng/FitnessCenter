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
    /// Interaction logic for AllTreninziWindow.xaml
    /// </summary>
    public partial class AllTreninziWindow : Window
    {
        ICollectionView view;

        public AllTreninziWindow()
        {
            InitializeComponent();
            UpdateView();
            view.Filter = CustomFilter;

        }

        private bool CustomFilter(object obj)
        {
            Trening trening = obj as Trening;
            //RegistrovaniKorisnik korisnik1 = (RegistrovaniKorisnik)obj ;

            if (trening.Aktivan)
            {
                if (txtPretraga.Text != "")
                {
                    return trening.Sifra.Contains(txtPretraga.Text);
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

        private void DodavanjeTreninga_Click(object sender, RoutedEventArgs e)
        {
            Trening noviTrening = new Trening();
            AddEditTreninzi addEditTreninzi = new AddEditTreninzi(noviTrening);
            this.Hide();
            if (!(bool)addEditTreninzi.ShowDialog())
            {

            }
            this.Show();
        }

        private void IzmenaTreninga_Click(object sender, RoutedEventArgs e)
        {
            Trening selectedTrening = view.CurrentItem as Trening;

            Trening stariTrening = selectedTrening.Clone();

            AddEditTreninzi addEditTreninzi = new AddEditTreninzi(selectedTrening, EStatus.IZMENI);
            this.Hide();
            if (!(bool)addEditTreninzi.ShowDialog())
            {
                int index = Util.Instance.Treninzi.ToList().FindIndex(t => t.Sifra.Equals(stariTrening.Sifra));
                Util.Instance.Treninzi[index] = stariTrening;
            }
            this.Show();

            view.Refresh();
            DGTreninzi.SelectedItems.Clear();

        }

        private void BrisanjeTreninga_Click(object sender, RoutedEventArgs e)
        {
            Trening treningZaBrisanje = view.CurrentItem as Trening;
            Util.Instance.DeleteWorkout(treningZaBrisanje.Sifra);

            int index = Util.Instance.Treninzi.ToList().FindIndex(trening => trening.Sifra.Equals(treningZaBrisanje.Sifra));
            Util.Instance.Treninzi[index].Aktivan = false;


            UpdateView();
            view.Refresh();
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

    }
}
