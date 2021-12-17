using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Services
{
    public interface IFitnesCentarService
    {
        void SaveFitnessCenter(string filename);
        void ReadFitnessCenter(string filename);
    }
}
