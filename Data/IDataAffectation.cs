using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataAffectation
    {
        public void affecterMateriel(int id, int departement, string materielType);
        public List<Ordinateur> GetOrdinateur(int departement);
        public List<Imprimante> GetImprimante(int departement);
    }
}
