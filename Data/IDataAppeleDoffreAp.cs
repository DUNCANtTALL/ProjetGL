using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataAppeleDoffreAp
    {
        List<AppelD_offre> GetAllAppelDoffre();
        void AddAppelDoffre(AppelD_offre appelDoffre);
        void DeleteAppelDoffre(DateTime dateDebut);
        AppelD_offre GetAppelD_Offre(int id); 
    }
}
