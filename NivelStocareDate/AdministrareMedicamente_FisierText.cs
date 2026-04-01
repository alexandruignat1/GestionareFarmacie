using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration; // Lab 5 - Utilizarea setarilor din fisierul de configurari

namespace GestionareFarmacie
{
    // Lab 5 - implementam Interfete (clasa implementeaza interfata definita)
    public class AdministrareMedicamente_FisierText : IStocareMedicamente
    {
        // Declaram variabila care va tine numele fisierului
        private string numeFisier;

        // Constructorul - aici setam numele fisierului intr-un mod sigur (fara crash)
        public AdministrareMedicamente_FisierText()
        {
            try
            {
                // Lab 5 - Utilizarea setarilor din fisierul de configurari
                numeFisier = ConfigurationManager.AppSettings["NumeFisier"];

                // Daca in App.config este gol sau nu s-a copiat bine, punem manual un nume
                if (string.IsNullOrEmpty(numeFisier))
                {
                    numeFisier = "Medicamente.txt";
                }
            }
            catch
            {
                // Daca lipseste pachetul NuGet sau da orice alta eroare, folosim fisierul standard
                numeFisier = "Medicamente.txt";
            }
        }

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
                    medicamente[i] = medicamentModificat;
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
                    medicamente.RemoveAt(i);
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