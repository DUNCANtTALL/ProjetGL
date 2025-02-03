using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataListeNoir : IDataListNoir
    {
        private readonly string _connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private GestionUsers gestionUsers = new GestionUsers();

        public void AddUser(User user, string raison)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand Command = new SqlCommand(@"
                    INSERT INTO ListeNoir (UserId,Raison) VALUES (@UserId, @Raison)", connection))
                {
                    Command.Parameters.AddWithValue("@UserId", user.UserId);
                    Command.Parameters.AddWithValue("@Raison", string.IsNullOrEmpty(raison) ? DBNull.Value : (object)raison);
                    Command.ExecuteNonQuery();
                }
            }
        }

        public bool CheckUser(int userID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand Command = new SqlCommand("SELECT 1 FROM ListeNoir WHERE UserId = @UserId", connection))
                {
                    Command.Parameters.Add("@UserId", SqlDbType.Int).Value = userID;
                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }


        public void DeleteUser(int userID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand Command = new SqlCommand("DELETE FROM ListeNoir WHERE UserId = @UserId", connection))
                {
                    Command.Parameters.AddWithValue("@UserId", userID);
                    Command.ExecuteNonQuery();
                }
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand Command = new SqlCommand("SELECT UserId FROM ListeNoir", connection))
                {
                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(gestionUsers.GetUser(reader.GetInt32(0))); // Get user from UserId
                        }
                    }
                }
            }
            return users;
        }
    }
}
