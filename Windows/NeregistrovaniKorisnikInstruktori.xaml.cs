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
    /// Interaction logic for NeregistrovaniKorisnikInstruktori.xaml
    /// </summary>
    public partial class NeregistrovaniKorisnikInstruktori : Window
    {
        ICollectionView view;

        public NeregistrovaniKorisnikInstruktori()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeWindowNeregistrovaniKorisnik homeWindowNeregistrovaniKorisnik = new HomeWindowNeregistrovaniKorisnik();
            this.Hide();
            homeWindowNeregistrovaniKorisnik.Show();
        }
    }
}
