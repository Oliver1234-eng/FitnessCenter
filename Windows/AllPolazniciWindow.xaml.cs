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
    /// Interaction logic for AllPolazniciWindow.xaml
    /// </summary>
    public partial class AllPolazniciWindow : Window
    {
        ICollectionView view;
        public AllPolazniciWindow()
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

        private void DodavanjePolaznika_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik noviKorisnik = new RegistrovaniKorisnik();
            AddEditPolaznici addEditPolaznici = new AddEditPolaznici(noviKorisnik);
            this.Hide();
            if (!(bool)addEditPolaznici.ShowDialog())
            {

            }
            this.Show();
        }

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

        private void BrisanjePolaznika_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik polaznikZaBrisanje = view.CurrentItem as RegistrovaniKorisnik;
            Util.Instance.DeleteUser(polaznikZaBrisanje.Email);

            int index = Util.Instance.Korisnici.ToList().FindIndex(korisnik => korisnik.Email.Equals(polaznikZaBrisanje.Email));
            Util.Instance.Korisnici[index].Aktivan = false;


            UpdateView();
            view.Refresh();
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
    }
}