<div align="center">

# Aplicație de Gestiune a unei Farmacii

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET 8.0](https://img.shields.io/badge/.NET_8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)]()
[![WPF](https://img.shields.io/badge/WPF-UI-blue?style=for-the-badge)]()

*Proiect modular pentru digitalizarea stocurilor de medicamente și administrarea personalului.*

---
</div>

## Descrierea Proiectului
Aplicația este dezvoltată în C# și are ca scop gestionarea inventarului și a resurselor umane din cadrul unei farmacii. Proiectul a fost refactorizat dintr-o aplicație consolă într-o aplicație desktop modernă, utilizând tehnologia **WPF (Windows Presentation Foundation)**. Arhitectura este decuplată pe 3 niveluri (N-Tier), separând strict interfața utilizatorului de modelele de date și de logica de persistență, integrând totodată concepte fundamentale **MVVM**.

## Funcționalități Curente
* **Securitate și Controlul Accesului (RBAC):** Sistem de autentificare integrat cu recuperare de parolă. Aplicația implementează privilegii diferențiate (Administrator vs. Farmacist standard), adaptând dinamic interfața grafică și ascunzând modulele sensibile pentru utilizatorii fără drepturi.
* **Interfață Grafică (GUI) Modernă:** Implementată în WPF, având o temă cromatică unitară și elemente de design optimizate (butoane de dimensiuni reduse pentru o încadrare și vizibilitate perfectă în fereastră). Navigarea este organizată eficient prin intermediul unui `TabControl`.
* **Data Binding & MVVM-lite:** Sincronizare automată și bidirecțională între interfața vizuală (XAML) și datele din cod folosind `INotifyPropertyChanged` și `ObservableCollection`.
* **Validare Inteligentă a Datelor:** Implementarea interfeței `IDataErrorInfo` direct în clasele model pentru a valida automat intrările utilizatorului (ex: interzicerea datelor calendaristice din trecut). Oferă feedback vizual nativ (chenare roșii) direct în formular.
* **Operațiuni CRUD complete:** Adăugare, afișare, modificare și ștergere pentru două entități distincte (`Medicament` și `Farmacist`), cu salvare automată în fișiere text dedicate.
* **Căutare inteligentă:** Filtrarea rapidă a înregistrărilor după nume folosind interogări LINQ, cu actualizarea instantanee a tabelelor (`DataGrid`).
* **Opțiuni multiple (Flags):** Utilizarea enumerărilor cu atributul `[Flags]` pentru a permite selectarea simultană a mai multor momente de administrare prin `CheckBox`-uri.

## Arhitectura și Structura Proiectului
Soluția este împărțită în 3 proiecte separate pentru o organizare profesională a codului:

### 1. GestionareFarmacie.WPF (Proiect UI)
* Reprezintă interfața grafică cu utilizatorul (Presentation Layer).
* Conține ferestrele XAML și logica de interacțiune, folosind mecanisme de Data Binding pentru a comunica fluid cu restul aplicației, înlocuind vechea consolă.

### 2. LibrarieModele (Class Library)
* Reprezintă "depozitul" cu datele și entitățile aplicației (Domain Model).
* Conține `Medicament.cs` și `Farmacist.cs` - modelele obiectelor îmbogățite cu reguli de validare, enumerările aferente și metodele de conversie a datelor.

### 3. NivelStocareDate (Class Library)
* Reprezintă logica de business și persistența datelor (Data Access Layer).
* Conține interfețele (`IStocareMedicamente`, `IStocareFarmacisti`) care reprezintă contractul obligatoriu pentru operațiunile cu baza de date.
* Conține clasele responsabile exclusiv cu scrierea, citirea, modificarea și ștergerea liniilor din fișierele text, incluzând protecție pentru compatibilitate retroactivă la citirea datelor vechi.

## Instrucțiuni de Testare
Pentru evaluarea completă a funcționalităților de administrare, asigurați-vă că fișierul `Farmacisti.txt` (localizat în folderul `bin\Release\net8.0-windows` sau `bin\Debug\net8.0-windows`) conține un cont cu flag-ul de Administrator setat pe `True`.

Exemplu de format valid pentru un cont de Administrator:
`1;NumeAdmin;admin@farmacie.ro;1234;True`

## Capturi de Ecran

### 1. Fereastra de Autentificare
![Autentificare](<img width="385" height="444" alt="Autentificare" src="https://github.com/user-attachments/assets/e3e5c5c3-3b11-4322-94c5-f22d231dd650" />
)

### 2. Gestiune Medicamente (Interfață și Validare)
![Gestiune Medicamente](<img width="1052" height="618" alt="Interfata Validare" src="https://github.com/user-attachments/assets/129b349a-198c-4e05-870c-0773a92fb726" />
)

### 3. Panou Administrator (Gestiune Personal)
![Admin Panel](<img width="1034" height="590" alt="Admin" src="https://github.com/user-attachments/assets/2dc7c2e1-fc2e-4324-8fc9-c167069da70a" />
)
