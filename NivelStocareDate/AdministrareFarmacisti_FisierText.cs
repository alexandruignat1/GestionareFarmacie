using System.Collections.Generic;
using System.IO;

namespace GestionareFarmacie
{
    public class AdministrareFarmacisti_FisierText : IStocareFarmacisti
    {
        private string numeFisier = "Farmacisti.txt";

        public AdministrareFarmacisti_FisierText()
        {
            // Se asigură că fișierul există la pornire
            if (!File.Exists(numeFisier))
            {
                File.Create(numeFisier).Close();
            }
        }

        public void AdaugaFarmacist(Farmacist f)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(f.ConversieLaSir_PentruFisier());
            }
        }

        public List<Farmacist> GetFarmacisti()
        {
            List<Farmacist> farmacisti = new List<Farmacist>();
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()!) != null)
                {
                    if (!string.IsNullOrWhiteSpace(linie))
                    {
                        farmacisti.Add(new Farmacist(linie));
                    }
                }
            }
            return farmacisti;
        }

        public void ModificaFarmacist(Farmacist fActualizat)
        {
            List<Farmacist> farmacisti = GetFarmacisti();
            for (int i = 0; i < farmacisti.Count; i++)
            {
                if (farmacisti[i].Id == fActualizat.Id)
                {
                    farmacisti[i] = fActualizat;
                    break;
                }
            }
            RescrieFisier(farmacisti);
        }

        public void StergeFarmacist(int idFarmacist)
        {
            List<Farmacist> farmacisti = GetFarmacisti();
            farmacisti.RemoveAll(f => f.Id == idFarmacist);
            RescrieFisier(farmacisti);
        }

        private void RescrieFisier(List<Farmacist> farmacisti)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            {
                foreach (var f in farmacisti)
                {
                    sw.WriteLine(f.ConversieLaSir_PentruFisier());
                }
            }
        }
    }
}