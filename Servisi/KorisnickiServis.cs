using SR12_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Servisi
{
    public class KorisnickiServis : IKorisnickiServis
    {
        public void CitajKorisnike(string nazivFajla)
        {
            Podaci.Instanca.Korisnici = new List<Korisnik>();
            using (StreamReader file = new StreamReader(@"../../Resursi/" + nazivFajla))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');
                    Enum.TryParse(korisnikIzFajla[5], out EPol pol);
                    Enum.TryParse(korisnikIzFajla[6], out ETipKorisnika tip);
                    Boolean.TryParse(korisnikIzFajla[8], out Boolean aktivan);

                    Korisnik korisnik = new Korisnik
                    {
                        Ime = korisnikIzFajla[0],
                        Prezime = korisnikIzFajla[1],
                        JMBG = korisnikIzFajla[2],
                        Email = korisnikIzFajla[3],
                        Lozinka = korisnikIzFajla[4],
                        Pol = pol,
                        TipKorisnika = tip,
                        Adresa = korisnikIzFajla[7],
                        Aktivan = aktivan

                    };
                    Podaci.Instanca.Korisnici.Add(korisnik);
                }
            }
        }

        public void SacuvajKorisnike(string nazivFajla)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resursi/" + nazivFajla))

                foreach (Korisnik korisnik in Podaci.Instanca.Korisnici)
                {
                    file.WriteLine(korisnik.UpisiKorisnikaUFajl());
                }
        }
    }
}
