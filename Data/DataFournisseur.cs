using ProjetGL.Models;
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
                _command.Parameters.AddWithValue("@NomSociété", fournisseur.nom ?? string.Empty); // Ensure value is not null
                _command.Parameters.AddWithValue("@Lieu", fournisseur.lieu);
                _command.Parameters.AddWithValue("@Adresse", fournisseur.Addresse);
                _command.Parameters.AddWithValue("@SiteInternet", fournisseur.siteInternet);

                _command.ExecuteNonQuery();


                _command.ExecuteNonQuery();
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
    }
}
