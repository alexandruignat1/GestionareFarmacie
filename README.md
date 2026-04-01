<div align="center">

# Aplicatie de Gestiune a unei Farmacii

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET 8.0](https://img.shields.io/badge/.NET_8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)]()

*Proiect modular pentru digitalizarea si eficientizarea stocurilor de medicamente.*

---
</div>

## Descrierea Proiectului
Aplicatia este dezvoltata in C# si are ca scop gestionarea inventarului unei farmacii. Proiectul este construit folosind o arhitectura decuplata pe 3 niveluri (N-Tier Architecture), separand interfata utilizatorului de modelele de date si de logica de salvare. Aceasta ofera operatiuni complete de tip CRUD, cu persistenta datelor in fisiere text.

## Functionalitati Curente
* **Operatiuni CRUD complete:** Adaugare, afisare, modificare si stergere de medicamente, cu salvare automata in fisier pe hard disk.
* **Cautare inteligenta:** Filtrarea rapida a medicamentelor dupa nume folosind interogari LINQ.
* **Gestiunea entitatilor multiple:** Sistemul este scalabil, avand modele definite atat pentru Medicamente, cat si pentru Farmacisti.
* **Optiuni multiple (Flags):** Utilizarea enumerarilor pentru a permite selectarea simultana a mai multor momente de administrare.
* **Siguranta si validare:** Tratarea exceptiilor (try-catch) si validarea datelor introduse de utilizator pentru a preveni inchiderea accidentala a aplicatiei.
* **Configurari externe:** Numele fisierului folosit ca baza de date este citit dinamic din fisierul extern `App.config`.

## Functionalitati Viitoare (In dezvoltare)
Pe parcursul dezvoltarii proiectului, vor fi implementate urmatoarele functionalitati:
* **Sortarea listei:** Afisarea medicamentelor ordonate alfabetic dupa nume, crescator dupa pret sau dupa cantitatea din stoc.
* **Integrare Baze de Date (SQL):** Adaugarea unui nou nivel de stocare care sa comunice cu o baza de date reala, inlocuind fisierul text, dar folosind aceeasi interfata.
* **Interfata Grafica (GUI):** Migrarea de la aplicatia de tip consola la o aplicatie cu o interfata vizuala moderna (ferestre, tabele, butoane).

## Arhitectura si Structura Proiectului
Solutia este impartita in 3 proiecte separate pentru o organizare profesionala a codului:

### 1. GestionareFarmacie (Proiect Consola)
* Reprezinta interfata cu utilizatorul.
* Contine `Program.cs` - meniul interactiv, comunicarea cu utilizatorul si afisarea datelor in consola.
* Contine fisierul `App.config` pentru setarile generale ale aplicatiei.

### 2. LibrarieModele (Class Library)
* Reprezinta "depozitul" cu datele si entitatile aplicatiei.
* Contine `Medicament.cs` si `Farmacist.cs` - modelele obiectelor, enumerarile aferente si metodele de formatare a textului pentru salvarea in fisiere.

### 3. NivelStocareDate (Class Library)
* Reprezinta logica de business si persistenta datelor.
* Contine interfata `IStocareMedicamente.cs` - contractul obligatoriu pentru operatiunile cu baza de date.
* Contine `AdministrareMedicamente_FisierText.cs` - clasa responsabila exclusiv cu scrierea, citirea, modificarea si stergerea liniilor din fisierul text, in conditii de siguranta.
