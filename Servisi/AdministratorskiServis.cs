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
    public class AdministratorskiServis : IKorisnickiServis
    {
        public void CitajKorisnike(string nazivFajla)
        {
            Podaci.Instanca.Administratori = new List<Administrator>();
            using (StreamReader file = new StreamReader(@"../../Resursi/" + nazivFajla))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] administratorIzFajla = line.Split(';');

                    //pronalazimo korisnika na osnovu jmbg
                    Korisnik korisnik = Podaci.Instanca.Korisnici.Find(k => k.JMBG.Equals(administratorIzFajla[0]));

                    Administrator administrator = new Administrator
                    {
                        Korisnik = korisnik
                    };
                    Podaci.Instanca.Administratori.Add(administrator);
                }
            }
        }

        public void SacuvajKorisnike(string nazivFajla)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resursi/" + nazivFajla))

                foreach (Administrator administrator in Podaci.Instanca.Administratori)
                {
                    file.WriteLine(administrator.UpisiAdministratoraUFajl());
                }
        }

        public void ObrisiKorisnika(string jmbg)
        {
            Administrator administrator = Podaci.Instanca.Administratori.ToList().Find(a => a.Korisnik.JMBG.Equals(jmbg));
            if (administrator == null)
            {
                throw new AdministratorNePostojiException($"Ne postoji korisnik sa emailom: {jmbg}");
            }

            administrator.Korisnik.Aktivan = false;
            Console.WriteLine("Uspesno obrisan administrator sa jmbg-om:" + jmbg);


            Podaci.Instanca.SacuvajEntitete("korisnici.txt");
            Podaci.Instanca.SacuvajEntitete("administratori.txt");
        }
    }
}
