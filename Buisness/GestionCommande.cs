using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionCommande
    {
        IDataCommande data = new DataCommande();


        public List<Commande> GetAllCommande()
        {
            return data.GetAllCommande();
        }
        
        public int  addCommande(Commande commande)
        {
          return  data.AddCommande(commande);
        }
        public Commande GetCommande(int id)
        {
            return data.GetCommande(id);
        }
        public void deleteCommande(DateTime dateCommande)
        {
            data.DeleteCommande(dateCommande);
        }
        public List<Commande> GetValidateCommande()
        {
            return data.GetValidateCommande();
        }
        public void validateCommande(int id)
        {
            data.ValidateCommande(id);
        }
        public void addImprimante(Imprimante imprimante)
        {
            data.AddImprimante(imprimante);
        }
        public void addOrdinateur(Ordinateur ordinateur)
        {
            data.AddOrdinateur(ordinateur);
        }
        public List<Ordinateur> GetOrdinateurs(int id)
        {
            return data.GetOrdinateurs(id);
        }
        public List<Imprimante> GetImprimantes(int id)
        {
            return data.GetImprimante(id);
        }
        public Commande GetCommande(int id, DateTime date)
        {
            return data.GetCommande(id, date);
        }
    }
}
