﻿using System;
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

namespace SR12_2020_POP2021.Windows
{
    /// <summary>
    /// Interaction logic for HomeWindowZaPolaznika.xaml
    /// </summary>
    public partial class HomeWindowZaPolaznika : Window
    {
        public HomeWindowZaPolaznika()
        {
            InitializeComponent();
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();
        }

        private void btnPregledLicnihPodataka_Click(object sender, RoutedEventArgs e)
        {
            PregledLicnihPodatakaPolaznikWindow pregledLicnihPodatakaPolaznikWindow = new PregledLicnihPodatakaPolaznikWindow();
            this.Hide();
            pregledLicnihPodatakaPolaznikWindow.Show();
        }

        private void btnRezervacijaTreninga_Click(object sender, RoutedEventArgs e)
        {
            RezervacijaTreningaPolaznikWindow rezervacijaTreningaPolaznikWindow = new RezervacijaTreningaPolaznikWindow();
            this.Hide();
            rezervacijaTreningaPolaznikWindow.Show();
        }

        private void btnOtkaziTrening_Click(object sender, RoutedEventArgs e)
        {
            OtkazivanjeTreningaPolaznikWindow otkazivanjeTreningaPolaznikWindow = new OtkazivanjeTreningaPolaznikWindow();
            this.Hide();
            otkazivanjeTreningaPolaznikWindow.Show();
        }

        private void btnInstruktorMika_Click(object sender, RoutedEventArgs e)
        {
            TreninziInstruktorMikaPolaznikWindow treninziInstruktorMikaPolaznikWindow = new TreninziInstruktorMikaPolaznikWindow();
            this.Hide();
            treninziInstruktorMikaPolaznikWindow.Show();
        }

        private void btnInstruktorIns2_Click(object sender, RoutedEventArgs e)
        {
            TreninziInstruktorIns2PolaznikWindow treninziInstruktorIns2PolaznikWindow = new TreninziInstruktorIns2PolaznikWindow();
            this.Hide();
            treninziInstruktorIns2PolaznikWindow.Show();
        }

        private void btnInstruktorIns3_Click(object sender, RoutedEventArgs e)
        {
            TreninziInstruktorIns3PolaznikWindow treninziInstruktorIns3PolaznikWindow = new TreninziInstruktorIns3PolaznikWindow();
            this.Hide();
            treninziInstruktorIns3PolaznikWindow.Show();
        }

        private void btnPregledSvojihTreninga_Click(object sender, RoutedEventArgs e)
        {
            PregledSvojihTreningaPolaznikWindow pregledSvojihTreningaPolaznikWindow = new PregledSvojihTreningaPolaznikWindow();
            this.Hide();
            pregledSvojihTreningaPolaznikWindow.Show();
        }
    }
}
