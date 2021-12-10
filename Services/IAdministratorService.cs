using SR12_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Services
{
    public interface IAdministratorService
    {
        void SaveUsers(string filename);
        void ReadUsers(string filename);
        List<RegistrovaniKorisnik> FindallClients(String email);
    }
}
