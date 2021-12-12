using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class Trening : IDataErrorInfo
    {
        private string _sifra;

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

        private string _datum;

        public string Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }

        private string _vremePocetka;

        public string VremePocetka
        {
            get { return _vremePocetka; }
            set { _vremePocetka = value; }
        }

        private string _trajanje;

        public string Trajanje
        {
            get { return _trajanje; }
            set { _trajanje = value; }
        }

        private EStatusTreninga _statusTreninga;

        public EStatusTreninga StatusTreninga
        {
            get { return _statusTreninga; }
            set { _statusTreninga = value; }
        }

        private string _intruktor;

        public string Instruktor
        {
            get { return _intruktor; }
            set { _intruktor = value; }
        }

        private string _polaznik;

        public string Polaznik
        {
            get { return _polaznik; }
            set { _polaznik = value; }
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
                    case "Sifra":
                        //if(Ime!=null && Ime.Equals(String.Empty))
                        if (string.IsNullOrEmpty(Sifra))
                        {
                            return "Unos podataka uokvirenih crvenim je obavezno!";
                        }
                        break;

                    case "Datum":
                        if (string.IsNullOrEmpty(Datum))
                        {
                            return "Unos datuma je obavezno!";
                        }
                        break;

                    case "Vreme pocetka":
                        if (string.IsNullOrEmpty(VremePocetka))
                        {
                            return "Unos vremena pocetka je obavezno!";
                        }
                        break;

                    case "Trajanje":
                        if (string.IsNullOrEmpty(Trajanje))
                        {
                            return "Unos trajanja treninga je obavezno!";
                        }
                        break;

                    case "Instruktor":
                        if (string.IsNullOrEmpty(Instruktor))
                        {
                            return "Unos instruktora je obavezno!";
                        }
                        break;

                    case "Polaznik":
                        if (string.IsNullOrEmpty(Polaznik))
                        {
                            return "Unos polaznika je obavezno!";
                        }
                        break;

                }

                return String.Empty;
            }

        }

        public Trening() { }
        public override string ToString()
        {
            return "Sifra treninga: " + _sifra + ", instuktor koji drzi: " + _intruktor + ", polaznik: " + _polaznik;
        }

        public string UpisUTreningUFajl()
        {
            return Sifra + ";" + Datum + ";" + VremePocetka + ";" + Trajanje + ";" + StatusTreninga + ";" + Instruktor + ";" + Polaznik + ";" + Aktivan;
        }

        public Trening Clone()
        {
            Trening kopija = new Trening();
            kopija.Sifra = Sifra;
            kopija.Datum = Datum;
            kopija.VremePocetka = VremePocetka;
            kopija.Trajanje = Trajanje;
            kopija.StatusTreninga = StatusTreninga;
            kopija.Instruktor = Instruktor;
            kopija.Polaznik = Polaznik;

            return kopija;
        }

    }
}
