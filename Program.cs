using System;
using GestiuneFarmacie;

Inventar inventarulMeu = new Inventar();
bool ruleaza = true;

while (ruleaza)
{
    Console.WriteLine("\n=== MENIU FARMACIE ===");
    Console.WriteLine("1. Adauga medicament nou");
    Console.WriteLine("2. Afiseaza toate medicamentele");
    Console.WriteLine("3. Iesire");
    Console.Write("Alege o optiune: ");

    string optiune = Console.ReadLine();

    switch (optiune)
    {
        case "1":
            // 1. Citirea securizata pentru ID
            int id;
            Console.Write("Introdu ID (numar intreg): ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Eroare! Te rog introdu un numar valid pentru ID: ");
            }

            Console.Write("Introdu Nume: ");
            string nume = Console.ReadLine();

            Console.Write("Introdu Categorie: ");
            string categorie = Console.ReadLine();

            // 2. Citirea securizata pentru Pret
            decimal pret;
            Console.Write("Introdu Pret: ");
            while (!decimal.TryParse(Console.ReadLine(), out pret))
            {
                Console.Write("Eroare! Te rog introdu un numar valid pentru pret: ");
            }

            // 3. Citirea securizata pentru Stoc
            int stoc;
            Console.Write("Introdu Stoc (numar intreg): ");
            while (!int.TryParse(Console.ReadLine(), out stoc))
            {
                Console.Write("Eroare! Te rog introdu un numar valid pentru stoc: ");
            }

            // Cream medicamentul cu datele citite si il adaugam
            Medicament medNou = new Medicament(id, nume, categorie, pret, stoc);
            inventarulMeu.AdaugaMedicament(medNou);
            break;

        case "2":
            inventarulMeu.AfiseazaMedicamente();
            break;

        case "3":
            ruleaza = false;
            Console.WriteLine("La revedere!");
            break;

        default:
            Console.WriteLine("Optiune invalida! Incearca din nou.");
            break;
    }
}