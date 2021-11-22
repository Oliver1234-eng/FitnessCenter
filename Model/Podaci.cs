using SR12_2020_POP2021.Servisi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Model
{
    public sealed class Podaci
    {
        private static readonly Podaci instanca = new Podaci();
        private IKorisnickiServis korisnickiServis;
        private IKorisnickiServis instruktorskiServis;
        private IKorisnickiServis administratorskiServis;
        private IKorisnickiServis polaznickiServis;

        private Podaci()
        {
            korisnickiServis = new KorisnickiServis();
            instruktorskiServis = new InstruktorskiServis();
            administratorskiServis = new AdministratorskiServis();
            polaznickiServis = new PolaznickiServis();
        }

        static Podaci()
        {

        }

        public static Podaci Instanca
        {
            get { return instanca; }
        }

        public List<Korisnik> Korisnici { get; set; }
        public List<Instruktor> Instruktori { get; set; }
        public List<Administrator> Administratori { get; set; }
        public List<Polaznik> Polaznici { get; set; }
        public List<Adresa> Adrese { get; set; }
        public List<FitnesCentar> FitnesCentarPodaci { get; set; }
        public List<Trening> Treninzi { get; set; }

        public void Inicijalizacija()
        {
            Korisnici = new List<Korisnik>();
            Instruktori = new List<Instruktor>();
            Administratori = new List<Administrator>();
            Polaznici = new List<Polaznik>();

            Adresa adresa = new Adresa
            {
                Grad = "Novi Sad",
                Drzava = "Srbija",
                Ulica = "ulica1",
                Broj = "22",
                ID = "1"
            };

            Korisnik korisnik1 = new Korisnik();
            korisnik1.Ime = "Pera";
            korisnik1.Prezime = "Peric";
            korisnik1.Email = "pera@gmail.com";
            korisnik1.JMBG = "123456";
            korisnik1.Lozinka = "peki";
            korisnik1.Adresa = adresa;
            korisnik1.Pol = EPol.MUSKI;
            korisnik1.TipKorisnika = ETipKorisnika.Administrator;
            korisnik1.Aktivan = true;

            Korisnik korisnik2 = new Korisnik
            {
                Email = "mika@gmail.com",
                Ime = "mika",
                Prezime = "Mikic",
                JMBG = "654321",
                Lozinka = "zika",
                Pol = EPol.ZENSKI,
                TipKorisnika = ETipKorisnika.Instruktor,
                Adresa = adresa,
                Aktivan = true
            };

            Korisnik korisnik3 = new Korisnik
            {
                Email = "zika@gmail.com",
                Ime = "zika",
                Prezime = "Zikic",
                JMBG = "111111",
                Lozinka = "zika",
                Pol = EPol.ZENSKI,
                TipKorisnika = ETipKorisnika.Polaznik,
                Adresa = adresa,
                Aktivan = true
            };

            // Console.WriteLine(korisnik1.ToString());
            //  Console.WriteLine(korisnik2.ToString());



            Instruktor korisnik4 = new Instruktor
            {
                Trening = "trening1",
                Korisnik = korisnik2
            };

            Administrator korisnik5 = new Administrator
            {
                Korisnik = korisnik1
            };

            Polaznik korisnik6 = new Polaznik
            {
                RezervisaniTrening = "trening2",
                Korisnik = korisnik3
            };

            // Console. WriteLine(korisnik4.ToString());

            Korisnici.Add(korisnik1);
            Korisnici.Add(korisnik2);
            Korisnici.Add(korisnik3);
            Instruktori.Add(korisnik4);
            Administratori.Add(korisnik5);
            Polaznici.Add(korisnik6);
        }

        public void SacuvajEntitete(string nazivFajla)
        {
            if (nazivFajla.Contains("korisnici"))
            {
                korisnickiServis.SacuvajKorisnike(nazivFajla);
            }
            else if (nazivFajla.Contains("instruktori"))
            {
                instruktorskiServis.SacuvajKorisnike(nazivFajla);
            }
            else if (nazivFajla.Contains("administratori"))
            {
                administratorskiServis.SacuvajKorisnike(nazivFajla);
            }
            else if (nazivFajla.Contains("polaznici"))
            {
                polaznickiServis.SacuvajKorisnike(nazivFajla);
            }
        }

        private void SacuvajAdrese(string nazivFajla)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resursi/" + nazivFajla))

                foreach (Adresa adresa in Adrese)
                {
                    file.WriteLine(adresa.UpisiAdresuUFajl());
                }
        }

        public void CitajEntitete(string nazivFajla)
        {
            if (nazivFajla.Contains("korisnici"))
            {
                korisnickiServis.CitajKorisnike(nazivFajla);
            }
            else if (nazivFajla.Contains("instruktori"))
            {
                instruktorskiServis.CitajKorisnike(nazivFajla);
            }
            else if (nazivFajla.Contains("administratori"))
            {
                administratorskiServis.CitajKorisnike(nazivFajla);
            }
            else if (nazivFajla.Contains("polaznici"))
            {
                polaznickiServis.CitajKorisnike(nazivFajla);
            }
        }

        private void CitajAdrese(string nazivFajla)
        {
            Adrese = new List<Adresa>();
            using (StreamReader file = new StreamReader(@"../../Resursi/" + nazivFajla))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] adresaIzFajla = line.Split(';');

                    Adresa adresa = new Adresa
                    {
                        Ulica = adresaIzFajla[0],
                        Broj = adresaIzFajla[1],
                        Grad = adresaIzFajla[2],
                        Drzava = adresaIzFajla[3]
                    };
                    Adrese.Add(adresa);
                }
            }

        }

        public void CuvanjeEntitetaBinarno(string nazivFajla)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(@"../../Resursi/" + nazivFajla, FileMode.Create, FileAccess.Write))
            {
                if (nazivFajla.Contains("korisnici"))
                {
                    formatter.Serialize(stream, Korisnici);
                }
                else if (nazivFajla.Contains("instruktori"))
                {
                    formatter.Serialize(stream, Instruktori);
                }
                else if (nazivFajla.Contains("administratori"))
                {
                    formatter.Serialize(stream, Administratori);
                }
                else
                {
                    formatter.Serialize(stream, Polaznici);
                }
            }

        }

        public void CitanjeEntitetaBinarno(string nazivFajla)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(@"../../Resursi/" + nazivFajla, FileMode.Open, FileAccess.Read))
            {
                if (nazivFajla.Contains("korisnici"))
                {
                    Korisnici = (List<Korisnik>)formatter.Deserialize(stream);
                }
                else if (nazivFajla.Contains("instruktori"))
                {
                    Instruktori = (List<Instruktor>)formatter.Deserialize(stream);
                }
                else if (nazivFajla.Contains("administratori"))
                {
                    Administratori = (List<Administrator>)formatter.Deserialize(stream);
                }
                else
                {
                    Polaznici = (List<Polaznik>)formatter.Deserialize(stream);
                }
            }
        }
    }
}
