using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataCommande
    {
        List<Commande> GetAllCommande();
        void AddCommande(Commande commande);
        void DeleteCommande(DateTime dateCommande);
    }
}
