using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class Polaznik
    {
        //za sada je string, kasnije ce biti objekat Trening
        private string _rezervisaniTrening;

        public string RezervisaniTrening
        {
            get { return _rezervisaniTrening; }
            set { _rezervisaniTrening = value; }
        }


        private Korisnik _korisnik;

        public Korisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }

        public override string ToString()
        {
            return "Ja sam polaznik i moje ime je:" + _korisnik.Ime + ", a moj email je: " + _korisnik.Email;
        }

        public string UpisiPolaznikaUFajl()
        {
            return RezervisaniTrening + ";" + Korisnik.JMBG;
        }
    }
}
