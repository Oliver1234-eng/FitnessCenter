using SR12_2020_POP2021.Model;
using SR12_2020_POP2021.MojiIzuzeci;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Servisi
{
    public class InstruktorskiServis : IKorisnickiServis
    {
        public void CitajKorisnike(string nazivFajla)
        {
            Podaci.Instanca.Instruktori = new List<Instruktor>();
            using (StreamReader file = new StreamReader(@"../../Resursi/" + nazivFajla))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] instruktorIzFajla = line.Split(';');
                    //Korisnik korisnik = Podaci.Instanca.Korisnici.ToList().Find(k => k.Email.Equals(instruktorIzFajla[0]));
                    //pronalazimo korisnika na osnovu jmbg
                    Korisnik korisnik = Podaci.Instanca.Korisnici.Find(k => k.JMBG.Equals(instruktorIzFajla[1]));
                    //Boolean.TryParse(instruktorIzFajla[2], out Boolean aktivan);

                    Instruktor instruktor = new Instruktor
                    {
                        //Aktivan = korisnik.Aktivan,
                        Trening = instruktorIzFajla[0],
                        Korisnik = korisnik
                        //instruktor.Korisnik.Aktivan = instruktorIzFajla[2],
                        //instruktor.Korisnik.Ime = instruktorIzFajla[0],
                        //Prezime = korisnik.Prezime,
                        //Email = korisnik.Email,
                        //JMBG = korisnik.JMBG,
                        //Lozinka = korisnik.Lozinka,
                        //Pol = korisnik.Pol,
                        //TipKorisnika = ETipKorisnika.Instruktor,

                    };

                    instruktor.Korisnik.Ime = korisnik.Ime;
                    instruktor.Korisnik.Prezime = korisnik.Prezime;
                    instruktor.Korisnik.JMBG = korisnik.JMBG;
                    instruktor.Korisnik.Email = korisnik.Email;
                    instruktor.Korisnik.TipKorisnika = korisnik.TipKorisnika;
                    instruktor.Korisnik.Pol = korisnik.Pol;

                    Podaci.Instanca.Instruktori.Add(instruktor);

                }
            }
        }

        public void SacuvajKorisnike(string nazivFajla)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resursi/" + nazivFajla))

                foreach (Instruktor instruktor in Podaci.Instanca.Instruktori)
                {
                    file.WriteLine(instruktor.UpisiInstruktoraUFajl());
                }
        }

        public void ObrisiKorisnika(string jmbg)
        {
            Instruktor instruktor = Podaci.Instanca.Instruktori.ToList().Find(i => i.Korisnik.JMBG.Equals(jmbg));
            if (instruktor == null)
            {
                throw new InstruktorNePostojiException($"Ne postoji korisnik sa emailom: {jmbg}");
            }

            instruktor.Korisnik.Aktivan = false;
            Console.WriteLine("Uspesno obrisan instruktor sa jmbg-om:" + jmbg);


            Podaci.Instanca.SacuvajEntitete("korisnici.txt");
            Podaci.Instanca.SacuvajEntitete("instruktori.txt");
        }
    }
}
