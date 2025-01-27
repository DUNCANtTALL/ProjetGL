using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataCommande
    {
        List<Commande> GetAllCommande();
        List<Commande> GetValidateCommande();
 
        int  AddCommande(Commande commande);
        void DeleteCommande(DateTime dateCommande);
        void ValidateCommande(int id );
        public void AddImprimante(Imprimante imprimante);
        public void AddOrdinateur(Ordinateur ordinateur);
        public List<Ordinateur> GetOrdinateurs(int id);
        public List<Imprimante> GetImprimante(int id);
        public Commande GetCommande(int id);
        public Commande GetCommande(int id,DateTime date );




    }
}
