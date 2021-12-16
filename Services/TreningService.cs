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
    public class TreningService : ITreningService
    {
        public void ReadWorkouts(string nazivFajla)
        {
            Util.Instance.Treninzi = new ObservableCollection<Trening>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + nazivFajla))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] TreningIzFajla = line.Split(';');

                    //pronalazimo korisnika na osnovu jmbg
                    //Korisnik korisnik = Podaci.Instanca.Korisnici.Find(k => k.JMBG.Equals(instruktorIzFajla[1]));
                    //Boolean.TryParse(korisnikIzFajla[7], out Boolean aktivan);
                    Enum.TryParse(TreningIzFajla[4], out EStatusTreninga statusTreninga);
                    //Instruktor instruktor = (Instruktor)Util.Instance.Instruktori.Where(i => i.Korisnik.Ime.Equals(TreningIzFajla[5]));
                    //Polaznik polaznik = (Polaznik)Util.Instance.Polaznici.Where(p => p.Korisnik.Ime.Equals(TreningIzFajla[6]));
                    Enum.TryParse(TreningIzFajla[5], out EImenaInstruktora imenaInstruktora);
                    Enum.TryParse(TreningIzFajla[6], out EImenaPolaznika imenaPolaznika);

                    Trening trening = new Trening
                    {
                        Sifra = TreningIzFajla[0],
                        Datum = TreningIzFajla[1],
                        VremePocetka = TreningIzFajla[2],
                        Trajanje = TreningIzFajla[3],
                        StatusTreninga = statusTreninga,
                        Instruktor = imenaInstruktora,
                        Polaznik = imenaPolaznika,
                        Aktivan = true
                    };
                    Util.Instance.Treninzi.Add(trening);
                }
            }
        }

        public void SaveWorkout(string nazivFajla)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + nazivFajla))

                foreach (Trening trening in Util.Instance.Treninzi)
                {
                    file.WriteLine(trening.UpisUTreningUFajl());
                }
        }

        public void DeleteWorkout(string sifra)
        {
            Trening trening = Util.Instance.Treninzi.ToList().Find(t => t.Sifra.Equals(sifra));
            if (trening == null)
            {
                throw new TreningNotFoundException($"Ne postoji trening sa sifrom: {sifra}");
            }

            trening.Aktivan = false;
            Console.WriteLine("Uspesno obrisan trening sa sifrom:" + sifra);


            Util.Instance.SacuvajEntitet("treninzi.txt");
        }
    }
}
