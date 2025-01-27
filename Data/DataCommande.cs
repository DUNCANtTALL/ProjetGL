using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Data;
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

        public int AddCommande(Commande commande)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
            {
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = @"
            INSERT INTO Commande 
            (AppelOffreId, FournisseurId, Total, DateLivraison, DateGarantie, Marque, PrixUnitaire, PrixUnitaireImprimantes, Quantite, QuantiteImprimantes) 
            VALUES (@AppelOffreId, @FournisseurId, @Total, @DateLivraison, @DateGarantie, @Marque, @PrixUnitaire, @PrixUnitaireImprimantes, @Quantite, @QuantiteImprimantes);
            SELECT CAST(scope_identity() AS int);"  // This will return the last inserted ID.
                };

                command.Parameters.AddWithValue("@AppelOffreId", commande.IdAppelOffre);
                command.Parameters.AddWithValue("@FournisseurId", commande.IdFournisseur);
                command.Parameters.AddWithValue("@Total", commande.Total);
                command.Parameters.AddWithValue("@DateLivraison", commande.Datelivraison);
                command.Parameters.AddWithValue("@DateGarantie", commande.Dategarantie);
                command.Parameters.AddWithValue("@Marque", commande.Marque);
                command.Parameters.AddWithValue("@PrixUnitaire", commande.PrixUnitaire);
                command.Parameters.AddWithValue("@Quantite", commande.Quantite);
                command.Parameters.AddWithValue("@PrixUnitaireImprimantes", commande.PrixUnitaireImprimate);
                command.Parameters.AddWithValue("@QuantiteImprimantes", commande.QuantiteImprimantes);

                try
                {
                    connection.Open();
                    // Execute the query and return the inserted ID
                    commande.Id = (int)command.ExecuteScalar();  // The ID will be returned here.
                    return commande.Id;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    throw new Exception("Erreur lors de l'ajout de la commande.", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public void AddImprimante(Imprimante imprimante)
        {
            try
            {
                _connection.Open();
                _command.CommandText = @"INSERT INTO Imprimantes (CommandID, Marque, VitesseImpression, Resolution,Quantity) 
                                           VALUES (@CommandID, @Marque, @VitesseImpression, @Resolution,@Quantity)";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@CommandID", imprimante.BesionID);
                _command.Parameters.AddWithValue("@Marque", imprimante.Marsque);
                _command.Parameters.AddWithValue("@VitesseImpression", imprimante.Vitesse);
                _command.Parameters.AddWithValue("@Resolution", imprimante.Resoluton);
                _command.Parameters.AddWithValue("@Quantity", imprimante.Quantity);


                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'ajout de l'imprimante.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void AddOrdinateur(Ordinateur ordinateur)
        {
            try
            {
                _connection.Open();
                _command.CommandText = @"INSERT INTO Ordinateurs (CommandID, Marque, CPU, RAM, DisqueDur, Ecran , Quantity) 
                                           VALUES (@CommandID, @Marque, @CPU, @RAM, @DisqueDur, @Ecran , @Quantity)";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@CommandID", ordinateur.BesoinId);
                _command.Parameters.AddWithValue("@Marque", ordinateur.Marque);
                _command.Parameters.AddWithValue("@CPU", ordinateur.Cpu);
                _command.Parameters.AddWithValue("@RAM", ordinateur.Ram);
                _command.Parameters.AddWithValue("@DisqueDur", ordinateur.Disque);
                _command.Parameters.AddWithValue("@Ecran", ordinateur.Ecran);
                _command.Parameters.AddWithValue("@Quantity", ordinateur.Quantity);


                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'ajout de l'ordinateur.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }
        public List<Imprimante> GetImprimante(int id)
        {
            var imprimantes = new List<Imprimante>();
            try
            {
                _connection.Open();
                _command.CommandText = "SELECT * FROM Imprimantes WHERE CommandID = @AppelId";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@AppelId", id);
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        imprimantes.Add(new Imprimante(
                            reader.IsDBNull(2) ? "" : reader.GetString(2),    // Marsque
                            reader.IsDBNull(3) ? "" : reader.GetString(3),    // Vitesse
                            reader.IsDBNull(4) ? "" : reader.GetString(4),    // Resoluton
                            reader.IsDBNull(5) ? 0 : reader.GetInt32(5),      // Quantity
                            reader.IsDBNull(7) ? 0 : reader.GetInt32(7)       // BesoinID
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des imprimantes.", ex);
            }
            finally
            {
                _connection.Close();
            }
            return imprimantes;

        }

        public List<Ordinateur> GetOrdinateurs(int id)
        {
            var ordinateurs = new List<Ordinateur>();
            try
            {
                _connection.Open();
                _command.CommandText = "SELECT * FROM Ordinateurs WHERE CommandID = @AppelId";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@AppelId", id);
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ordinateurs.Add(new Ordinateur(
                            reader.IsDBNull(2) ? "" : reader.GetString(2),   // Marque
                            reader.IsDBNull(3) ? "" : reader.GetString(3),   // Cpu
                            reader.IsDBNull(4) ? "" : reader.GetString(4),   // Ram
                            reader.IsDBNull(5) ? "" : reader.GetString(5),   // Disque
                            reader.IsDBNull(6) ? "" : reader.GetString(6),   // Autres détails
                            reader.IsDBNull(7) ? 0 : reader.GetInt32(7),      // BesoinId
                            reader.IsDBNull(9) ? 0 : reader.GetInt32(9)    // Quantity

                            ));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des ordinateurs.", ex);
            }
            finally
            {
                _connection.Close();
            }
            return ordinateurs;
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
                _command.CommandText = "SELECT Id, AppelOffreId, FournisseurId, Total, DateLivraison, DateGarantie, Marque, PrixUnitaire, Quantite, isValidated, PrixUnitaireImprimantes, QuantiteImprimantes FROM Commande";
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
                            Total = reader.GetDouble(3),
                            Datelivraison = reader.GetDateTime(4),
                            Dategarantie = reader.GetDateTime(5),
                            Marque = reader.GetString(6),
                            PrixUnitaire = reader.GetDecimal(7),
                            Quantite = reader.GetInt32(8),
                            // Handle nullable columns
                            PrixUnitaireImprimate = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                            QuantiteImprimantes = reader.IsDBNull(11) ? 0 : reader.GetInt32(11)
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



        public List<Commande> GetValidateCommande()
        {
            var commandes = new List<Commande>();
            try
            {
                _connection.Open();
                _command.CommandText = "SELECT * FROM Commande Where isValidated = 1";
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
                            Total = reader.GetDouble(3),
                            Datelivraison = reader.GetDateTime(4),
                            Dategarantie = reader.GetDateTime(5),
                            Marque = reader.GetString(6),
                            PrixUnitaire = reader.GetDecimal(7),
                            Quantite = reader.GetInt32(8) ,// Remplacez par la colonne appropriée
                            // Handle nullable columns
                            PrixUnitaireImprimate = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                            QuantiteImprimantes = reader.IsDBNull(11) ? 0 : reader.GetInt32(11)
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
                _command.CommandText = "UPDATE Commande SET isValidated = 1 WHERE Id = @Id";
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

        public Commande GetCommande(int id)
        {
            var commande = new Commande();
            try
            {
                using (var connection = new SqlConnection(_connection.ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * FROM Commande WHERE Id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                commande = new Commande
                                {
                                    Id = reader.GetInt32(0),
                                    IdAppelOffre = reader.GetInt32(1),
                                    IdFournisseur = reader.GetInt32(2),
                                    Total = reader.GetDouble(3),
                                    Datelivraison = reader.GetDateTime(4),
                                    Dategarantie = reader.GetDateTime(5),
                                    Marque = reader.GetString(6),
                                    PrixUnitaire = reader.GetDecimal(7),
                                    Quantite = reader.GetInt32(8),// Remplacez par la colonne appropriée
                                    PrixUnitaireImprimate = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                                    QuantiteImprimantes = reader.IsDBNull(11) ? 0 : reader.GetInt32(11)
                                }; 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des commandes.", ex);
            }

            return commande;
        }

        public Commande GetCommande(int id, DateTime date)
        {
            var commande = new Commande();
            try
            {
                using (var connection = new SqlConnection(_connection.ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * FROM Commande WHERE FournisseurId = @id And DateLivraison= @DateLivraison", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@DateLivraison",date);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                commande = new Commande
                                {
                                    Id = reader.GetInt32(0),
                                    IdAppelOffre = reader.GetInt32(1),
                                    IdFournisseur = reader.GetInt32(2),
                                    Total = reader.GetDouble(3),
                                    Datelivraison = reader.GetDateTime(4),
                                    Dategarantie = reader.GetDateTime(5),
                                    Marque = reader.GetString(6),
                                    PrixUnitaire = reader.GetDecimal(7),
                                    Quantite = reader.GetInt32(8),// Remplacez par la colonne appropriée
                                    PrixUnitaireImprimate = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                                    QuantiteImprimantes = reader.IsDBNull(11) ? 0 : reader.GetInt32(11)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération des commandes.", ex);
            }

            return commande;
        }
    }
}
