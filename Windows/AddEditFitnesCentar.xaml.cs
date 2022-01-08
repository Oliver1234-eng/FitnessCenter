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
    /// Interaction logic for AddEditFitnesCentar.xaml
    /// </summary>
    public partial class AddEditFitnesCentar : Window
    {
        private EStatus odabraniStatus;
        private FitnesCentar odabraniFitnesCentar;

        public AddEditFitnesCentar(FitnesCentar fitnesCentar, EStatus status = EStatus.DODAJ)
        {
            InitializeComponent();

            this.DataContext = fitnesCentar;

            odabraniFitnesCentar = fitnesCentar;
            odabraniStatus = status;

            if (status.Equals(EStatus.IZMENI) && fitnesCentar != null)
            {
                this.Title = "Izmeni fitnes centar";

            }
            else
            {
                this.Title = "Dodaj fitnes centar";
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                if (odabraniStatus.Equals(EStatus.DODAJ))
                {
                    //odabraniFitnesCentar.Aktivan = true;
                    FitnesCentar fitnesCentar = new FitnesCentar
                    {

                        //FitnesCentar = odabraniFitnesCentar;
                    };
                    Util.Instance.FitnesCentri.Add(odabraniFitnesCentar);
                }

                Util.Instance.SacuvajEntitet("fitnesCentri.txt");

                this.DialogResult = true;
                this.Close();
                MessageBox.Show("Uspesno dodat/izmenjen fitnes centar!");
            }

            else
            {
                MessageBox.Show("Nisu uneti svi podaci!");
            }
        }

        private bool IsValid()
        {
            return !Validation.GetHasError(txtSifra) && !Validation.GetHasError(txtNaziv) && !Validation.GetHasError(txtSifraAdrese)
                && !Validation.GetHasError(txtUlica) && !Validation.GetHasError(txtBroj) && !Validation.GetHasError(txtGrad)
                && !Validation.GetHasError(txtDrzava);
        }
    }
}
