using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionConstat
    {
        IDataConstat _dataConstat = new DataConstat();


       

        // Constructeur
        public GestionConstat()
        {
         
        }

        // Ajouter un nouveau constat
        public Constat AjouterConstat(Constat constat)
        {
            // Appel de la méthode AjouterConstat de DataConstat
            return _dataConstat.AjouterConstat(constat);
        }

        // Obtenir tous les constats d'une panne par son ID
        public List<Constat> ObtenirConstatsParPanneId(int panneId)
        {
            // Appel de la méthode ObtenirConstatsParPanneId de DataConstat
            return _dataConstat.ObtenirConstatsParPanneId(panneId);
        }

        // Supprimer un constat par son ID
        public void SupprimerConstat(int id)
        {
            // Appel de la méthode SupprimerConstat de DataConstat
            _dataConstat.SupprimerConstat(id);
        }
        public List<Constat> ObtenirTousLesConstats()
        {
            return _dataConstat.ObtenirConstats();
        }
    }
}
