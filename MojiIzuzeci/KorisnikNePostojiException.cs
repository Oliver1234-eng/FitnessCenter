using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.MojiIzuzeci
{
    public class KorisnikNePostojiException : Exception
    {
        public KorisnikNePostojiException() : base()
        {

        }

        public KorisnikNePostojiException(string poruka) : base(poruka)
        {

        }

        public KorisnikNePostojiException(string poruka, Exception ex) : base(poruka, ex)
        {

        }
    }
}
