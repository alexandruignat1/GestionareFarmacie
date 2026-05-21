using System.Collections.Generic;

namespace GestionareFarmacie
{
    public interface IStocareFarmacisti
    {
        void AdaugaFarmacist(Farmacist f);
        List<Farmacist> GetFarmacisti();
        void ModificaFarmacist(Farmacist f);
        void StergeFarmacist(int idFarmacist);
    }
}