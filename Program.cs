using System;
using GestiuneFarmacie;

Console.WriteLine("=== Bine ai venit la Gestiune Farmacie ===");

Inventar inventarulMeu = new Inventar();

Medicament paracetamol = new Medicament(1, "Paracetamol", "Analgezice", 15.50m, 100);
Medicament nurofen = new Medicament(2, "Nurofen", "Răceală", 32.00m, 50);

inventarulMeu.AdaugaMedicament(paracetamol);
inventarulMeu.AdaugaMedicament(nurofen);

inventarulMeu.AfiseazaMedicamente(); ;