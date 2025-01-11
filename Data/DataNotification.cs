using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataNotification: IDataNotification
    {
        SqlConnection connection;
        SqlCommand Command;
        public DataNotification()
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-6QJ1K1I;Initial Catalog=ProjetGL;Integrated Security=True");
            Command = new SqlCommand();
            Command.Connection = connection;

        }
        public List<Notifications> GetAllNotification()
        {
            List<Notifications> notifications = new List<Notifications>();
            Command.CommandText = "select * from Notifications";
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Notifications notification = new Notifications
                (
                reader.GetDateTime(2),
                  reader.GetString(3),
                     reader.GetString(1)
                );
                notifications.Add(notification);
            }
            return notifications;
        }

        public void AddNotification(Notifications notification)
        {
            Command.CommandText = @"
            INSERT INTO Notifications (Date, Content, Type) 
            VALUES (@Date, @Content, @Type)";

            Command.Parameters.AddWithValue("@Date", notification.Date);
            Command.Parameters.AddWithValue("@Message", notification.Message);
            Command.Parameters.AddWithValue("@UserName", notification.UserName);
            Command.ExecuteNonQuery();
        }
    }
    
}
