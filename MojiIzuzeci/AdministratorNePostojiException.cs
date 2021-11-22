using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.MojiIzuzeci
{
    public class AdministratorNePostojiException : Exception
    {
        public AdministratorNePostojiException() : base()
        {

        }

        public AdministratorNePostojiException(string poruka) : base(poruka)
        {

        }

        public AdministratorNePostojiException(string poruka, Exception ex) : base(poruka, ex)
        {

        }
    }
}
