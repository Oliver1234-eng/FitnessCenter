using SR12_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Servisi
{
    public class FitnesCentarServis : IFitnesCentarServis
    {
        public void CitajFitnesCentar(string nazivFajla)
        {
            Podaci.Instanca.FitnesCentarPodaci = new List<FitnesCentar>();
            using (StreamReader file = new StreamReader(@"../../Resursi/" + nazivFajla))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] FitnesCentarIzFajla = line.Split(';');

                    //pronalazimo korisnika na osnovu jmbg
                    //Korisnik korisnik = Podaci.Instanca.Korisnici.Find(k => k.JMBG.Equals(instruktorIzFajla[1]));

                    FitnesCentar fitnesCentar = new FitnesCentar
                    {
                        Sifra = FitnesCentarIzFajla[0],
                        Naziv = FitnesCentarIzFajla[1],
                        Adresa = FitnesCentarIzFajla[2]

                    };
                    Podaci.Instanca.FitnesCentarPodaci.Add(fitnesCentar);
                }
            }
        }

        public void SacuvajFitnesCentar(string nazivFajla)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resursi/" + nazivFajla))

                foreach (FitnesCentar fitnesCentar in Podaci.Instanca.FitnesCentarPodaci)
                {
                    file.WriteLine(fitnesCentar.UpisUFitnesCentarUFajl());
                }
        }
    }
}
