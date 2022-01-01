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
    /// Interaction logic for LoginWindowAdministrator.xaml
    /// </summary>
    public partial class LoginWindowAdministrator : Window
    {
        public LoginWindowAdministrator()
        {
            InitializeComponent();
        }

        string[] usernames = {"222222"};
        string[] passwords = { "peki" };

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (usernames.Contains(txtJMBG.Text) && passwords.Contains(txtLozinka.Text) && Array.IndexOf(usernames, txtJMBG.Text) ==
                Array.IndexOf(passwords, txtLozinka.Text))
            {
                HomeWindowZaAdministratora homeWindowZaAdministratora = new HomeWindowZaAdministratora();
                this.Hide();
                homeWindowZaAdministratora.Show();
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
