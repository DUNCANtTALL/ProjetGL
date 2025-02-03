using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionPanne
    {

        IDataPanne _dataPanne = new DataPanne();
       
        public GestionPanne()
        {
            // Initialisation de la dépendance DataPanne via l'interface IDataPanne
           
        }

        // Ajouter une nouvelle panne
        public Pannes AjouterPanne(Pannes panne)
        {
            // Appel de la méthode AjouterPanne de DataPanne
            return _dataPanne.AjouterPanne(panne);
        }

        // Obtenir une panne par son ID
        public Pannes ObtenirPanneParId(int id)
        {
            // Appel de la méthode ObtenirPanneParId de DataPanne
            return _dataPanne.ObtenirPanneParId(id);
        }

        // Obtenir toutes les pannes
        public List<Pannes> ObtenirToutesLesPannes()
        {
            // Appel de la méthode ObtenirToutesLesPannes de DataPanne
            return _dataPanne.ObtenirToutesLesPannes();
        }

        // Mettre à jour une panne existante
        public void MettreAJourPanne(Pannes panne)
        {
            // Appel de la méthode MettreAJourPanne de DataPanne
            _dataPanne.MettreAJourPanne(panne);
        }

        // Supprimer une panne par son ID
        public void SupprimerPanne(int id)
        {
            // Appel de la méthode SupprimerPanne de DataPanne
            _dataPanne.SupprimerPanne(id);
        }
    }
}
