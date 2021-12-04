using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Servisi
{
    public interface IKorisnickiServis
    {
        void SacuvajKorisnike(string nazivFajla);
        void CitajKorisnike(string nazivFajla);
        void ObrisiKorisnika(string jmbg);
    }
}
