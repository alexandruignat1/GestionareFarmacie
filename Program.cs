using System;
using System.Collections.Generic;
using GestiuneFarmacie;

Inventar inv = new Inventar();
bool ruleaza = true;

while (ruleaza)
{
    Console.WriteLine("\n=== MENIU FARMACIE ===");
    Console.WriteLine("1. Adauga medicament nou");
    Console.WriteLine("2. Afiseaza toate medicamentele");
    Console.WriteLine("3. Cauta medicament ");//Lab3&4
    Console.WriteLine("4. Iesire");
    Console.Write("Alege o optiune: ");

    string optiune = Console.ReadLine();

    switch (optiune)
    {
        case "1":
            int id;
            Console.Write("Introdu ID: ");
            while (!int.TryParse(Console.ReadLine(), out id)) Console.Write("Eroare! Introdu numar: ");

            Console.Write("Introdu Nume: ");
            string nume = Console.ReadLine();

            // -- Lab 4: Citire optiuni din Enumerari --
            Console.WriteLine("Tipuri: 1=Pastile, 2=Sirop, 3=Unguent");
            Console.Write("Alege Tip: ");
            TipMedicament tip = (TipMedicament)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Administrare: 1=Dimineata, 2=Pranz, 4=Seara");
            Console.WriteLine("(Daca se ia Dimineata si Seara, aduna 1+4. Scrie 5)");
            Console.Write("Alege Moment Administrare: ");
            MomentAdministrare moment = (MomentAdministrare)Convert.ToInt32(Console.ReadLine());
 
            decimal pret;
            Console.Write("Introdu Pret (in RON): ");
            while (!decimal.TryParse(Console.ReadLine(), out pret)) Console.Write("Eroare! Introdu pret: ");

            int stoc;
            Console.Write("Introdu Stoc (buc.): ");
            while (!int.TryParse(Console.ReadLine(), out stoc)) Console.Write("Eroare! Introdu numar: ");

            Medicament medNou = new Medicament(id, nume, tip, moment, pret, stoc);
            inv.AdaugaMedicament(medNou);
            break;

        case "2":
            Console.WriteLine("\n--- Lista Medicamente ---");
            inv.AfiseazaMedicamente();
            break;

        case "3":
            // -- Lab 3: Testare functie de cautare --
            Console.Write("Introdu numele cautat: ");
            string numeCautat = Console.ReadLine();

            List<Medicament> rezultate = inv.CautaDupaNume(numeCautat);

            Console.WriteLine("\n--- Rezultate Cautare ---");
            if (rezultate.Count == 0) Console.WriteLine("Nu a fost gasit niciun medicament.");
            foreach (var rezultat in rezultate) Console.WriteLine(rezultat.ToString());
            break;

        case "4":
            ruleaza = false;
            Console.WriteLine("Terminare Program");
            break;

        default:
            Console.WriteLine("Optiune invalida!");
            break;
    }
}