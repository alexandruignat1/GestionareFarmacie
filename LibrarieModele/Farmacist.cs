namespace GestionareFarmacie
{
    // Lab 5 - implementam o a doua entitate
    public class Farmacist
    {
        private const char SEPARATOR = ';';
        public int Id { get; set; }
        public string Nume { get; set; }

        public Farmacist(int id, string nume) { Id = id; Nume = nume; }

        public Farmacist(string linieFisier)
        {
            string[] date = linieFisier.Split(SEPARATOR);
            Id = int.Parse(date[0]);
            Nume = date[1];
        }

        public string ConversieLaSir_PentruFisier() => $"{Id}{SEPARATOR}{Nume}";
        public override string ToString() => $"[Farmacist ID: {Id}] Nume: {Nume}";
    }
}