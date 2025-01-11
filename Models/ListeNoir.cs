namespace ProjetGL.Models
{
    public class ListeNoir
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public string Raison { get; set; } 

        public User? User { get; set; }

        public ListeNoir() { }

        public ListeNoir(int userId, string raison)
        {
            UserId = userId;
            Raison = raison;
        }
    }
}
