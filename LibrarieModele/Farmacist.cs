using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestionareFarmacie
{
    // Adăugăm interfețele pentru Data Binding și Validare
    public class Farmacist : INotifyPropertyChanged, IDataErrorInfo
    {
        private const char SEPARATOR = ';';

        private int id;
        private string? nume;

        public int Id
        {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }

        public string? Nume
        {
            get => nume;
            set { nume = value; OnPropertyChanged(); }
        }

        public Farmacist() { }

        public Farmacist(int id, string nume)
        {
            Id = id;
            Nume = nume;
        }

        public Farmacist(string linieFisier)
        {
            string[] date = linieFisier.Split(SEPARATOR);
            Id = int.Parse(date[0]);
            Nume = date[1];
        }

        public string ConversieLaSir_PentruFisier() => $"{Id}{SEPARATOR}{Nume}";

        public override string ToString() => $"[Farmacist ID: {Id}] Nume: {Nume}";

        // ==========================================
        // VALIDARE DATE: IDataErrorInfo
        // ==========================================
        public string Error => null!;

        public string this[string columnName]
        {
            get
            {
                string result = null!;
                if (columnName == nameof(Nume))
                {
                    if (string.IsNullOrWhiteSpace(Nume))
                        result = "Numele farmacistului este obligatoriu!";
                }
                return result;
            }
        }

        public bool EsteValid => string.IsNullOrEmpty(this[nameof(Nume)]);

        // ==========================================
        // NOTIFICARE INTERFAȚĂ: INotifyPropertyChanged
        // ==========================================
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}