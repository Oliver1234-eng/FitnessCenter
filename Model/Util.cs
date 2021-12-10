using SR12_2020_POP2021.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    public sealed class Util
    {
        private static readonly Util instance = new Util();
        private IUserService userService;
        private IInstruktorService instruktorService;
        private IPolaznikService polaznikService;
        private IAdministratorService administratorService;
        private ITreningService treningService;

        private Util()
        {
            userService = new UserService();
            instruktorService = new InstruktorService();
            polaznikService = new PolaznikService();
            administratorService = new AdministratorService();
            treningService = new TreningService();
        }

        static Util() { }

        public static Util Instance
        {
            get
            {
                return instance;
            }
        }

        public ObservableCollection<RegistrovaniKorisnik> Korisnici { get; set; }
        public ObservableCollection<Instruktor> Instruktori { get; set; }
        public ObservableCollection<Polaznik> Polaznici { get; set; }
        public ObservableCollection<Administrator> Administratori { get; set; }
        public ObservableCollection<Trening> Treninzi { get; set; }

        public void Initialize()
        {

            Korisnici = new ObservableCollection<RegistrovaniKorisnik>();
            Instruktori = new ObservableCollection<Instruktor>();
            Polaznici = new ObservableCollection<Polaznik>();
            Administratori = new ObservableCollection<Administrator>();
            Treninzi = new ObservableCollection<Trening>();

            Adresa adresa = new Adresa
            {
                Grad = "Novi Sad",
                Drzava = "Srbija",
                Ulica = "ulica1",
                Broj = "22",
                ID = "1"
            };

            RegistrovaniKorisnik korisnik1 = new RegistrovaniKorisnik();
            korisnik1.Ime = "Pera";
            korisnik1.Prezime = "Peric";
            korisnik1.Email = "pera@gmail.com";
            korisnik1.JMBG = "121346";
            korisnik1.Lozinka = "peki";
            korisnik1.Pol = EPol.MUSKI;
            korisnik1.TipKorisnika = ETipKorisnika.Administrator;
            korisnik1.Sifra = "1";
            korisnik1.Ulica = "Ulica1";
            korisnik1.Broj = "1";
            korisnik1.Grad = "Novi Sad";
            korisnik1.Drzava = "Srbija";
            korisnik1.Aktivan = true;

            RegistrovaniKorisnik korisnik2 = new RegistrovaniKorisnik
            {
                Email = "mika@gmail.com",
                Ime = "mika",
                Prezime = "Mikic",
                JMBG = "121346",
                Lozinka = "zika",
                Pol = EPol.ZENSKI,
                TipKorisnika = ETipKorisnika.Instruktor,
                Sifra = "2",
                Ulica = "Ulica2",
                Broj = "2",
                Grad = "Novi Sad",
                Drzava = "Srbija",
                Aktivan = true
            };

            RegistrovaniKorisnik korisnik3 = new RegistrovaniKorisnik
            {
                Email = "marko@gmail.com",
                Ime = "marko",
                Prezime = "Markic",
                JMBG = "847721",
                Lozinka = "marko",
                Pol = EPol.ZENSKI,
                TipKorisnika = ETipKorisnika.Polaznik,
                Sifra = "3",
                Ulica = "Ulica3",
                Broj = "3",
                Grad = "Novi Sad",
                Drzava = "Srbija",
                Aktivan = true
            };

            Instruktor korisnik4 = new Instruktor
            {
                Korisnik = korisnik2,
            };

            Polaznik korisnik5 = new Polaznik
            {
                Korisnik = korisnik3,
            };

            Administrator korisnik6 = new Administrator
            {
                Korisnik = korisnik1,
            };

            Korisnici.Add(korisnik1);
            Korisnici.Add(korisnik2);
            Korisnici.Add(korisnik3);
            Instruktori.Add(korisnik4);
            Polaznici.Add(korisnik5);
            Administratori.Add(korisnik6);
        }

        public void SacuvajEntitet(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                userService.SaveUsers(filename);
            }
            else if (filename.Contains("instruktori"))
            {
                instruktorService.SaveUsers(filename);
            }
            else if (filename.Contains("polaznici"))
            {
                polaznikService.SaveUsers(filename);
            }
            else if (filename.Contains("administratori"))
            {
                administratorService.SaveUsers(filename);
            }
            else if (filename.Contains("treninzi"))
            {
                treningService.SaveWorkout(filename);
            }
        }

        public void CitanjeEntiteta(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                userService.ReadUsers(filename);
            }
            else if (filename.Contains("instruktori"))
            {
                instruktorService.ReadUsers(filename);
            }
            else if (filename.Contains("polaznici"))
            {
                polaznikService.ReadUsers(filename);
            }
            else if (filename.Contains("administratori"))
            {
                administratorService.ReadUsers(filename);
            }
            else if (filename.Contains("treninzi"))
            {
                treningService.ReadWorkouts(filename);
            }
        }

        public void DeleteUser(string email)
        {
            userService.DeleteUser(email);
        }

        public void DeleteWorkout(string sifra)
        {
            treningService.DeleteWorkout(sifra);
        }

        public void SacuvajUBin(string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(@"../../Resources/" + filename, FileMode.Create, FileAccess.Write))
            {
                if (filename.Contains("korisnici"))
                {
                    formatter.Serialize(stream, Util.Instance.Korisnici);
                }
                else if (filename.Contains("instruktori"))
                {
                    formatter.Serialize(stream, Util.Instance.Instruktori);
                }
            }
        }

        public void CitajIzBin(string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(@"../../Resources/" + filename, FileMode.Open, FileAccess.Read))
            {
                if (filename.Contains("korisnici"))
                {
                    Korisnici = (ObservableCollection<RegistrovaniKorisnik>)formatter.Deserialize(stream);
                }
                else if (filename.Contains("instruktori"))
                {
                    Instruktori = (ObservableCollection<Instruktor>)formatter.Deserialize(stream);
                }
            }
        }
    }
}
