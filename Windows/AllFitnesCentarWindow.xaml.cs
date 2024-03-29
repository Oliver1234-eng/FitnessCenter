﻿using SR12_2020_POP2021.Model;
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
    /// Interaction logic for AllFitnesCentarWindow.xaml
    /// </summary>
    public partial class AllFitnesCentarWindow : Window
    {
        ICollectionView view;
        public AllFitnesCentarWindow()
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

        private void IzmenaPodataka_Click(object sender, RoutedEventArgs e)
        {
            FitnesCentar selectedFitnesCentar = view.CurrentItem as FitnesCentar;

            FitnesCentar stariFitnesCentar = selectedFitnesCentar.Clone();

            AddEditFitnesCentar addEditFitnesCentar = new AddEditFitnesCentar(selectedFitnesCentar, EStatus.IZMENI);
            this.Hide();
            if (!(bool)addEditFitnesCentar.ShowDialog())
            {
                int index = Util.Instance.FitnesCentri.ToList().FindIndex(f => f.Sifra.Equals(stariFitnesCentar.Sifra));
                Util.Instance.FitnesCentri[index] = stariFitnesCentar;
            }
            this.Show();

            view.Refresh();
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
            HomeWindowZaAdministratora homeWindowAdministrator = new HomeWindowZaAdministratora();
            this.Hide();
            homeWindowAdministrator.Show();
        }

    }
}
