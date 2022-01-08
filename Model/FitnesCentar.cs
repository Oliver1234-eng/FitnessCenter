using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class FitnesCentar : IDataErrorInfo
    {
        private string _sifra;

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

        private string _naziv;

        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        private string _sifraAdrese;

        public string SifraAdrese
        {
            get { return _sifraAdrese; }
            set { _sifraAdrese = value; }
        }

        private string _ulica;

        public string Ulica
        {
            get { return _ulica; }
            set { _ulica = value; }
        }

        private string _broj;

        public string Broj
        {
            get { return _broj; }
            set { _broj = value; }
        }

        private string _grad;

        public string Grad
        {
            get { return _grad; }
            set { _grad = value; }
        }

        private string _drzava;

        public string Drzava
        {
            get { return _drzava; }
            set { _drzava = value; }
        }

        public string Error
        {
            get
            {
                return "message";
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {

                    case "Sifra":
                        if (string.IsNullOrEmpty(Sifra))
                        {
                            return "Unos podataka uokvirenih crvenim je obavezno!";
                        }
                        break;

                    case "Naziv":
                        if (string.IsNullOrEmpty(Naziv))
                        {
                            return "Unos naziva je obavezno!";
                        }
                        break;

                    case "Sifra adrese":
                        if (string.IsNullOrEmpty(SifraAdrese))
                        {
                            return "Unos sifre adrese je obavezno!";
                        }
                        break;

                    case "Ulica":
                        if (string.IsNullOrEmpty(Ulica))
                        {
                            return "Unos ulice je obavezno!";
                        }
                        break;

                    case "Broj":
                        if (string.IsNullOrEmpty(Broj))
                        {
                            return "Unos broja je obavezno!";
                        }
                        break;

                    case "Grad":
                        if (string.IsNullOrEmpty(Grad))
                        {
                            return "Unos grada je obavezno!";
                        }
                        break;

                    case "Drzava":
                        if (string.IsNullOrEmpty(Drzava))
                        {
                            return "Unos drzave je obavezno!";
                        }
                        break;

                }

                return String.Empty;
            }

        }
        public override string ToString()
        {
            return "Sifra fitnes centra: " + _sifra + ", naziv: " + _naziv + ".";
        }

        public string UpisUFitnesCentarUFajl()
        {
            return Sifra + ";" + Naziv + ";" + SifraAdrese + ";" + Ulica + ";" + Broj + ";" + Grad + ";" + Drzava;
        }

        public FitnesCentar Clone()
        {
            FitnesCentar kopija = new FitnesCentar();
            kopija.Sifra = Sifra;
            kopija.Naziv = Naziv;
            kopija.SifraAdrese = SifraAdrese;
            kopija.Ulica = Ulica;
            kopija.Broj = Broj;
            kopija.Grad = Grad;
            kopija.Drzava = Drzava;

            return kopija;
        }


    }
}
