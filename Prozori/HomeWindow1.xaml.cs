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

namespace SR12_2020_POP2021.Prozori
{
    /// <summary>
    /// Interaction logic for HomeWindow1.xaml
    /// </summary>
    public partial class HomeWindow1 : Window
    {
        public HomeWindow1()
        {
            InitializeComponent();

            Podaci.Instanca.CitajEntitete("korisnici.txt");
            Podaci.Instanca.CitajEntitete("instruktori.txt");
            Podaci.Instanca.CitajEntitete("polaznici.txt");
            Podaci.Instanca.CitajEntitete("administratori.txt");
            Podaci.Instanca.CitajEntitete("treninzi.txt");
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            InstruktoriWindow instruktoriWindow = new InstruktoriWindow();
            this.Hide();
            instruktoriWindow.Show();
        }

        private void btnPolaznici_Click(object sender, RoutedEventArgs e)
        {
            PolazniciWindow polazniciWindow = new PolazniciWindow();
            this.Hide();
            polazniciWindow.Show();
        }

        private void btnAdministratori_Click(object sender, RoutedEventArgs e)
        {
            AdministratoriWindow administratoriWindow = new AdministratoriWindow();
            this.Hide();
            administratoriWindow.Show();
        }

        private void btnTreninzi_Click(object sender, RoutedEventArgs e)
        {
            TreninziWindow treninziWindow = new TreninziWindow();
            this.Hide();
            treninziWindow.Show();
        }
    }
}
