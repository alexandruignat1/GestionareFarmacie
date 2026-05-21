<div align="center">

# Aplicație de Gestiune a unei Farmacii

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET 8.0](https://img.shields.io/badge/.NET_8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)]()
[![WPF](https://img.shields.io/badge/WPF-UI-blue?style=for-the-badge)]()

*Proiect modular pentru digitalizarea și eficientizarea stocurilor de medicamente.*

---
</div>

## Descrierea Proiectului
Aplicația este dezvoltată în C# și are ca scop gestionarea inventarului și a personalului unei farmacii. Proiectul a fost refactorizat dintr-o aplicație consolă într-o aplicație desktop modernă, utilizând tehnologia **WPF (Windows Presentation Foundation)**. Este construit folosind o arhitectură decuplată pe 3 niveluri , separând interfața utilizatorului de modelele de date și de logica de salvare, integrând totodată concepte de bază **MVVM**.

## Funcționalități Curente
* **Interfață Grafică (GUI) Modernă:** Implementată în WPF, având o temă cromatică unitară și elemente de design optimizate (butoane de dimensiuni reduse pentru o încadrare și vizibilitate perfectă în fereastră). Navigarea este organizată eficient prin intermediul unui `TabControl`.
* **Data Binding & MVVM-lite:** Sincronizare automată și bidirecțională între interfața vizuală (XAML) și datele din cod folosind `INotifyPropertyChanged` și `ObservableCollection`.
* **Validare Inteligentă a Datelor:** Implementarea interfeței `IDataErrorInfo` direct în clasele model pentru a valida automat intrările utilizatorului. Oferă feedback vizual nativ (chenare roșii) direct în formular.
* **Operațiuni CRUD complete:** Adăugare, afișare, modificare și ștergere pentru două entități distincte (`Medicament` și `Farmacist`), cu salvare automată în fișiere text dedicate.
* **Căutare inteligentă:** Filtrarea rapidă a înregistrărilor după nume folosind interogări LINQ, cu actualizarea instantanee a tabelelor (`DataGrid`).
* **Opțiuni multiple (Flags):** Utilizarea enumerărilor cu atributul `[Flags]` pentru a permite selectarea simultană a mai multor momente de administrare prin `CheckBox`-uri.


## Arhitectura și Structura Proiectului
Soluția este împărțită în 3 proiecte separate pentru o organizare profesională a codului:

### 1. GestionareFarmacie.WPF (Proiect UI)
* Reprezintă interfața grafică cu utilizatorul.
* Conține ferestrele XAML și logica de interacțiune, folosind mecanisme de Data Binding pentru a comunica fluid cu restul aplicației, înlocuind vechea consolă.

### 2. LibrarieModele (Class Library)
* Reprezintă "depozitul" cu datele și entitățile aplicației.
* Conține `Medicament.cs` și `Farmacist.cs` - modelele obiectelor îmbogățite cu reguli de validare, enumerările aferente și metodele de conversie a datelor.

### 3. NivelStocareDate (Class Library)
* Reprezintă logica de business și persistența datelor.
* Conține interfețele (`IStocareMedicamente`, `IStocareFarmacisti`) care reprezintă contractul obligatoriu pentru operațiunile cu baza de date.
* Conține clasele responsabile exclusiv cu scrierea, citirea, modificarea și ștergerea liniilor din fișierele text, în condiții de siguranță.
