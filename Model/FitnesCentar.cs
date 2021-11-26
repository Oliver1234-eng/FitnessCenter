using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class FitnesCentar
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

        private string _adresa;

        public string Adresa
        {
            get { return _adresa; }
            set { _adresa = value; }
        }

        public override string ToString()
        {
            return "Sifra fitnes centra: " + _sifra + ", naziv: " + _naziv + ".";
        }

        public string UpisUFitnesCentarUFajl()
        {
            return Sifra + ";" + Naziv + ";" + Adresa;
        }



    }
}
