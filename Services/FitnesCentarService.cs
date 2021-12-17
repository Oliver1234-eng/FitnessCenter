using SR12_2020_POP2021.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR12_2020_POP2021.Services
{
    public class FitnesCentarService : IFitnesCentarService
    {
        public void ReadFitnessCenter(string filename)
        {
            Util.Instance.FitnesCentri = new ObservableCollection<FitnesCentar>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] FitnesCentarIzFajla = line.Split(';');

                    FitnesCentar fitnesCentar = new FitnesCentar
                    {
                        Sifra = FitnesCentarIzFajla[0],
                        Naziv = FitnesCentarIzFajla[1],
                        SifraAdrese = FitnesCentarIzFajla[2],
                        Ulica = FitnesCentarIzFajla[3],
                        Broj = FitnesCentarIzFajla[4],
                        Grad = FitnesCentarIzFajla[5],
                        Drzava = FitnesCentarIzFajla[6]

                    };
                    Util.Instance.FitnesCentri.Add(fitnesCentar);
                }
            }
        }

        public void SaveFitnessCenter(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))

                foreach (FitnesCentar fitnesCentar in Util.Instance.FitnesCentri)
                {
                    file.WriteLine(fitnesCentar.UpisUFitnesCentarUFajl());
                }
        }
    }
}
