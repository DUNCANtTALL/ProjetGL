using ProjetGL.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataLivraison : IDataLivrason
    {
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;

        public DataLivraison()
        {
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            _command = new SqlCommand { Connection = _connection };
        }

        public Livraison GetLivraison()
        {
            var livraison = new Livraison();

            try
            {
                _connection.Open();

                // Fetch validated Imprimantes
                livraison.imprimantes = GetValidatedImprimantes();

                // Fetch validated Ordinateurs
                livraison.ordinateurs = GetValidatedOrdinateurs();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la récupération de la livraison.", ex);
            }
            finally
            {
                _connection.Close();
            }

            return livraison;
        }

        private List<Imprimante> GetValidatedImprimantes()
        {
            var imprimantes = new List<Imprimante>();
            _command.CommandText = @"
        SELECT 
            i.Marque AS ImprimanteMarque,
            i.VitesseImpression,
            i.Resolution,
            i.Quantity,
            i.CommandID,
            i.isValidated,
            i.Affecter
        FROM 
            dbo.Imprimantes i
        INNER JOIN 
            dbo.Commande c ON i.CommandID = c.Id
        WHERE 
            c.isValidated = 1";
            _command.Parameters.Clear();

            using (var reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    imprimantes.Add(new Imprimante {
                       Marsque =  reader.IsDBNull(0) ? "" : reader.GetString(0),    // Marque
                       Vitesse =  reader.IsDBNull(1) ? "" : reader.GetString(1),    // Vitesse Impression
                       Resoluton =  reader.IsDBNull(2) ? "" : reader.GetString(2),    // Résolution
                       BesionID =  reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                       Quantity = reader.IsDBNull(3) ? 0 : reader.GetInt32(3) ,     // Quantity
                       Status = reader.IsDBNull(5) ? false : reader.GetBoolean(5),     // Quantity
                       AffecteId = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)

                    });
                }
            }

            return imprimantes;
        }

        private List<Ordinateur> GetValidatedOrdinateurs()
        {
            var ordinateurs = new List<Ordinateur>();
            _command.CommandText = @"
        SELECT 
            o.Marque AS OrdinateurMarque,
            o.CPU,
            o.RAM,
            o.DisqueDur,
            o.Ecran,
            o.Quantity,
            o.CommandID,
            o.isValidated,
            o.Affecter
        FROM 
            dbo.Ordinateurs o
        INNER JOIN 
            dbo.Commande c ON o.CommandID = c.Id
        WHERE 
            c.isValidated = 1";
            _command.Parameters.Clear();

            using (var reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ordinateurs.Add(new Ordinateur {
                     Marque =   reader.IsDBNull(0) ? "" : reader.GetString(0),   // Marque
                     Cpu =  reader.IsDBNull(1) ? "" : reader.GetString(1),   // CPU
                     Ram=reader.IsDBNull(2) ? "" : reader.GetString(2),   // RAM
                     Disque =reader.IsDBNull(3) ? "" : reader.GetString(3),   // DisqueDur
                     Ecran =reader.IsDBNull(4) ? "" : reader.GetString(4),   // Écran
                     BesoinId= reader.IsDBNull(6) ? 0 : reader.GetInt32(6),      // BesionID
                     Quantity=reader.IsDBNull(5) ? 0 : reader.GetInt32(5) ,    // Quantity
                      Status = reader.IsDBNull(7) ? false : reader.GetBoolean(7) ,    // Quantity
                        AffectedId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8)
                    }
                        );
                    
                }
            }

            return ordinateurs;
        }


        public void validateImprimante(int id)
        {
            var query = "UPDATE Imprimantes SET isValidated = 1 WHERE CommandID = @CommandId";

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommandId", id);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException($"No Commande found with Id {id}");
                    }
                }
            }
        }

        public void validateOrdinateur(int id)
        {
            var query = "UPDATE Ordinateurs SET isValidated = 1 WHERE CommandID = @CommandId";

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommandId", id);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException($"No Commande found with Id {id}");
                    }
                }
            }
        }

      

       

    }
}
