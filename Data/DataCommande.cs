using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataCommande : IDataCommande
    {

        SqlConnection connection;
        SqlCommand Command;
        GestionMaterielle gestionMaterielle = new GestionMaterielle();
        public DataCommande() {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\ProjetGL\ProjetGL\App_Data\ProjetGL.mdf;Integrated Security=True");
            Command = new SqlCommand();
            Command.Connection = connection;

        }


        public void AddCommande(Commande commande)
        {
            Command.CommandText = @"
            INSERT INTO Commande (AppelOffreId,FournisseurId,Total,DateLivraison,DateGarantie) 
            VALUES (@AppelOffreId, @FournisseurId, @Total, @DateLivraison, @DateGarantie)";

            Command.Parameters.AddWithValue("@AppelOffreId", commande.IdAppelOffre);
            Command.Parameters.AddWithValue("@FournisseurId", commande.IdFournisseur);
            Command.Parameters.AddWithValue("@Total", commande.Total);
            Command.Parameters.AddWithValue("@DateLivraison", commande.Datelivraison);
            Command.Parameters.AddWithValue("@DateGarantie", commande.Dategarantie);


            Command.ExecuteNonQuery();

        }

        public void DeleteCommande(DateTime dateCommande)
        {
            Command.CommandText = "DELETE FROM Commande WHERE DateCommande = @DateCommande";
            Command.Parameters.Clear();
        }

        public List<Commande> GetAllCommande()
        {
            List<Commande> commandes = new List<Commande>();
            Command.CommandText = "select * from Commande";
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Commande commande = new Commande
                (
                reader.GetInt32(1),
                  reader.GetInt32(2),
                     reader.GetFloat(3),
                     reader.GetDateTime(4),
                     reader.GetDateTime(5),
                     gestionMaterielle.GetMaterielle(reader.GetInt32(0)
                ));
                commandes.Add(commande);
            }
            return commandes;
        }
    }
}
