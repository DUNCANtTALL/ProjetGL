using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataListeNoir : IDataListNoir
    {

        SqlConnection connection;
        SqlCommand Command;
        GestionUsers gestionUsers = new  GestionUsers(); 

        
        public DataListeNoir()
        {
            connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            connection.Open();
            Command = new SqlCommand();
            Command.Connection = connection;

        }
        public void AddUser(User user , string raison)
        {
            Command.CommandText = @"
            INSERT INTO ListeNoir (UserId,Raison) 
            VALUES (@UserId, @Raison ) ";

            Command.Parameters.AddWithValue("@UserId", user.UserId);
            Command.Parameters.AddWithValue("@Raison", raison);
           
            Command.ExecuteNonQuery();
        }

        public void DeleteUser(int userID)
        {
            Command.CommandText = "DELETE FROM ListeNoir WHERE UserId = @UserId";
            Command.Parameters.Clear();

        }

       
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            Command.CommandText = "select * from ListeNoir";
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(gestionUsers.GetUser(reader.GetInt32(1)));
            }
            return users;
        }
    }
}
