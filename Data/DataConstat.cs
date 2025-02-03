using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataConstat: IDataConstat
    {
        private readonly SqlConnection _connection;

        public DataConstat()
        {
            // Connexion à la base de données (ajuster la chaîne de connexion selon ton environnement)
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;");
            _connection.Open();
        }
        public Constat AjouterConstat(Constat constat)
        {
            try
            {
                Console.WriteLine("Tentative d'ajouter le constat dans la base de données.");
                using (var command = new SqlCommand(@"
            INSERT INTO Constats (Explication, DateConstat, Frequence, Ordre, PanneId) 
            OUTPUT INSERTED.Id 
            VALUES (@Explication, @DateConstat, @Frequence, @Ordre, @PanneId)", _connection))
                {
                    command.Parameters.AddWithValue("@Explication", constat.Explication);
                    command.Parameters.AddWithValue("@DateConstat", constat.DateConstat);
                    command.Parameters.AddWithValue("@Frequence", constat.Frequence);
                    command.Parameters.AddWithValue("@Ordre", constat.Ordre);
                    command.Parameters.AddWithValue("@PanneId", constat.PanneId);

                    constat.Id = (int)command.ExecuteScalar(); // Récupère l'ID généré par l'insertion
                }

                return constat;  // Retourne l'objet constat avec l'ID généré
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout du constat : {ex.Message}");
                throw;  // Relance l'exception
            }
        }


        public List<Constat> ObtenirConstatsParPanneId(int panneId)
        {
            var constats = new List<Constat>();

            // Récupère les constats en fonction de l'ID de la panne
            using (var command = new SqlCommand("SELECT * FROM Constats WHERE PanneId = @PanneId", _connection))
            {
                command.Parameters.AddWithValue("@PanneId", panneId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        constats.Add(new Constat
                        {
                            Id = reader.GetInt32(0),
                            Explication = reader.GetString(1),
                            DateConstat = reader.GetDateTime(2),
                            Frequence = reader.GetString(3),
                            Ordre = reader.GetString(4),
                            PanneId = reader.GetInt32(5)
                        });
                    }
                }
            }

            return constats;  // Retourne la liste des constats pour une panne donnée
        }
        public List<Constat> ObtenirConstats()
        {
            var constats = new List<Constat>();

            // Récupère les constats en fonction de l'ID de la panne
            using (var command = new SqlCommand("SELECT * FROM Constats ", _connection))
            {

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        constats.Add(new Constat
                        {
                            Id = reader.GetInt32(0),
                            Explication = reader.GetString(1),
                            DateConstat = reader.GetDateTime(2),
                            Frequence = reader.GetString(3),
                            Ordre = reader.GetString(4),
                            PanneId = reader.GetInt32(5)
                        });
                    }
                }
            }

            return constats;  // Retourne la liste des constats pour une panne donnée
        }

        public void SupprimerConstat(int id)
        {
            // Supprime un constat de la base de données en fonction de l'ID
            using (var command = new SqlCommand("DELETE FROM Constats WHERE Id = @Id", _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();  // Exécute la suppression
            }
        }
    }
}
