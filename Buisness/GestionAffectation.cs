using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionAffectation
    {
        IDataAffectation data = new DataAffectaion(); 
        public void affecterMateriel(int id, int departement, string materielType)
        {
            data.affecterMateriel(id, departement, materielType);

        }
        public List<Imprimante> GetImprimante(int departement)
        {
            return data.GetImprimante(departement);
        }
        public List<Ordinateur> GetOrdinateur(int departement)
        {
            return data.GetOrdinateur(departement);
        }






    }
}
