using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class Administrator
    {
        private Korisnik _korisnik;

        public Korisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }

        public override string ToString()
        {
            return "Ja sam administrator i moje ime je:" + _korisnik.Ime + ", a moj email je :" + _korisnik.Email;
        }

        public string UpisiAdministratoraUFajl()
        {
            return Korisnik.JMBG + ";" + Korisnik.Email;
        }
    }
}
