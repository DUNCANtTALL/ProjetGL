using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataPanne :  IDataPanne
    {
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;


        public DataPanne()
        {
            // Connexion à la base de données (ajuster la chaîne de connexion selon ton environnement)
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;");
            _connection.Open();
        }

        public Pannes AjouterPanne(Pannes panne)
        {
            // Ajout d'une nouvelle panne dans la base de données
            using (var command = new SqlCommand(@"
                INSERT INTO Pannes (Description, DateSignalement, Type, Statut) 
                OUTPUT INSERTED.Id 
                VALUES (@Description, @DateSignalement, @Type, @Statut)", _connection))
            {
                command.Parameters.AddWithValue("@Description", panne.Description);
                command.Parameters.AddWithValue("@DateSignalement", panne.DateSignalement);
                command.Parameters.AddWithValue("@Type", panne.Type);
                command.Parameters.AddWithValue("@Statut", panne.Statut);

                panne.Id = (int)command.ExecuteScalar(); // Récupère l'ID généré par l'insertion
            }

            return panne;  // Retourne l'objet panne avec l'ID généré
        }

        public Pannes ObtenirPanneParId(int id)
        {
            // Récupère une panne spécifique par son ID
            using (var command = new SqlCommand("SELECT * FROM Pannes WHERE Id = @Id", _connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Pannes
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            DateSignalement = reader.GetDateTime(2),
                            Type = reader.GetString(3),
                            Statut = reader.GetString(4)
                        };
                    }
                }
            }
            return null;  // Retourne null si aucune panne n'est trouvée
        }

        public List<Pannes> ObtenirToutesLesPannes()
        {
            var pannes = new List<Pannes>();

            // Récupère toutes les pannes de la base de données
            using (var command = new SqlCommand("SELECT * FROM Pannes", _connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    pannes.Add(new Pannes
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        DateSignalement = reader.GetDateTime(2),
                        Type = reader.GetString(3),
                        Statut = reader.GetString(4)
                    });
                }
            }
            return pannes;  // Retourne la liste des pannes
        }

        public void MettreAJourPanne(Pannes panne)
        {
            // Met à jour une panne existante
            using (var command = new SqlCommand(@"
                UPDATE Pannes 
                SET Description = @Description, DateSignalement = @DateSignalement, Type = @Type, Statut = @Statut
                WHERE Id = @Id", _connection))
            {
                command.Parameters.AddWithValue("@Id", panne.Id);
                command.Parameters.AddWithValue("@Description", panne.Description);
                command.Parameters.AddWithValue("@DateSignalement", panne.DateSignalement);
                command.Parameters.AddWithValue("@Type", panne.Type);
                command.Parameters.AddWithValue("@Statut", panne.Statut);

                command.ExecuteNonQuery();  // Exécute la mise à jour
            }
        }

        public void SupprimerPanne(int id)
        {
            // Supprime une panne de la base de données
            using (var command = new SqlCommand("DELETE FROM Pannes WHERE Id = @Id", _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();  // Exécute la suppression
            }
        }
    }
}
