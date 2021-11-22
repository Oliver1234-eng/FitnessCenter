using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.MojiIzuzeci
{
    public class InstruktorNePostojiException : Exception
    {
        public InstruktorNePostojiException() : base()
        {

        }

        public InstruktorNePostojiException(string poruka) : base(poruka)
        {

        }

        public InstruktorNePostojiException(string poruka, Exception ex) : base(poruka, ex)
        {

        }
    }
}
