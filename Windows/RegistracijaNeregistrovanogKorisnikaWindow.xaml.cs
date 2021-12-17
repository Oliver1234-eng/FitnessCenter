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
    /// Interaction logic for RegistracijaNeregistrovanogKorisnikaWindow.xaml
    /// </summary>
    public partial class RegistracijaNeregistrovanogKorisnikaWindow : Window
    {
        public RegistracijaNeregistrovanogKorisnikaWindow()
        {
            InitializeComponent();
        }

        private void Registracija_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik noviKorisnik = new RegistrovaniKorisnik();
            FormaZaRegistraciju formaZaRegistraciju = new FormaZaRegistraciju(noviKorisnik);
            this.Hide();
            if (!(bool)formaZaRegistraciju.ShowDialog())
            {

            }
            this.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeWindowNeregistrovaniKorisnik homeWindowNeregistrovaniKorisnik = new HomeWindowNeregistrovaniKorisnik();
            this.Hide();
            homeWindowNeregistrovaniKorisnik.Show();
        }
    }
}
