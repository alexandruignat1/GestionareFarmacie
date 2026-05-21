using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestionareFarmacie
{
    public enum TipMedicament { Pastile = 1, Sirop = 2, Unguent = 3 }

    [Flags]
    public enum MomentAdministrare { Nespecificat = 0, Dimineata = 1, Pranz = 2, Seara = 4 }

    // Implementăm INotifyPropertyChanged și IDataErrorInfo (Lab 10 & 11)
    public class Medicament : INotifyPropertyChanged, IDataErrorInfo
    {
        private const char SEPARATOR = ';';

        private int id;
        private string? nume;
        private TipMedicament tip;
        private MomentAdministrare moment;
        private decimal pret;
        private int stoc;
        private DateTime dataExpirarii;

        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        public string? Nume { get => nume; set { nume = value; OnPropertyChanged(); } }
        public TipMedicament Tip { get => tip; set { tip = value; OnPropertyChanged(); } }
        public MomentAdministrare Moment { get => moment; set { moment = value; OnPropertyChanged(); } }
        public decimal Pret { get => pret; set { pret = value; OnPropertyChanged(); } }
        public int Stoc { get => stoc; set { stoc = value; OnPropertyChanged(); } }
        public DateTime DataExpirarii { get => dataExpirarii; set { dataExpirarii = value; OnPropertyChanged(); } }

        public Medicament()
        {
            DataExpirarii = DateTime.Now.AddYears(1);
        }

        public Medicament(int id, string nume, TipMedicament tip, MomentAdministrare moment, decimal pret, int stoc, DateTime dataExpirarii)
        {
            Id = id; Nume = nume; Tip = tip; Moment = moment; Pret = pret; Stoc = stoc; DataExpirarii = dataExpirarii;
        }

        public Medicament(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR);
            Id = Convert.ToInt32(dateFisier[0]);
            Nume = dateFisier[1];
            Tip = (TipMedicament)Convert.ToInt32(dateFisier[2]);
            Moment = (MomentAdministrare)Convert.ToInt32(dateFisier[3]);
            Pret = Convert.ToDecimal(dateFisier[4]);
            Stoc = Convert.ToInt32(dateFisier[5]);
            DataExpirarii = DateTime.Now.AddYears(1);
        }

        public string ConversieLaSir_PentruFisier()
        {
            return $"{Id}{SEPARATOR}{Nume}{SEPARATOR}{(int)Tip}{SEPARATOR}{(int)Moment}{SEPARATOR}{Pret}{SEPARATOR}{Stoc}";
        }

        // ==========================================
        // VALIDARE DATE: IDataErrorInfo (Lab 11)
        // ==========================================
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
                        else if (Nume.Length > 30) result = "Numele nu poate depăși 30 caractere!";
                        break;
                    case nameof(Pret):
                        if (Pret <= 0) result = "Prețul trebuie să fie strict pozitiv!";
                        break;
                    case nameof(Stoc):
                        if (Stoc < 0) result = "Stocul nu poate fi negativ!";
                        break;
                }
                return result;
            }
        }

        // Verifică dacă obiectul are vreo eroare
        public bool EsteValid => string.IsNullOrEmpty(this[nameof(Nume)]) &&
                                 string.IsNullOrEmpty(this[nameof(Pret)]) &&
                                 string.IsNullOrEmpty(this[nameof(Stoc)]);

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