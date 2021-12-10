using SR12_2020_POP2021.Model;
using SR12_2020_POP2021.MojiIzuzeci;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Services
{
    public class UserService : IUserService
    {
        public void DeleteUser(string email)
        {

            RegistrovaniKorisnik registrovaniKorisnik = Util.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(email));
            if (registrovaniKorisnik == null)
            {
                throw new UserNotFoundException($"Ne postoji korisnik sa emailom: {email}");
            }

            registrovaniKorisnik.Aktivan = false;
            Console.WriteLine("Uspesno obrisan korisnik sa emailom:" + email);


            Util.Instance.SacuvajEntitet("korisnici.txt");
        }

        public void ReadUsers(string filename)
        {
            Util.Instance.Korisnici = new ObservableCollection<RegistrovaniKorisnik>();

            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');

                    Enum.TryParse(korisnikIzFajla[3], out EPol pol);
                    Enum.TryParse(korisnikIzFajla[6], out ETipKorisnika tip);
                    Boolean.TryParse(korisnikIzFajla[12], out Boolean status);
                    RegistrovaniKorisnik registrovaniKorisnik = new RegistrovaniKorisnik
                    {

                        Ime = korisnikIzFajla[0],
                        Prezime = korisnikIzFajla[1],
                        JMBG = korisnikIzFajla[2],
                        Pol = pol,
                        Email = korisnikIzFajla[4],
                        Lozinka = korisnikIzFajla[5],
                        TipKorisnika = tip,
                        Sifra = korisnikIzFajla[7],
                        Ulica = korisnikIzFajla[8],
                        Broj = korisnikIzFajla[9],
                        Grad = korisnikIzFajla[10],
                        Drzava = korisnikIzFajla[11],
                        Aktivan = status
                    };

                    Util.Instance.Korisnici.Add(registrovaniKorisnik);
                }
            }
        }

        public void SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (RegistrovaniKorisnik registrovaniKorisnik in Util.Instance.Korisnici)
                {
                    file.WriteLine(registrovaniKorisnik.KorisnikZaUpisUFajl());
                }
            }
        }
    }
}
