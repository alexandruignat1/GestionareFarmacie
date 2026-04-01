using System.Collections.Generic;

namespace GestiuneFarmacie
{
    // Lab 5 - implementam Interfete
    public interface IStocareMedicamente
    {
        void AdaugaMedicament(Medicament m);

        // Lab 3 - implementam Colectii generice. Liste generice
        List<Medicament> GetMedicamente();

        void ModificaMedicament(Medicament medicamentModificat);
        void StergeMedicament(int idMedicament);
    }
}