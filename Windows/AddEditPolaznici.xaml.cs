﻿using SR12_2020_POP2021.Model;
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
    /// Interaction logic for AddEditPolaznici.xaml
    /// </summary>
    public partial class AddEditPolaznici : Window
    {
        private EStatus odabraniStatus;
        private RegistrovaniKorisnik odabraniPolaznik;

        public AddEditPolaznici(RegistrovaniKorisnik polaznik, EStatus status = EStatus.DODAJ)
        {
            InitializeComponent();


            this.DataContext = polaznik;
            ComboTipKorisnika.ItemsSource = Enum.GetValues(typeof(ETipKorisnika)).Cast<ETipKorisnika>();
            ComboPol.ItemsSource = Enum.GetValues(typeof(EPol)).Cast<EPol>();

            odabraniPolaznik = polaznik;
            odabraniStatus = status;

            if (status.Equals(EStatus.IZMENI) && polaznik != null)
            {
                this.Title = "Izmeni polaznika";

            }
            else
            {
                this.Title = "Dodaj polaznika";
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
                    odabraniPolaznik.Aktivan = true;
                    Polaznik polaznik = new Polaznik
                    {

                        Korisnik = odabraniPolaznik
                    };
                    Util.Instance.Korisnici.Add(odabraniPolaznik);
                    Util.Instance.Polaznici.Add(polaznik);
                }

                Util.Instance.SacuvajEntitet("korisnici.txt");
                Util.Instance.SacuvajEntitet("polaznici.txt");

                this.DialogResult = true;
                this.Close();
                MessageBox.Show("Uspesno dodat/izmenjen polaznik!");
            }

            else
            {
                MessageBox.Show("Nisu uneti svi podaci!");
            }
        }

        private bool IsValid()
        {
            return !Validation.GetHasError(txtJmbg) && !Validation.GetHasError(txtEmail) && !Validation.GetHasError(txtIme)
                && !Validation.GetHasError(txtPrezime) && !Validation.GetHasError(txtLozinka) && !Validation.GetHasError(txtSifra)
                && !Validation.GetHasError(txtUlica) && !Validation.GetHasError(txtBroj) && !Validation.GetHasError(txtGrad)
                && !Validation.GetHasError(txtDrzava);
        }
    }
}
