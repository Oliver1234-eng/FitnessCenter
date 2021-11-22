using SR12_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Servisi
{
    public class PolaznickiServis : IKorisnickiServis
    {
        public void CitajKorisnike(string nazivFajla)
        {
            Podaci.Instanca.Polaznici = new List<Polaznik>();
            using (StreamReader file = new StreamReader(@"../../Resursi/" + nazivFajla))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] polaznikIzFajla = line.Split(';');

                    //pronalazimo korisnika na osnovu jmbg
                    Korisnik korisnik = Podaci.Instanca.Korisnici.Find(k => k.JMBG.Equals(polaznikIzFajla[1]));

                    Polaznik polaznik = new Polaznik
                    {
                        RezervisaniTrening = polaznikIzFajla[0],
                        Korisnik = korisnik
                    };
                    Podaci.Instanca.Polaznici.Add(polaznik);
                }
            }
        }

        public void SacuvajKorisnike(string nazivFajla)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resursi/" + nazivFajla))

                foreach (Polaznik polaznik in Podaci.Instanca.Polaznici)
                {
                    file.WriteLine(polaznik.UpisiPolaznikaUFajl());
                }
        }
    }

}
