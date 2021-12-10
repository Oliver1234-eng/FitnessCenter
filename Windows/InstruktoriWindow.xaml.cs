﻿using SR12_2020_POP2021.Model;
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
    /// Interaction logic for InstruktoriWindow.xaml
    /// </summary>
    public partial class InstruktoriWindow : Window
    {
        public InstruktoriWindow()
        {
            InitializeComponent();

            UpdateView();
        }

        private void UpdateView()
        {
            dgInstruktori.ItemsSource = null;
            dgInstruktori.ItemsSource = Podaci.Instanca.Instruktori;
            dgInstruktori.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgInstruktori_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //if (e.PropertyName.Equals("Aktivan"))
            //{
            //e.Column.Visibility = Visibility.Collapsed;
            //}
        }

        private void miDodajInstruktora_Click(object sender, RoutedEventArgs e)
        {
            DodajIzmeniInstruktoraProzor dodajIzmeniInstruktoraProzor = new DodajIzmeniInstruktoraProzor(null); //rezim dodavanja

            this.Hide();
            if ((bool)dodajIzmeniInstruktoraProzor.ShowDialog())
            {
                UpdateView();
            }
            this.Show();
        }

        private void miIzmeniInstruktora_Click(object sender, RoutedEventArgs e)
        {
            Instruktor stariInstruktor = (Instruktor)dgInstruktori.SelectedItem;
            DodajIzmeniInstruktoraProzor dodajIzmeniInstruktoraProzor = new DodajIzmeniInstruktoraProzor(stariInstruktor, EStatus.IZMENI);

            this.Hide();
            if (!(bool)dodajIzmeniInstruktoraProzor.ShowDialog())
            {
                //cancel kliknuto
            }

            this.Show();
        }

        private void miIzbrisiInstruktora_Click(object sender, RoutedEventArgs e)
        {
            Instruktor obrisiInstruktor = (Instruktor)dgInstruktori.SelectedItem;
            Podaci.Instanca.ObrisiInstruktora(obrisiInstruktor.Korisnik.JMBG);

            int index = Podaci.Instanca.Korisnici.ToList().FindIndex(i => i.JMBG.Equals(obrisiInstruktor.Korisnik.JMBG));
            Podaci.Instanca.Korisnici[index].Aktivan = false;

            Podaci.Instanca.SacuvajEntitete("korisnici.txt");
            Podaci.Instanca.SacuvajEntitete("instruktori.txt");

            UpdateView();
        }
    }
}