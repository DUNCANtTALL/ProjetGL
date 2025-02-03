using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataUsers : IDataUsers
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;";

        public void AddUser(User account)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"
                    INSERT INTO Users (Name, Email, Password, UserType, CreatedAt) 
                    VALUES (@Name, @Email, @Password, @UserType, GETDATE())", connection))
                {
                    command.Parameters.AddWithValue("@Name", account.Name);
                    command.Parameters.AddWithValue("@Email", account.Email);
                    command.Parameters.AddWithValue("@Password", account.Password);
                    command.Parameters.AddWithValue("@UserType", account.Type);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Users WHERE Name = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine(rowsAffected > 0 ? "User deleted successfully." : "No user found with the provided username.");
                }
            }
        }

        public User FindUser(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT UserId, Name, Email, Password, UserType FROM Users WHERE Email = @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(reader["UserID"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                Type = reader["UserType"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public User FindUserByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT UserId, Name, Email, Password FROM Users WHERE UserId = @UserId", connection))
                {
                    command.Parameters.AddWithValue("@UserId", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public User FindUserByName(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT UserId, Name, Email, Password, UserType FROM Users WHERE Name = @Name", connection))
                {
                    command.Parameters.AddWithValue("@Name", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(reader["UserID"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                Type = reader["UserType"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT UserId, Name, Email, Password FROM Users", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString()
                            });
                        }
                    }
                }
            }
            return users;
        }

        public List<User> GetDepartement()
        {
            var users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT UserId, Name, Email, Password FROM Users WHERE UserType = 'Departement'", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString()
                            });
                        }
                    }
                }
            }
            return users;
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Users SET Password = @Password WHERE Name = @Name", connection))
                {
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
