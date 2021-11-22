using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.MojiIzuzeci
{
    public class PolaznikNePostojiException : Exception
    {
        public PolaznikNePostojiException() : base()
        {

        }

        public PolaznikNePostojiException(string poruka) : base(poruka)
        {

        }

        public PolaznikNePostojiException(string poruka, Exception ex) : base(poruka, ex)
        {

        }
    }
}
