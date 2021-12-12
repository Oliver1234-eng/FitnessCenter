using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class RegistrovaniKorisnik : IDataErrorInfo
    {

        private string _ime;

        public string Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }

        private string _prezime;

        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }

        private string _lozinka;

        public string Lozinka
        {
            get { return _lozinka; }
            set { _lozinka = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _JMBG;

        public string JMBG
        {
            get { return _JMBG; }
            set
            {
                if (value != null)
                {
                    if (Util.Instance.Korisnici.ToList().Exists(k => k.JMBG.Equals(value)))
                    {
                        //throw new ArgumentException("Jmbg mora biti jedinstven!");
                    }
                }

                _JMBG = value;
            }
        }

        private EPol _pol;

        public EPol Pol
        {
            get { return _pol; }
            set { _pol = value; }
        }

        private ETipKorisnika _tipKorisnika;

        public ETipKorisnika TipKorisnika
        {
            get { return _tipKorisnika; }
            set { _tipKorisnika = value; }
        }

        private string _sifra;

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
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

        private bool _aktivan;

        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
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
                    case "Ime":
                        //if(Ime!=null && Ime.Equals(String.Empty))
                        if (string.IsNullOrEmpty(Ime))
                        {
                            return "Unos podataka uokvirenih crvenim je obavezno!";
                        }
                        break;

                    case "Prezime":
                        if (string.IsNullOrEmpty(Prezime))
                        {
                            return "Unos prezimena je obavezno!";
                        }
                        break;

                    case "Lozinka":
                        if (string.IsNullOrEmpty(Lozinka))
                        {
                            return "Unos lozinke je obavezno!";
                        }
                        break;

                    case "Sifra":
                        if (string.IsNullOrEmpty(Sifra))
                        {
                            return "Unos sifre je obavezno!";
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

        public RegistrovaniKorisnik() { }

        public override string ToString()
        {
            return "Ja sam " + Ime + " " + Prezime + " tip " + TipKorisnika + " moj email je: " + Email;
        }

        public string KorisnikZaUpisUFajl()
        {
            return Ime + ";" + Prezime + ";" + JMBG + ";" + Pol + ";" + Email + ";" + Lozinka + ";" + TipKorisnika + ";" + Sifra + ";" + Ulica + ";" + Broj + ";" + Grad + ";" + Drzava + ";" + Aktivan;
        }

        public RegistrovaniKorisnik Clone()
        {
            RegistrovaniKorisnik kopija = new RegistrovaniKorisnik();
            kopija.Ime = Ime;
            kopija.Prezime = Prezime;
            kopija.JMBG = JMBG;
            kopija.Pol = Pol;
            kopija.Email = Email;
            kopija.Lozinka = Lozinka;
            kopija.TipKorisnika = TipKorisnika;
            kopija.Sifra = Sifra;
            kopija.Ulica = Ulica;
            kopija.Broj = Broj;
            kopija.Grad = Grad;
            kopija.Drzava = Drzava;

            return kopija;
        }
    }
}
