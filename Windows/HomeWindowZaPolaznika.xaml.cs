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

    }
}
