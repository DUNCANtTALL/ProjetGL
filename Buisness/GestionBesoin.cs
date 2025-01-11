using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionBesoin
    {
        IDataBesoin data = new DataBesion();


        public void AddBesoin(string desc)
        {
            data.AddBesoin(desc);
        }

        public List<Besion> GetBesions()
        {
            return data.GetBesions();
        }


        public void AddOrdinateur(Ordinateur ordinateur)
        {
            data.AddOrdinateur(ordinateur);
        }
        public void DeleteBesion(int id)
        {
            data.Delete(id); 
        }
        public bool status(int id)
        {
            return data.status(id);

        }
        public Besion CreateBesoin(string desc)
        {
            return data.CreateBesoin(desc);
        }
        public void AddImprimante(Imprimante imprimante)
        {
            data.AddImprimante(imprimante);
        }

        public List<Ordinateur> GetOrdinateurs(int id)
        {
            return data.GetOrdinateurs(id);
        }

        public List<Imprimante> GetImprimante(int id)
        {
            return data.GetImprimante(id);
        }
        public void Validate(int id)
        {
            data.ValidateBesion(id); 

        }
      
    }
}
