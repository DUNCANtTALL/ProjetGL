using ProjetGL.Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ProjetGL.Data
{
    public class DataAffectaion : IDataAffectation
    {
        private readonly SqlConnection connection;

        public DataAffectaion()
        {
            connection = new SqlConnection
            {
                ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;"
            };
            connection.Open();
        }

        public void affecterMateriel(int id, int departement, string materielType)
        {
            string query = "";

            if (materielType == "Ordinateur")
            {
                query = "UPDATE Ordinateurs SET Affecter = @DepartementId WHERE CommandID = @MaterielId";
            }
            else if (materielType == "Imprimante")
            {
                query = "UPDATE Imprimantes SET Affecter = @DepartementId WHERE CommandID = @MaterielId";
            }
            else
            {
                throw new ArgumentException("Invalid materiel type. Must be 'Ordinateur' or 'Imprimante'.");
            }

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MaterielId", id);
                command.Parameters.AddWithValue("@DepartementId", departement);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException($"No {materielType} found with Id {id}");
                }
            }
        }

        public List<Imprimante> GetImprimante(int departement)
        {
            var imprimantes = new List<Imprimante>();
            var query = @"
                SELECT 
                    Id, Marque, VitesseImpression, Resolution, Quantity 
                FROM 
                    dbo.Imprimantes 
                WHERE 
                    Affecter = @DepartementId";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartementId", departement);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var imprimante = new Imprimante
                        {
                          Marsque =   reader.IsDBNull(1) ? "" : reader.GetString(1),  // Marque
                          Vitesse =  reader.IsDBNull(2) ? "" : reader.GetString(2),  // Vitesse
                          Resoluton =  reader.IsDBNull(3) ? "" : reader.GetString(3),  // Résolution
                          Quantity =   reader.IsDBNull(4) ? 0 : reader.GetInt32(4)     // Quantity
                        };
                        imprimantes.Add(imprimante);
                    }
                }
            }
            return imprimantes;
        }

        public List<Ordinateur> GetOrdinateur(int departement)
        {
            var ordinateurs = new List<Ordinateur>();
            var query = @"
                SELECT 
                    Id, Marque, CPU, RAM, DisqueDur, Ecran, Quantity 
                FROM 
                    dbo.Ordinateurs 
                WHERE 
                    Affecter = @DepartementId";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartementId", departement);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ordinateur = new Ordinateur
                        {
                         Marque =    reader.IsDBNull(1) ? "" : reader.GetString(1),  // Marque
                         Cpu = reader.IsDBNull(2) ? "" : reader.GetString(2),  // CPU
                         Ram = reader.IsDBNull(3) ? "" : reader.GetString(3),  // RAM
                         Disque= reader.IsDBNull(4) ? "" : reader.GetString(4),  // DisqueDur
                         Ecran= reader.IsDBNull(5) ? "" : reader.GetString(5),  // Écran
                         Quantity =  reader.IsDBNull(6) ? 0 : reader.GetInt32(6)     // Quantity
                        };
                        ordinateurs.Add(ordinateur);
                    }
                }
            }
            return ordinateurs;
        }
    }
}
