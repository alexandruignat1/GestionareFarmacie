using System;
using System.Collections.Generic;
using System.Linq; // Lab 4 - implementam Linq
using GestiuneFarmacie;

// Lab 5 - implementam Interfete (instantierea folosind interfata)
IStocareMedicamente adminFarmacie = new AdministrareMedicamente_FisierText();
bool ruleaza = true;

while (ruleaza)
{
    Console.WriteLine("\n=== MENIU FARMACIE ===");
    Console.WriteLine("1. Adauga medicament");
    Console.WriteLine("2. Afiseaza toate medicamentele");
    Console.WriteLine("3. Cauta medicament");
    Console.WriteLine("4. Modifica medicament ");
    Console.WriteLine("5. Sterge medicament ");
    Console.WriteLine("6. Iesire");
    Console.Write("Alege o optiune: ");

    string optiune = Console.ReadLine();

    switch (optiune)
    {
        case "1":
            // Lab 1 - implementam Tipuri de date valoare. Conversii.
            int id;
            Console.Write("Introdu ID: ");
            while (!int.TryParse(Console.ReadLine(), out id)) Console.Write("Eroare! Introdu numar: ");

            Console.Write("Introdu Nume: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Tipuri: 1=Pastile, 2=Sirop, 3=Unguent");
            Console.Write("Alege TipMedicament (1-3): ");
            TipMedicament tip = (TipMedicament)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Momente: 0=Nespecificat, 1=Dimineata, 2=Pranz, 4=Seara");
            Console.Write("Alege Moment Administrare: ");
            MomentAdministrare moment = (MomentAdministrare)Convert.ToInt32(Console.ReadLine());

            decimal pret;
            Console.Write("Introdu Pret: ");
            while (!decimal.TryParse(Console.ReadLine(), out pret)) Console.Write("Eroare! Introdu pret: ");

            int stoc;
            Console.Write("Introdu Stoc: ");
            while (!int.TryParse(Console.ReadLine(), out stoc)) Console.Write("Eroare! Introdu numar: ");

            Medicament medNou = new Medicament(id, nume, tip, moment, pret, stoc);
            adminFarmacie.AdaugaMedicament(medNou);
            Console.WriteLine("Medicament salvat cu succes in fisier!");
            break;

        case "2":
            Console.WriteLine("\n--- Lista Medicamente din Fisier ---");
            List<Medicament> toateMedicamentele = adminFarmacie.GetMedicamente();

            if (toateMedicamentele.Count == 0) Console.WriteLine("Nu exista medicamente in fisier.");
            foreach (var m in toateMedicamentele) Console.WriteLine(m.ToString());
            break;

        case "3":
            Console.Write("Introdu numele cautat: ");
            string numeCautat = Console.ReadLine();

            // Lab 4 - implementam Linq
            List<Medicament> rezultate = adminFarmacie.GetMedicamente()
                                        .Where(m => m.Nume.ToLower().Contains(numeCautat.ToLower())).ToList();

            Console.WriteLine("\n--- Rezultate Cautare ---");
            if (rezultate.Count == 0) Console.WriteLine("Nu a fost gasit niciun medicament.");
            foreach (var rezultat in rezultate) Console.WriteLine(rezultat.ToString());
            break;

        case "4":
            Console.Write("Introdu ID-ul medicamentului pe care vrei sa il modifici: ");
            int idModificare;
            while (!int.TryParse(Console.ReadLine(), out idModificare)) Console.Write("Eroare! Introdu numar valid: ");

            // Verificam daca medicamentul exista inainte sa cerem noile date
            var medicamentExistent = adminFarmacie.GetMedicamente().FirstOrDefault(m => m.Id == idModificare);
            if (medicamentExistent == null)
            {
                Console.WriteLine("Medicamentul cu acest ID nu a fost gasit!");
                break;
            }

            Console.WriteLine($"\n--- Introdu noile date pentru {medicamentExistent.Nume} ---");

            Console.Write("Nume nou: ");
            string numeNou = Console.ReadLine();

            Console.Write("TipMedicament nou (1=Pastile, 2=Sirop, 3=Unguent): ");
            TipMedicament tipNou = (TipMedicament)Convert.ToInt32(Console.ReadLine());

            Console.Write("Moment Administrare nou (0-7): ");
            MomentAdministrare momentNou = (MomentAdministrare)Convert.ToInt32(Console.ReadLine());

            decimal pretNou;
            Console.Write("Pret nou: ");
            while (!decimal.TryParse(Console.ReadLine(), out pretNou)) Console.Write("Eroare! Introdu pret: ");

            int stocNou;
            Console.Write("Stoc nou: ");
            while (!int.TryParse(Console.ReadLine(), out stocNou)) Console.Write("Eroare! Introdu numar: ");

            Medicament medActualizat = new Medicament(idModificare, numeNou, tipNou, momentNou, pretNou, stocNou);
            adminFarmacie.ModificaMedicament(medActualizat);

            Console.WriteLine("Medicamentul a fost modificat cu succes!");
            break;

        case "5":
            Console.Write("Introdu ID-ul medicamentului pe care vrei sa il stergi: ");
            int idStergere;
            while (!int.TryParse(Console.ReadLine(), out idStergere)) Console.Write("Eroare! Introdu numar valid: ");

            adminFarmacie.StergeMedicament(idStergere);
            Console.WriteLine("Daca medicamentul exista, a fost sters cu succes din fisier!");
            break;

        case "6":
            ruleaza = false;
            Console.WriteLine("La revedere!");
            break;

        default:
            Console.WriteLine("Optiune invalida!");
            break;
    }
}