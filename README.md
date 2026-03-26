<div align="center">

# Aplicatie de Gestiune a unei Farmacii

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET 8.0](https://img.shields.io/badge/.NET_8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)]()

*Proiect pentru digitalizarea si eficientizarea stocurilor de medicamente.*

---
</div>

## Descrierea Proiectului
Aplicatia este dezvoltata in C# si are ca scop gestionarea inventarului unei farmacii direct din linia de comanda (Console App). Aceasta ofera un control riguros asupra produselor, permitand operatiuni de baza asupra stocului.

## Functionalitati Curente
* **Adaugare medicament:** Introducerea unui produs nou in sistem, cu validarea datelor pentru a preveni erorile de tastare (ID, Nume, Tip, Moment de administrare, Pret, Stoc).
* **Afisare inventar:** Vizualizarea tuturor medicamentelor inregistrate in memorie la un moment dat.
* **Cautare medicament:** Gasirea rapida a medicamentelor prin introducerea unei parti din nume, folosind interogari LINQ.
* **Gestiunea optiunilor multiple:** Utilizarea enumerarilor cu atributul Flags pentru a permite selectarea mai multor momente de administrare simultan (ex: Dimineata si Seara).

## Functionalitati Viitoare (In dezvoltare)
Pe parcursul dezvoltarii proiectului, este posibil sa fie implementate urmatoarele functionalitati:
* **Modificarea datelor:** Actualizarea informatiilor unui medicament existent (ex: schimbarea pretului sau actualizarea stocului).
* **Stergerea unui medicament:** Eliminarea completa a unui produs din inventar.
* **Sortarea listei:** Afisarea medicamentelor ordonate dupa nume, pret sau cantitatea din stoc.

## Structura Proiectului
Codul este modularizat pentru o mai buna organizare:
* `Program.cs` - Punctul de intrare in aplicatie si meniul interactiv pentru utilizator.
* `Medicament.cs` - Definirea modelului de date si a enumerarilor (`TipMedicament`, `MomentAdministrare`).
* `Inventar.cs` - Clasa responsabila cu logica de business (salvarea in lista generica, afisarea si filtrarea datelor).

