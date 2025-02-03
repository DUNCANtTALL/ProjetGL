using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataFournisseur
    {
        public void AddFournisseur(Societe fournisseur);
        public bool IsAlreadyExist(int id );
        public List<Societe> GetAllFournisseur();
        public Societe GetFournisseurById(int id);
        public void DeleteFournisseur(int id);
    }
}
