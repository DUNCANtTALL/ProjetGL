using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataBesoin
    {
        public void AddBesoin(string desc);
        public void Delete(int id);
        public Boolean status(int id );
        public List<Besion> GetBesions();
        public List<Besion> GetValidatedBesions();

        public Besion CreateBesoin(string desc); 
        public void AddImprimante(Imprimante imprimante);
        public void AddOrdinateur(Ordinateur ordinateur);

        public List<Ordinateur> GetOrdinateurs(int id);
        public List<Imprimante> GetImprimante(int id);
        public void ValidateBesion(int id); 

    }
}
