using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Services
{
    public interface ITreningService
    {
        void SaveWorkout(string filename);
        void ReadWorkouts(string filename);
        void DeleteWorkout(string sifra);
    }
}
