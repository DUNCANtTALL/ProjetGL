using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataMaterielle
    {
        List<Materielle> GetAllMaterielle(int commande);
        void AddMaterielle(Materielle materielle);
    }
}
