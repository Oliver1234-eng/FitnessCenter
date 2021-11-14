using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    [Serializable]
    public class Adresa
    {
        public string Id;

        public string ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public string ulica;

        public string Ulica
        {
            get { return ulica; }
            set { ulica = value; }
        }

        public string broj;

        public string Broj
        {
            get { return broj; }
            set { broj = value; }
        }

        public string grad;

        public string Grad
        {
            get { return grad; }
            set { grad = value; }
        }


        private string drzava;

        public string Drzava
        {
            get { return drzava; }
            set { drzava = value; }
        }

        private bool _aktivan;

        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }

        public override string ToString()
        {
            return "Ulica " + Ulica + " broj " + Broj + " grad" + Grad + " drzava " + Drzava;
        }

        public string UpisiAdresuUFajl()
        {
            return Ulica + ";" + Broj + ";" + Grad + ";" + Drzava;
        }

    }
}
