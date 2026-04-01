using System;

namespace GestionareFarmacie
{
    // Lab 4 - implementam Tipuri valoare (enumerari)
    public enum TipMedicament { Pastile = 1, Sirop = 2, Unguent = 3 }

    // Lab 4 - implementam Enumerari cu atributul Flags
    [Flags]
    public enum MomentAdministrare { Nespecificat = 0, Dimineata = 1, Pranz = 2, Seara = 4 }

    // Lab 2 - implementam lucrul cu clase in Visual C#
    public class Medicament
    {
        // Lab 4 - implementam Constante
        private const char SEPARATOR = ';';
        // Lab 2 - implementam Proprietati
        public int Id { get; set; }
        public string Nume { get; set; }
        public TipMedicament Tip { get; set; }
        public MomentAdministrare Moment { get; set; }
        public decimal Pret { get; set; }
        public int Stoc { get; set; }

        public Medicament(int id, string nume, TipMedicament tip, MomentAdministrare moment, decimal pret, int stoc)
        {
            Id = id; Nume = nume; Tip = tip; Moment = moment; Pret = pret; Stoc = stoc;
        }

        // Lab 5 - implementam Nivelul de persistenta cu stocare in fisier (citire)
        public Medicament(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR);

            Id = Convert.ToInt32(dateFisier[0]);
            Nume = dateFisier[1];
            Tip = (TipMedicament)Convert.ToInt32(dateFisier[2]);
            Moment = (MomentAdministrare)Convert.ToInt32(dateFisier[3]);
            Pret = Convert.ToDecimal(dateFisier[4]);
            Stoc = Convert.ToInt32(dateFisier[5]);
        }

        // Lab 5 - implementam Nivelul de persistenta cu stocare in fisier (scriere)
        public string ConversieLaSir_PentruFisier()
        {
            return $"{Id}{SEPARATOR}{Nume}{SEPARATOR}{(int)Tip}{SEPARATOR}{(int)Moment}{SEPARATOR}{Pret}{SEPARATOR}{Stoc}";
        }

        public override string ToString()
        {
            return $"[{Id}] {Nume} (Tip: {Tip}) [Se ia: {Moment}] - Pret: {Pret} RON | Stoc: {Stoc} buc.";
        }
    }
}