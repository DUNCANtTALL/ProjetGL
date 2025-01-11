using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataNotification
    {
        List<Notifications> GetAllNotification();
        void AddNotification(Notifications notification);
    }
}
