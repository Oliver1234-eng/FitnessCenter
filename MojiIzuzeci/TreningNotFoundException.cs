using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.MojiIzuzeci
{
    public class TreningNotFoundException : Exception
    {

        public TreningNotFoundException() : base() { }
        public TreningNotFoundException(String message) : base(message) { }
        public TreningNotFoundException(String message, Exception innerException) : base(message, innerException) { }
    }
}
