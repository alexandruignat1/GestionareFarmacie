namespace GestiuneFarmacie
{
    public class Medicament
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Categorie { get; set; } 
        public decimal Pret { get; set; }
        public int Stoc { get; set; }

        public Medicament(int id, string nume, string categorie, decimal pret, int stoc)
        {
            Id = id;
            Nume = nume;
            Categorie = categorie;
            Pret = pret;
            Stoc = stoc;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nume} ({Categorie}) - Pret: {Pret} RON | Stoc: {Stoc} buc.";
        }
    }
}