using SR12_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Services
{
    public class AdministratorService : IAdministratorService
    {
        public List<RegistrovaniKorisnik> FindallClients(string email)
        {
            throw new NotImplementedException();
        }

        public void ReadUsers(string filename)
        {
            Util.Instance.Administratori = new ObservableCollection<Administrator>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] administratorIzFajla = line.Split(';');
                    RegistrovaniKorisnik registrovaniKorisnik = Util.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(administratorIzFajla[0]));

                    Administrator administrator = new Administrator
                    {

                        Korisnik = registrovaniKorisnik,
                    };

                    Util.Instance.Administratori.Add(administrator);
                }
            }
        }

        public void SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Administrator administrator in Util.Instance.Administratori)
                {
                    file.WriteLine(administrator.AdministratorZaUpisUFajl());
                }
            }
        }
    }
}
