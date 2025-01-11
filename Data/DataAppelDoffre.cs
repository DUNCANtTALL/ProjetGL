using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Data
{
    public class DataAppelDoffre : IDataAppeleDoffreAp
    {

        SqlConnection connection;
        SqlCommand Command;
        public DataAppelDoffre()
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-6QJ1K1I;Initial Catalog=ProjetGL;Integrated Security=True");
            Command = new SqlCommand();
            Command.Connection = connection;

        }
        public void AddAppelDoffre(AppelD_offre appelDoffre)
        {
            Command.CommandText = @"
            INSERT INTO AppelOffre (DateDebut, DateFin, Description, Type) 
            VALUES (@DateDebut, @DateFin, @Description)";

            Command.Parameters.AddWithValue("@DateDebut", appelDoffre.DateDebut);
            Command.Parameters.AddWithValue("@DateFin", appelDoffre.DateFin);
            Command.Parameters.AddWithValue("@Description", appelDoffre.Description);
 
            Command.ExecuteNonQuery();
        }

        public void DeleteAppelDoffre(DateTime dateDebut)
        {
            Command.CommandText = "DELETE FROM AppelOffre WHERE DateDebut = @DateDebut";
            Command.Parameters.Clear();

        }

        public List<AppelD_offre> GetAllAppelDoffre()
        {
           List<AppelD_offre> appelD_offres = new List<AppelD_offre>();
            Command.CommandText = "select * from AppelOffre";
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                AppelD_offre appelD_offre = new AppelD_offre
                (
                reader.GetDateTime(1),
                  reader.GetDateTime(2),
                     reader.GetString(3)
                       
                );
                appelD_offres.Add(appelD_offre);
            }
            return appelD_offres;
        }
    }
}
