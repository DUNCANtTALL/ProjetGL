using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataFournisseur
    {
        public void AddFournisseur(Societe fournisseur);
        public List<Societe> GetAllFournisseur();
        public Societe GetFournisseurById(int id);
        public void DeleteFournisseur(int id);
    }
}
