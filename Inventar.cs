using System;
using System.Collections.Generic;

namespace GestiuneFarmacie
{
    public class Inventar
    {
        private List<Medicament> medicamente;

        public Inventar()
        {
            medicamente = new List<Medicament>();
        }
        public void AdaugaMedicament(Medicament medicamentNou)
        {
            medicamente.Add(medicamentNou);
            Console.WriteLine($"\nMedicamentul '{medicamentNou.Nume}' a fost adăugat cu succes!");
        }

        public void AfiseazaMedicamente()
        {
            Console.WriteLine("\n--- Lista Medicamente ---");
            if (medicamente.Count == 0)
            {
                Console.WriteLine("Nu există medicamente în stoc.");
                return;
            }

            foreach (var med in medicamente)
            {
                Console.WriteLine(med.ToString()); 
            }
            Console.WriteLine("-------------------------\n");
        }
    }
}