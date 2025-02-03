using ProjetGL.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataFournisseurs : IDataFournisseur
    {

        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;
        public DataFournisseurs()
        {

            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            _command = new SqlCommand { Connection = _connection };

        }
        public void AddFournisseur(Societe fournisseur)
        {
            try
            {
                _connection.Open();
                _command.CommandText = @"
            INSERT INTO Fournisseurs (FournisseurId, NomSociété, Lieu, Adresse, SiteInternet) 
            VALUES (@FournisseurId, @NomSociété, @Lieu, @Adresse, @SiteInternet)";

                _command.Parameters.Clear();
                _command.Parameters.AddWithValue("@FournisseurId", fournisseur.fournisseurId);
                _command.Parameters.AddWithValue("@NomSociété", fournisseur.nom ?? string.Empty); // Handle null
                _command.Parameters.AddWithValue("@Lieu", fournisseur.lieu ?? (object)DBNull.Value); // Handle null
                _command.Parameters.AddWithValue("@Adresse", fournisseur.Addresse ?? (object)DBNull.Value); // Handle null
                _command.Parameters.AddWithValue("@SiteInternet", fournisseur.siteInternet ?? (object)DBNull.Value); // Handle null

                _command.ExecuteNonQuery(); // Single call
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'ajout du Fournisseur.", ex);
            }
            finally
            {
                _connection.Close();
            }
        }


        public void DeleteFournisseur(int id)
        {
            throw new NotImplementedException();
        }

        public List<Societe> GetAllFournisseur()
        {
            throw new NotImplementedException();
        }

        public Societe GetFournisseurById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsAlreadyExist(int id)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
            {
                connection.Open();
                // Adjusting the query to check the 'Fournisseurs' table
                using (SqlCommand Command = new SqlCommand("SELECT 1 FROM Fournisseurs WHERE FournisseurId = @FournisseurId", connection))
                {
                    Command.Parameters.Add("@FournisseurId", SqlDbType.Int).Value = id;
                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }

    }
}
