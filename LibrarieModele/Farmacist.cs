using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestionareFarmacie
{
    public class Farmacist : INotifyPropertyChanged, IDataErrorInfo
    {
        private const char SEPARATOR = ';';

        private int id;
        private string? nume;
        private string? email;
        private string? parola;
        private bool esteAdmin;

        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        public string? Nume { get => nume; set { nume = value; OnPropertyChanged(); } }
        public string? Email { get => email; set { email = value; OnPropertyChanged(); } }
        public string? Parola { get => parola; set { parola = value; OnPropertyChanged(); } }
        public bool EsteAdmin { get => esteAdmin; set { esteAdmin = value; OnPropertyChanged(); } }

        public Farmacist() { }

        public Farmacist(int id, string nume, string email, string parola, bool esteAdmin)
        {
            Id = id; Nume = nume; Email = email; Parola = parola; EsteAdmin = esteAdmin;
        }

        // CITIREA
        public Farmacist(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR);
            Id = Convert.ToInt32(dateFisier[0]);
            Nume = dateFisier[1];

            if (dateFisier.Length > 3)
            {
                Email = dateFisier[2];
                Parola = dateFisier[3];
                // Citim statusul de admin (dacă fișierul e vechi și n-are, punem false implicit)
                EsteAdmin = dateFisier.Length > 4 && Convert.ToBoolean(dateFisier[4]);
            }
            else
            {
                Email = "nesetat@farmacie.ro";
                Parola = "1234";
                EsteAdmin = false;
            }
        }

        // SALVAREA
        public string ConversieLaSir_PentruFisier()
        {
            return $"{Id}{SEPARATOR}{Nume}{SEPARATOR}{Email}{SEPARATOR}{Parola}{SEPARATOR}{EsteAdmin}";
        }

        // VALIDARE DATE
        public string Error => null!;

        public string this[string columnName]
        {
            get
            {
                string result = null!;
                switch (columnName)
                {
                    case nameof(Nume):
                        if (string.IsNullOrWhiteSpace(Nume)) result = "Numele este obligatoriu!";
                        break;
                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(Email)) result = "E-mailul este obligatoriu!";
                        else if (!Email.Contains("@") || !Email.Contains(".")) result = "Format de e-mail invalid!";
                        break;
                    case nameof(Parola):
                        if (string.IsNullOrWhiteSpace(Parola)) result = "Parola este obligatorie!";
                        else if (Parola.Length < 4) result = "Parola trebuie minim 4 caractere!";
                        break;
                }
                return result;
            }
        }

        public bool EsteValid => string.IsNullOrEmpty(this[nameof(Nume)]) &&
                                 string.IsNullOrEmpty(this[nameof(Email)]) &&
                                 string.IsNullOrEmpty(this[nameof(Parola)]);

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}