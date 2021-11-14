using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class Korisnik
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
            set { _JMBG = value; }
        }

        private Adresa _adresa;

        public Adresa Adresa
        {
            get { return _adresa; }
            set { _adresa = value; }
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

        private bool _aktivan; //da li je korisnik aktivan/neobrisan

        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }


        public Korisnik()
        {

        }

        public override string ToString()
        {
            return "Ja sam korisnik " + Ime + ". Moja email adresa je: " + Email;
        }

        public string UpisiKorisnikaUFajl()
        {
            return Ime + ";" + Prezime + ";" + JMBG + ";" + Email + ";" + Pol + ";" + TipKorisnika + ";" + Aktivan;
        }

    }
}
