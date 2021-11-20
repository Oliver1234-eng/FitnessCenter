using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class Instruktor
    {
        //za sada je string, kasnije ce biti objekat Trening
        private string _trening;

        public string Trening
        {
            get { return _trening; }
            set { _trening = value; }
        }


        private Korisnik _korisnik;

        public Korisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }

        public override string ToString()
        {
            return "Ja sam korisnik " + _korisnik.Ime + ". Moja email adresa je: " + _korisnik.Email + ". Ja sam instruktor.";
        }

        public string UpisiInstruktoraUFajl()
        {
            return Trening + ";" + Korisnik.JMBG;
        }
    }
}
