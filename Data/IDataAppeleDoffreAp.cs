using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataAppeleDoffreAp
    {
        List<AppelD_offre> GetAllAppelDoffre();
        void AddAppelDoffre(AppelD_offre appelDoffre);
        void DeleteAppelDoffre(int id);
        AppelD_offre FindAppelOffre(int id);
        void UpdateAppelDoffre(int id, string titre, DateTime dateDebut, DateTime dateFin, string description);
        AppelD_offre GetAppelD_Offre(int id);
        AppelD_offre GetAppelD_Offre(DateTime date);

        public void AddImprimante(Imprimante imprimante);
        public void AddOrdinateur(Ordinateur ordinateur);
        public List<Ordinateur> GetOrdinateurs(int id);
        public List<Imprimante> GetImprimante(int id);



    }
}
