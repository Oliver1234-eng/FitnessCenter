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
    public class TreningServis : ITreningServis
    {
        public void CitajTrening(string nazivFajla)
        {
            Podaci.Instanca.Treninzi = new List<Trening>();
            using (StreamReader file = new StreamReader(@"../../Resursi/" + nazivFajla))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] TreningIzFajla = line.Split(';');

                    //pronalazimo korisnika na osnovu jmbg
                    //Korisnik korisnik = Podaci.Instanca.Korisnici.Find(k => k.JMBG.Equals(instruktorIzFajla[1]));
                    //Boolean.TryParse(korisnikIzFajla[7], out Boolean aktivan);
                    Enum.TryParse(TreningIzFajla[4], out EStatusTreninga statusTreninga);
                    Instruktor instruktor = Podaci.Instanca.Instruktori.Find(i => i.Korisnik.Ime.Equals(TreningIzFajla[5]));
                    Polaznik polaznik = Podaci.Instanca.Polaznici.Find(p => p.Korisnik.Ime.Equals(TreningIzFajla[6]));

                    Trening trening = new Trening
                    {
                        Sifra = TreningIzFajla[0],
                        Datum = TreningIzFajla[1],
                        VremePocetka = TreningIzFajla[2],
                        Trajanje = TreningIzFajla[3],
                        StatusTreninga = statusTreninga,
                        Instruktor = instruktor,
                        Polaznik = polaznik,
                        Aktivan = true
                    };
                    Podaci.Instanca.Treninzi.Add(trening);
                }
            }
        }

        public void SacuvajTrening(string nazivFajla)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resursi/" + nazivFajla))

                foreach (Trening trening in Podaci.Instanca.Treninzi)
                {
                    file.WriteLine(trening.UpisUTreningUFajl());
                }
        }

        public void ObrisiTrening(string sifra)
        {
            Trening trening = Podaci.Instanca.Treninzi.ToList().Find(t => t.Sifra.Equals(sifra));
            if (trening == null)
            {
                throw new TreningNePostojiException($"Ne postoji trening sa sifrom: {sifra}");
            }

            trening.Aktivan = false;
            Console.WriteLine("Uspesno obrisan trening sa sifrom:" + sifra);


            Podaci.Instanca.SacuvajEntitete("treninzi.txt");
        }
    }
}
