using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataAppelDoffre : IDataAppeleDoffreAp
    {
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;

        public DataAppelDoffre()
        {
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            _command = new SqlCommand { Connection = _connection };
        }

        public void AddAppelDoffre(AppelD_offre appelDoffre)
        {
            try
            {
                _connection.Open();
                _command.CommandText = @"
                    INSERT INTO AppelOffre (DateDebut, DateFin, Description, Titre) 
                    VALUES (@DateDebut, @DateFin, @Description, @Titre)";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@DateDebut", appelDoffre.DateDebut);
                _command.Parameters.AddWithValue("@DateFin", appelDoffre.DateFin);
                _command.Parameters.AddWithValue("@Description", appelDoffre.Description);
                _command.Parameters.AddWithValue("@Titre", appelDoffre.Titre);

                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'ajout de l'appel d'offre.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeleteAppelDoffre(DateTime dateDebut)
        {
            try
            {
                _connection.Open();
                _command.CommandText = "DELETE FROM AppelOffre WHERE DateDebut = @DateDebut";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@DateDebut", dateDebut);

                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la suppression de l'appel d'offre.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }

        public List<AppelD_offre> GetAllAppelDoffre()
        {
            var appelD_offres = new List<AppelD_offre>();
            try
            {
                _connection.Open();
                _command.CommandText = "SELECT DateDebut, DateFin, Description, Titre ,Id FROM AppelOffre";
                _command.Parameters.Clear();

                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var appelD_offre = new AppelD_offre
                        {
                            Id = reader.GetInt32(4),
                            DateDebut = reader.GetDateTime(0),
                            DateFin = reader.GetDateTime(1),
                            Description = reader.GetString(2),
                            Titre = reader.GetString(3)
                        };
                        appelD_offres.Add(appelD_offre);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des appels d'offre.", ex);
            }
            finally
            {
                _connection.Close();
            }

            return appelD_offres;
        }

        public AppelD_offre GetAppelD_Offre(int id)
        {
            var appelD_offre = new AppelD_offre();
            try
            {
                _connection.Open();
                _command.CommandText = @$"SELECT DateDebut, DateFin, Description, Titre, Id FROM AppelOffre WHERE Id = @id";
                _command.Parameters.Clear(); // Clear any existing parameters
                _command.Parameters.AddWithValue("@id", id); // Use a parameterized query to prevent SQL injection

                using (var reader = _command.ExecuteReader())
                {
                    if (reader.Read()) // Use `if` since you're fetching a single record
                    {
                        appelD_offre = new AppelD_offre
                        {
                            Id = reader.GetInt32(4),
                            DateDebut = reader.GetDateTime(0),
                            DateFin = reader.GetDateTime(1),
                            Description = reader.GetString(2),
                            Titre = reader.GetString(3)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des appels d'offre.", ex);
            }
            finally
            {
                _connection.Close();
            }

            return appelD_offre;
        }


    }
}
