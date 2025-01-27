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
        public AppelD_offre GetAppel(DateTime date)
        {
            return data.GetAppelD_Offre(date);
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
        public List<Imprimante> GetImprimante(int id)
        {
            return data.GetImprimante(id);
        }

    }
}
