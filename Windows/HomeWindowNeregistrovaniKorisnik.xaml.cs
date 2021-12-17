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
    /// Interaction logic for HomeWindowNeregistrovaniKorisnik.xaml
    /// </summary>
    public partial class HomeWindowNeregistrovaniKorisnik : Window
    {
        public HomeWindowNeregistrovaniKorisnik()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistracijaNeregistrovanogKorisnikaWindow registracijaNeregistrovanogKorisnikaWindow = new RegistracijaNeregistrovanogKorisnikaWindow();
            this.Hide();
            registracijaNeregistrovanogKorisnikaWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AllFitnesCentarWindow allfitnesCentarWindow = new AllFitnesCentarWindow();
            this.Hide();
            allfitnesCentarWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NeregistrovaniKorisnikInstruktori neregistrovaniKorisnikInstruktori = new NeregistrovaniKorisnikInstruktori();
            this.Hide();
            neregistrovaniKorisnikInstruktori.Show();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            this.Hide();
            homeWindow.Show();
        }
    }
}
