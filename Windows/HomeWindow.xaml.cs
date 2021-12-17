using SR12_2020_POP2021.Model;
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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();

            Util.Instance.CitanjeEntiteta("korisnici.txt");
            Util.Instance.CitanjeEntiteta("instruktori.txt");
            Util.Instance.CitanjeEntiteta("polaznici.txt");
            Util.Instance.CitanjeEntiteta("administratori.txt");
            Util.Instance.CitanjeEntiteta("treninzi.txt");
            Util.Instance.CitanjeEntiteta("fitnesCentri.txt");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HomeWindowNeregistrovaniKorisnik homeWindowNeregistrovaniKorisnik = new HomeWindowNeregistrovaniKorisnik();
            this.Hide();
            homeWindowNeregistrovaniKorisnik.Show();
        }
    }
}
