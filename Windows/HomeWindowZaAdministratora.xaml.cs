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
    /// Interaction logic for HomeWindowZaAdministratora.xaml
    /// </summary>
    public partial class HomeWindowZaAdministratora : Window
    {
        public HomeWindowZaAdministratora()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            AllInstructorsWindow allInstructorsWindow = new AllInstructorsWindow();
            this.Hide();
            allInstructorsWindow.Show();
        }

        private void btnPolaznici_Click(object sender, RoutedEventArgs e)
        {
            AllPolazniciWindow allPolazniciWindow = new AllPolazniciWindow();
            this.Hide();
            allPolazniciWindow.Show();
        }

        private void btnAdministratori_Click(object sender, RoutedEventArgs e)
        {
            AllAdministratoriWindow allAdministratoriWindow = new AllAdministratoriWindow();
            this.Hide();
            allAdministratoriWindow.Show();
        }

        private void btnTreninzi_Click(object sender, RoutedEventArgs e)
        {
            AllTreninziWindow allTreninziWindow = new AllTreninziWindow();
            this.Hide();
            allTreninziWindow.Show();
        }

        private void btnFitnesCentri_Click(object sender, RoutedEventArgs e)
        {
            AllFitnesCentarWindow allFitnesCentarWindow = new AllFitnesCentarWindow();
            this.Hide();
            allFitnesCentarWindow.Show();
        }
    }
}
