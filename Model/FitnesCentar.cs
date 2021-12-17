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

        public override string ToString()
        {
            return "Sifra fitnes centra: " + _sifra + ", naziv: " + _naziv + ".";
        }

        public string UpisUFitnesCentarUFajl()
        {
            return Sifra + ";" + Naziv + ";" + SifraAdrese + ";" + Ulica + ";" + Broj + ";" + Grad + ";" + Drzava;
        }



    }
}
