using System.Collections.Generic;
using System.IO;

namespace GestiuneFarmacie
{
    // Lab 5 - implementam Interfete (clasa implementeaza interfata definita)
    public class AdministrareMedicamente_FisierText : IStocareMedicamente
    {
        private string numeFisier = "Medicamente.txt";

        public void AdaugaMedicament(Medicament m)
        {
            // Lab 5 - implementam I/O in limbajul C#. Fisiere text (utilizand StreamWriter cu append=true)
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(m.ConversieLaSir_PentruFisier());
            }
        }

        public List<Medicament> GetMedicamente()
        {
            // Lab 3 - implementam Colectii generice. Liste generice
            List<Medicament> medicamente = new List<Medicament>();

            if (!File.Exists(numeFisier)) return medicamente;

            // Lab 5 - implementam I/O in limbajul C#. Fisiere text (utilizand StreamReader)
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    medicamente.Add(new Medicament(linie));
                }
            }
            return medicamente;
        }

        public void ModificaMedicament(Medicament medicamentModificat)
        {
            List<Medicament> medicamente = GetMedicamente();

            for (int i = 0; i < medicamente.Count; i++)
            {
                if (medicamente[i].Id == medicamentModificat.Id)
                {
                    medicamente[i] = medicamentModificat; // Inlocuim medicamentul vechi cu cel nou
                    break;
                }
            }

            // Rescriem intregul fisier. "false" inseamna ca stergem continutul vechi inainte sa scriem
            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            {
                foreach (var m in medicamente)
                {
                    sw.WriteLine(m.ConversieLaSir_PentruFisier());
                }
            }
        }

        public void StergeMedicament(int idMedicament)
        {
            List<Medicament> medicamente = GetMedicamente();

            for (int i = 0; i < medicamente.Count; i++)
            {
                if (medicamente[i].Id == idMedicament)
                {
                    medicamente.RemoveAt(i); // Stergem din lista
                    break;
                }
            }

            // Rescriem fisierul fara medicamentul sters
            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            {
                foreach (var m in medicamente)
                {
                    sw.WriteLine(m.ConversieLaSir_PentruFisier());
                }
            }
        }
    }
}