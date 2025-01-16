using ProjetGL.Buisness;
using ProjetGL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataBesion : IDataBesoin
    {
        private readonly SqlConnection connection;

        public DataBesion()
        {
            connection = new SqlConnection
            {
                ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;"
            };
            connection.Open();
        }

        public Besion CreateBesoin(string desc)
        {
            int newId;

            using (var command = new SqlCommand(@"
                INSERT INTO Besion (Description) 
                OUTPUT INSERTED.Id 
                VALUES (@Description)", connection))
            {
                command.Parameters.AddWithValue("@Description", desc);
                newId = (int)command.ExecuteScalar();
            }

            return new Besion(newId, desc);
        }

        public void AddImprimante(Imprimante imprimante)
        {
            try
            {
                using (var command = new SqlCommand(@"
            INSERT INTO Imprimantes (BesionId, Marque, VitesseImpression, Resolution) 
            VALUES (@BesionId, @Marque, @VitesseImpression, @Resolution)", connection))
                {
                    command.Parameters.AddWithValue("@BesionId", imprimante.BesionID);
                    command.Parameters.AddWithValue("@Marque", imprimante.Marsque);
                    command.Parameters.AddWithValue("@VitesseImpression", imprimante.Vitesse);
                    command.Parameters.AddWithValue("@Resolution", imprimante.Resoluton);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding Imprimante: {ex.Message}");
                throw;
            }
        }



        public void AddOrdinateur(Ordinateur ordinateur)
        {
            using (var command = new SqlCommand(@"
                INSERT INTO Ordinateurs (BesionId, Marque, CPU, RAM, DisqueDur, Ecran) 
                VALUES (@BesionId, @Marque, @CPU, @RAM, @DisqueDur, @Ecran)", connection))
            {
                command.Parameters.AddWithValue("@BesionId", ordinateur.BesoinId);
                command.Parameters.AddWithValue("@Marque", ordinateur.Marque);
                command.Parameters.AddWithValue("@CPU", ordinateur.Cpu);
                command.Parameters.AddWithValue("@RAM", ordinateur.Ram);
                command.Parameters.AddWithValue("@DisqueDur", ordinateur.Disque);
                command.Parameters.AddWithValue("@Ecran", ordinateur.Ecran);

                command.ExecuteNonQuery();
            }
        }

        public List<Besion> GetBesions()
        {
            var besions = new List<Besion>();

            using (var command = new SqlCommand("SELECT * FROM Besion", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    besions.Add(new Besion(reader.GetInt32(0), reader.GetString(1)));
                }
            }

            return besions;
        }

        public List<Imprimante> GetImprimante(int id)
        {
            var imprimantes = new List<Imprimante>();

            using (var command = new SqlCommand("SELECT * FROM Imprimantes WHERE BesionId = @BesionId", connection))
            {
                command.Parameters.AddWithValue("@BesionId", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        imprimantes.Add(new Imprimante(
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetInt32(1)
                        ));
                    }
                }
            }

            return imprimantes;
        }

        public void ValidateBesion(int id)
        {
            using (var command = new SqlCommand(@"
                UPDATE Besion 
                SET IsValidated = 1 
                WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public List<Ordinateur> GetOrdinateurs(int id)
        {
            var ordinateurs = new List<Ordinateur>();

            using (var command = new SqlCommand("SELECT * FROM Ordinateurs WHERE BesionId = @BesionId", connection))
            {
                command.Parameters.AddWithValue("@BesionId", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ordinateurs.Add(new Ordinateur(
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetInt32(1)
                        ));
                    }
                }
            }

            return ordinateurs;
        }

        public void AddBesoin(string desc)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // Delete related Ordinateurs
                    using (var command = new SqlCommand(@"
                DELETE FROM Ordinateurs WHERE BesionId = @Id", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }

                    // Delete related Imprimantes (if applicable)
                    using (var command = new SqlCommand(@"
                DELETE FROM Imprimantes WHERE BesionId = @Id", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }

                    // Delete the Besion
                    using (var command = new SqlCommand(@"
                DELETE FROM Besion WHERE Id = @Id", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error: " + ex.Message);
                    throw;
                }
            }
        }


        public bool status(int id)
        {
            bool b = false;
            using (var command = new SqlCommand("SELECT * FROM Besion WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        b = reader.GetBoolean(2);
                        
                    }
                }
            }



            return b;
        }

        public List<Besion> GetValidatedBesions()
        {
            var besions = new List<Besion>();

            using (var command = new SqlCommand("SELECT * FROM Besion WHERE isValidated = 1", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    besions.Add(new Besion(reader.GetInt32(0), reader.GetString(1)));
                }
            }

            return besions;
        }

    }
}
