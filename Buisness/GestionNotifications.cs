using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionNotifications
    {
        IDataNotification data = new DataNotification();

        public List<Notifications> GetNotifications()
        {
            return data.GetAllNotification();
        }
        public void addNotification(Notifications notification)
        {
            data.AddNotification(notification);
        }
    }
}
