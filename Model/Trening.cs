using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class Trening
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

        private Instruktor _intruktor;

        public Instruktor Instruktor
        {
            get { return _intruktor; }
            set { _intruktor = value; }
        }

        private Polaznik _polaznik;

        public Polaznik Polaznik
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

        public override string ToString()
        {
            return "Sifra treninga:" + _sifra;
        }

    }
}
