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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindowAdministrator loginWindowAdministrator = new LoginWindowAdministrator();
            this.Hide();
            loginWindowAdministrator.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindowInstruktor loginWindowInstruktor = new LoginWindowInstruktor();
            this.Hide();
            loginWindowInstruktor.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoginWindowPolaznik loginWindowPolaznik = new LoginWindowPolaznik();
            this.Hide();
            loginWindowPolaznik.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            this.Hide();
            homeWindow.Show();
        }
    }
}
