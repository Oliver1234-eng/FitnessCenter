using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.MojiIzuzeci
{
    public class TreningNePostojiException : Exception
    {
        public TreningNePostojiException() : base()
        {

        }

        public TreningNePostojiException(string poruka) : base(poruka)
        {

        }

        public TreningNePostojiException(string poruka, Exception ex) : base(poruka, ex)
        {

        }
    }
}
