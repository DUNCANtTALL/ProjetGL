using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionMaterielle
    {
        IDataMaterielle data = new DataMaterielle();

        public List<Materielle> GetMaterielle(int id)
        {
            return data.GetAllMaterielle(id);
        }
        public void addMaterielle(Materielle materielle)
        {
            data.AddMaterielle(materielle);
        }
    }
}
