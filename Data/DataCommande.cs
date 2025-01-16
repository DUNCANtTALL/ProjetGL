using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataCommande : IDataCommande
    {
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;

        public DataCommande()
        {
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            _command = new SqlCommand { Connection = _connection };
        }

        public void AddCommande(Commande commande)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
            {
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = @"
                INSERT INTO Commande 
                (AppelOffreId, FournisseurId, Total, DateLivraison, DateGarantie, Marque,PrixUnitaire,Quantite) 
                VALUES (@AppelOffreId, @FournisseurId, @Total, @DateLivraison, @DateGarantie, @Marque, @PrixUnitaire ,@Quantite)"
                };

                command.Parameters.AddWithValue("@AppelOffreId", commande.IdAppelOffre);
                command.Parameters.AddWithValue("@FournisseurId", commande.IdFournisseur);
                command.Parameters.AddWithValue("@Total", commande.Total);
                command.Parameters.AddWithValue("@DateLivraison", commande.Datelivraison);
                command.Parameters.AddWithValue("@DateGarantie", commande.Dategarantie);
                command.Parameters.AddWithValue("@Marque", commande.Marque);
                command.Parameters.AddWithValue("@PrixUnitaire", commande.PrixUnitaire);
                command.Parameters.AddWithValue("@Quantite", commande.Quantite);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log the exception (consider implementing a logging mechanism)
                    throw new Exception("Erreur lors de l'ajout de la commande.", ex);
                }
                finally
                {
                    connection.Close(); // Ensure the connection is always closed
                }
            }
        }


        public void DeleteCommande(DateTime dateCommande)
        {
            try
            {
                _connection.Open();
                _command.CommandText = "DELETE FROM Commande WHERE DateCommande = @DateCommande";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@DateCommande", dateCommande);

                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la suppression de la commande.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }

        public List<Commande> GetAllCommande()
        {
            var commandes = new List<Commande>();
            try
            {
                _connection.Open();
                _command.CommandText = "SELECT * FROM Commande";
                _command.Parameters.Clear();

                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var commande = new Commande
                        {
                            Id = reader.GetInt32(0),
                            IdAppelOffre = reader.GetInt32(1),
                            IdFournisseur = reader.GetInt32(2),
                            Total = reader.GetFloat(3),
                            Datelivraison = reader.GetDateTime(4),
                            Dategarantie = reader.GetDateTime(5),
                            Marque = reader.GetString(6),
                            PrixUnitaire = reader.GetDecimal(7),
                            Quantite = reader.GetInt32(8) // Remplacez par la colonne appropriée
                        };
                        commandes.Add(commande);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des commandes.", ex);
            }
            finally
            {
                _connection.Close();
            }

            return commandes;
        }

        public void ValidateCommande(int id)
        {
            try
            {
                _connection.Open();
                _command.CommandText = "UPDATE Commande SET Status = 'Validée' WHERE Id = @Id";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@Id", id);

                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la validation de la commande.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
