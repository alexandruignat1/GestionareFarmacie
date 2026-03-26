using System;
using System.Collections.Generic;
using System.Linq; // -- Lab 4

namespace GestiuneFarmacie
{
    public class Inventar
    {
        // -- Lab 3: Colectie generica List<T> --
        private List<Medicament> medicamente;

        public Inventar()
        {
            medicamente = new List<Medicament>();
        }

        public void AdaugaMedicament(Medicament m)
        {
            medicamente.Add(m);
        }

        public void AfiseazaMedicamente()
        {
            if (medicamente.Count == 0)
            {
                Console.WriteLine("Nu exista medicamente in stoc.");
                return;
            }

            foreach (var med in medicamente)
            {
                Console.WriteLine(med.ToString());
            }
        }

        // -- Lab 3 & Lab 4: Cautare folosind LINQ --
        public List<Medicament> CautaDupaNume(string numeCautat)
        {
            return medicamente.Where(m => m.Nume.ToLower().Contains(numeCautat.ToLower())).ToList();// Cauta medicamente care contin numele cautat (case-insensitive)
        }
    }
}