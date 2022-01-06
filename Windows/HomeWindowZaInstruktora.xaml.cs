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

namespace SR12_2020_POP2021.Windows
{
    /// <summary>
    /// Interaction logic for HomeWindowZaInstruktora.xaml
    /// </summary>
    public partial class HomeWindowZaInstruktora : Window
    {
        public HomeWindowZaInstruktora()
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
            PregledLicnihPodatakaInstruktorWindow pregledLicnihPodatakaInstruktorWindow = new PregledLicnihPodatakaInstruktorWindow();
            this.Hide();
            pregledLicnihPodatakaInstruktorWindow.Show();
        }

        private void btnPregledSvojihTreninga_Click(object sender, RoutedEventArgs e)
        {
            PregledSvojihTreningaInstruktorWindow pregledSvojihTreningaInstruktorWindow = new PregledSvojihTreningaInstruktorWindow();
            this.Hide();
            pregledSvojihTreningaInstruktorWindow.Show();
        }

        private void btnPregledSvojihTreningaRezervisanih_Click(object sender, RoutedEventArgs e)
        {
            PregledSvojihTreningaRezervisanihInstruktorWindow pregledSvojihTreningaRezervisanihInstruktorWindow = new PregledSvojihTreningaRezervisanihInstruktorWindow();
            this.Hide();
            pregledSvojihTreningaRezervisanihInstruktorWindow.Show();
        }

        private void btnPregledPolaznika_Click(object sender, RoutedEventArgs e)
        {
            PregledPolaznikaInstruktorWindow pregledPolaznikaInstruktorWindow = new PregledPolaznikaInstruktorWindow();
            this.Hide();
            pregledPolaznikaInstruktorWindow.Show();
        }
    }
}
