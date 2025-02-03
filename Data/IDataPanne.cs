using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataPanne
    {
        Pannes AjouterPanne(Pannes panne);
        Pannes ObtenirPanneParId(int id);
        List<Pannes> ObtenirToutesLesPannes();
        void MettreAJourPanne(Pannes panne);
        void SupprimerPanne(int id);
    }
}
