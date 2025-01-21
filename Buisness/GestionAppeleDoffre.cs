using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionAppeleDoffre
    {
        IDataAppeleDoffreAp data = new DataAppelDoffre();

        public List<AppelD_offre> GetAppeleDoffres()
        {
            return data.GetAllAppelDoffre();
        }
        public void addAppeleDoffre(AppelD_offre appeleDoffre)
        {
            data.AddAppelDoffre(appeleDoffre);
        }
        public void DeleteAppeleDoffre(DateTime dateDebut)
        {
            data.DeleteAppelDoffre(dateDebut);
        }
        public AppelD_offre GetAppel(int id )
        {
            return data.GetAppelD_Offre(id); 
        }
    }
}
