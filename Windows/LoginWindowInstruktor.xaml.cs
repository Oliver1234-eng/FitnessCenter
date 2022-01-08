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
    /// Interaction logic for LoginWindowInstruktor.xaml
    /// </summary>
    public partial class LoginWindowInstruktor : Window
    {
        public LoginWindowInstruktor()
        {
            InitializeComponent();
        }

        string[] usernames = { "111111", "777888", "777667" };
        string[] passwords = { "zika", "ins1234", "ins888" };

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (usernames.Contains(txtJMBG.Text) && passwords.Contains(txtLozinka.Password) && Array.IndexOf(usernames, txtJMBG.Text) ==
                Array.IndexOf(passwords, txtLozinka.Password))
            {
                HomeWindowZaInstruktora homeWindowZaInstruktora = new HomeWindowZaInstruktora();
                this.Hide();
                homeWindowZaInstruktora.Show();
            }
            else
            {
                MessageBox.Show("JMBG i/ili lozinka nisu tacni!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();
        }
    }
}
