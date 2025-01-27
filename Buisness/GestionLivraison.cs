using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionLivraison
    {
        IDataLivrason data = new DataLivraison();

        public Livraison GetLivraison()
        {
            return data.GetLivraison();
        }
        public void validateOrdinateur(int id)
        {
            data.validateOrdinateur(id);
        }
        public void validateImprimante(int id)
        {
            data.validateImprimante(id);
        }
    }
}
