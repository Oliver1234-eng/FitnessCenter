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
    public class PolaznikService : IPolaznikService
    {
        public List<RegistrovaniKorisnik> FindallClients(string email)
        {
            throw new NotImplementedException();
        }

        public void ReadUsers(string filename)
        {
            Util.Instance.Polaznici = new ObservableCollection<Polaznik>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] polaznikIzFajla = line.Split(';');
                    RegistrovaniKorisnik registrovaniKorisnik = Util.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(polaznikIzFajla[0]));

                    Polaznik polaznik = new Polaznik
                    {

                        Korisnik = registrovaniKorisnik,
                    };

                    Util.Instance.Polaznici.Add(polaznik);
                }
            }
        }

        public void SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Polaznik polaznik in Util.Instance.Polaznici)
                {
                    file.WriteLine(polaznik.PolaznikZaUpisUFajl());
                }
            }
        }
    }
}
