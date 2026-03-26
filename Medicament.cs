using System;

namespace GestiuneFarmacie
{
    // -- Lab 4
    public enum TipMedicament
    {
        Pastile = 1,
        Sirop = 2,
        Unguent = 3,
    }

    // -- Lab 4
    [Flags]
    public enum MomentAdministrare
    {
        Dimineata = 1,
        Pranz = 2,
        Seara = 4
    }
    public class Medicament
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public TipMedicament Tip { get; set; }
        public MomentAdministrare Moment { get; set; }
        public decimal Pret { get; set; }
        public int Stoc { get; set; }
        public Medicament(int id, string nume, TipMedicament tip, MomentAdministrare moment, decimal pret, int stoc)
        {
            Id = id;
            Nume = nume;
            Tip = tip;
            Moment = moment;
            Pret = pret;
            Stoc = stoc;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nume} (Tip: {Tip}) [Se ia: {Moment}] - Pret: {Pret} RON | Stoc: {Stoc} buc.";
        }
    }
}