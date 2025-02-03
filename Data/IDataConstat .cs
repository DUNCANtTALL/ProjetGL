using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataConstat
    {
        Constat AjouterConstat(Constat constat);
        List<Constat> ObtenirConstatsParPanneId(int panneId);
        void SupprimerConstat(int id);
        public List<Constat> ObtenirConstats(); 

    }
}
