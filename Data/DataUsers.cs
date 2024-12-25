using ProjetGL.Models;
using System.Data.SqlClient;
using System.Security.Principal;

namespace ProjetGL.Data
{
    public class DataUsers : IDataUsers
    {
        SqlConnection connection;
        SqlCommand Command;

        public DataUsers()
        {
            connection = new SqlConnection("Data Source=DESKTOP-7VJ1VUJ;Initial Catalog=ProjetGL;Integrated Security=True");
            Command = new SqlCommand();
            Command.Connection = connection;
        }
        

        public void AddUser(User account)
        {
            Command.CommandText = @"
            INSERT INTO Users (Name, Email, Password, UserType, CreatedAt) 
            VALUES (@Name, @Email, @Password, @UserType, GETDATE())";

            Command.Parameters.AddWithValue("@Name", account.Name);
            Command.Parameters.AddWithValue("@Email", account.Email);
            Command.Parameters.AddWithValue("@Password", account.Password);
            Command.Parameters.AddWithValue("@UserType", account.GetType());
            Command.ExecuteNonQuery();
        }

        public void DeleteUser(string username)
        {
            try
            {
                Command.CommandText = "DELETE FROM Users WHERE Name = @Username";
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Username", username);

                int rowsAffected = Command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("User deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No user found with the provided username.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");
            }
        }


        public User FindUser(string username)
        {
            try
            {
                Command.CommandText = "SELECT UserId, Name, Email, Password, UserType, CreatedAt FROM Users WHERE Name = @Username";
                SqlDataReader rs = Command.ExecuteReader();
                
                while (rs.Read())
                {
                    return new User
                    {
                        Name = rs["Name"].ToString(),
                        Email = rs["Email"].ToString(),
                        Password = rs["Password"].ToString(),
                    };
                }
                rs.Close();
                return null; 
             
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while finding the user: {ex.Message}");
                return null;
            }
        }


        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            try
            {
                Command.CommandText = "SELECT UserId, Name, Email, Password, CreatedAt FROM Users";
                SqlDataReader rs = Command.ExecuteReader();
                while (rs.Read())
                {
                    User user = new User();
                    user.Name = (string)rs["Name"];
                    user.Email = (string)rs["Email"];
                    user.Password = (string)rs["Password"];
                    users.Add(user); 
                }
                rs.Close();
                return users;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
            }

            return users;
        }


        public void UpdateUser(User user)
        {
            try
            {
                Command.CommandText = $@"update Users set password='{user.Password}' 
                                        where username='{user.Name}'";
                Command.ExecuteNonQuery();

            }
            catch
            {
                Console.WriteLine($"An error occurred while Updating");


            }
        }
    }
}
