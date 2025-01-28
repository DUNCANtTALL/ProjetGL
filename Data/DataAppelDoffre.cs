using ProjetGL.Models;
using System;
using System.Collections.Generic;
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
            if (appelDoffre == null)
            {
                throw new ArgumentNullException(nameof(appelDoffre), "L'appel d'offre ne peut pas être null.");
            }

            if (appelDoffre.DateDebut < new DateTime(1753, 1, 1) || appelDoffre.DateFin < new DateTime(1753, 1, 1))
            {
                throw new ArgumentOutOfRangeException("Les dates doivent être comprises entre le 1/1/1753 et le 12/31/9999.");
            }

            try
            {
                _connection.Open();
                _command.CommandText = @"INSERT INTO AppelOffre (DateDebut, DateFin, Description, Titre) 
                               VALUES (@DateDebut, @DateFin, @Description, @Titre)";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@DateDebut", appelDoffre.DateDebut);
                _command.Parameters.AddWithValue("@DateFin", appelDoffre.DateFin);
                _command.Parameters.AddWithValue("@Description", appelDoffre.Description ?? string.Empty);
                _command.Parameters.AddWithValue("@Titre", appelDoffre.Titre ?? string.Empty);
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


        public void DeleteAppelDoffre(int Id)
        {
            try
            {
                _connection.Open(); // Vérifiez que la connexion est bien ouverte
                _command.CommandText = "DELETE FROM AppelOffre WHERE Id = @Id";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@Id", Id);

                int rowsAffected = _command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Aucune ligne n'a été supprimée. Vérifiez si l'ID existe.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la suppression sur bd fonction delete de l'appel d'offre.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }
        public AppelD_offre FindAppelOffre(int Id)
        {
            try
            {
                _connection.Open();
                _command.CommandText = @"
            SELECT Id, DateDebut, DateFin, Description, Titre 
            FROM AppelOffre 
            WHERE Id = @Id";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@Id", Id);

                using (var reader = _command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AppelD_offre
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DateDebut = reader.GetDateTime(reader.GetOrdinal("DateDebut")),
                            DateFin = reader.GetDateTime(reader.GetOrdinal("DateFin")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Titre = reader.GetString(reader.GetOrdinal("Titre"))
                        };
                    }
                }

                return null; // Si aucun résultat trouvé
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la recherche BD de fonction find de l'appel d'offre.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }
        public void UpdateAppelDoffre(int Id, string titre, DateTime dateDebut, DateTime dateFin, string description)
        {
            try
            {
                _connection.Open();

                // Préparez la requête de mise à jour
                _command.CommandText = @"
                 UPDATE AppelOffre 
                 SET Titre = @Titre, DateDebut = @DateDebut, DateFin = @DateFin, Description = @Description
                 WHERE Id = @Id";

                // Effacer les anciens paramètres et ajouter les nouveaux
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@Id", Id);
                _command.Parameters.AddWithValue("@Titre", titre);
                _command.Parameters.AddWithValue("@DateDebut", dateDebut);
                _command.Parameters.AddWithValue("@DateFin", dateFin);
                _command.Parameters.AddWithValue("@Description", description);

                // Exécution de la commande
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la mise à jour de l'appel d'offre.", ex);
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
                _command.CommandText = "SELECT DateDebut, DateFin, Description, Titre, Id FROM AppelOffre";
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

        public void AddImprimante(Imprimante imprimante)
        {
            try
            {
                _connection.Open();
                _command.CommandText = @"INSERT INTO Imprimantes (AppelId, Marque, VitesseImpression, Resolution,Quantity) 
                                           VALUES (@AppelId, @Marque, @VitesseImpression, @Resolution,@Quantity)";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@AppelId", imprimante.BesionID);
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
                _command.CommandText = @"INSERT INTO Ordinateurs (AppelId, Marque, CPU, RAM, DisqueDur, Ecran , Quantity) 
                                           VALUES (@AppelId, @Marque, @CPU, @RAM, @DisqueDur, @Ecran , @Quantity)";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@AppelId", ordinateur.BesoinId);
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

        public List<Ordinateur> GetOrdinateurs(int id)
        {
            var ordinateurs = new List<Ordinateur>();
            try
            {
                _connection.Open();
                _command.CommandText = "SELECT * FROM Ordinateurs WHERE AppelId = @AppelId";
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

        public List<Imprimante> GetImprimante(int id)
        {
            var imprimantes = new List<Imprimante>();
            try
            {
                _connection.Open();
                _command.CommandText = "SELECT * FROM Imprimantes WHERE AppelId = @AppelId";
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

        public AppelD_offre GetAppelD_Offre(int id)
        {
            AppelD_offre appelD_offre = null;

            try
            {
                _connection.Open();
                _command.CommandText = "SELECT DateDebut, DateFin, Description, Titre, Id FROM AppelOffre WHERE Id = @id";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@id", id);

                using (var reader = _command.ExecuteReader())
                {
                    if (reader.Read())
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
                throw new Exception("Erreur lors de la récupération de l'appel d'offre.", ex);
            }
            finally
            {
                _connection.Close();
            }

            return appelD_offre;
        }

        public AppelD_offre GetAppelD_Offre(DateTime date)
        {
            AppelD_offre appelD_offre = null;

            try
            {
                _connection.Open();
                _command.CommandText = "SELECT DateDebut, DateFin, Description, Titre, Id FROM AppelOffre WHERE DateDebut = @DateDebut";
                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@DateDebut", date);

                using (var reader = _command.ExecuteReader())
                {
                    if (reader.Read())
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
                throw new Exception("Erreur lors de la récupération de l'appel d'offre.", ex);
            }
            finally
            {
                _connection.Close();
            }

            return appelD_offre;
        }
    }
}
