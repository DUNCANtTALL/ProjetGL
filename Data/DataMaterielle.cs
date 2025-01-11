using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataMaterielle : IDataMaterielle
    {
        SqlConnection connection;
        SqlCommand Command;
        public DataMaterielle()
        {
            connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            connection.Open();
            Command = new SqlCommand();
            Command.Connection = connection;
        }
        public void AddMaterielle(Materielle materielle)
        {
            Command.CommandText = "INSERT INTO Materielle (Marque, Prix,CommandeId ,Quantite) VALUES (@Marque, @Prix, @Quantite, @CommandeId)";
            Command.Parameters.AddWithValue("@Marque", materielle.Marque);
            Command.Parameters.AddWithValue("@Prix", materielle.Prix);
            Command.Parameters.AddWithValue("@Quantite", materielle.Quantite);
            Command.Parameters.AddWithValue("@CommandeId", materielle.CommandeId1);
            Command.ExecuteNonQuery();



        }

        public List<Materielle> GetAllMaterielle(int commande)
        {
            List<Materielle> materielles = new List<Materielle>();
            Command.CommandText = $@"select * from Materielle where CommandeId={commande}";
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read()) {
                Materielle materielle = new Materielle
                (
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3),
                    reader.GetInt32(4)
                );
                materielles.Add(materielle);
            }
            return materielles;
        }
    }
}
