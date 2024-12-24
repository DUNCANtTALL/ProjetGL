namespace ProjetGL.Models
{
    public class Fournisseur :User
    {
        private string name; 
        private string email;
        private string password;
        private Commande commande;
        private List<Message> messages;

        public Fournisseur(string name, string email, string password, Commande commande, List<Message> messages)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.commande = commande;
            this.messages = messages;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        
    }
}
