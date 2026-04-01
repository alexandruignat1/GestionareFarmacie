<div align="center">

# Aplicatie de Gestiune a unei Farmacii

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET 8.0](https://img.shields.io/badge/.NET_8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)]()

*Proiect pentru digitalizarea si eficientizarea stocurilor de medicamente.*

---
</div>

## Descrierea Proiectului
Aplicatia este dezvoltata in C# si are ca scop gestionarea inventarului unei farmacii direct din linia de comanda (Console App). Aceasta ofera un control riguros asupra produselor, permitand operatiuni complete de tip CRUD (Create, Read, Update, Delete) asupra inventarului, avand implementata si persistenta datelor.

## Functionalitati Curente
* **Adaugare medicament:** Introducerea unui produs nou in sistem, cu salvare automata in fisier text.
* **Afisare inventar:** Citirea si vizualizarea tuturor medicamentelor inregistrate in fisierul de pe hard disk.
* **Cautare medicament:** Gasirea rapida a medicamentelor prin introducerea unei parti din nume, folosind interogari LINQ.
* **Modificare medicament:** Actualizarea tuturor datelor unui produs existent direct in baza de date (fisier).
* **Stergere medicament:** Eliminarea completa a unui medicament din sistem pe baza ID-ului.
* **Gestiunea optiunilor multiple:** Utilizarea enumerarilor cu atributul Flags pentru a permite selectarea mai multor momente de administrare simultan (ex: Dimineata si Seara).

## Functionalitati Viitoare (In dezvoltare)
Pe parcursul dezvoltarii proiectului, vor fi implementate urmatoarele functionalitati:
* **Sortarea listei:** Afisarea medicamentelor ordonate alfabetic dupa nume, crescator dupa pret sau dupa cantitatea ramasa in stoc.
* **Integrare Baze de Date (SQL):** Extinderea aplicatiei prin adaugarea unei noi clase de stocare care sa comunice cu o baza de date reala, folosind aceeasi interfata.
* **Interfata Grafica (GUI):** Trecerea de la o aplicatie de tip consola la o aplicatie cu o interfata vizuala moderna (ferestre, butoane, tabele).

## Structura Proiectului
Codul este decuplat si modularizat pentru o mai buna organizare:
* `Program.cs` - Punctul de intrare in aplicatie si meniul interactiv pentru utilizator.
* `Medicament.cs` - Definirea modelului de date, a enumerarilor si a functiilor de pregatire a textului pentru fisier.
* `IStocareMedicamente.cs` - Interfata (contractul) care defineste setul obligatoriu de functii pentru gestionarea bazei de date.
* `AdministrareMedicamente_FisierText.cs` - Clasa responsabila cu logica tehnica (citire, scriere, editare, stergere) din fisierul text.