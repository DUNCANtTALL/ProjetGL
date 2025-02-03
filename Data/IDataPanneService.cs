using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataPanneService
    {
        Pannes SignalerPanne(Pannes panne);
        List<Pannes> ListerPannes();
        Pannes ConsulterPanne(int id);
        void AjouterConstat(int panneId, Constat constat);
        void CloturerPanne(int panneId);

    }
}
